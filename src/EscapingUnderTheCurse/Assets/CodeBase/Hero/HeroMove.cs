using Code.Gameplay.Features.Movement;
using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroMove : MonoBehaviour, ISavedProgress
  {
    public float MoveDirection;
    public float JumpHeight;
    public MovingDirection Direction;

    private HeroGrounder _grounding;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
      _grounding = GetComponentInChildren<HeroGrounder>();
      _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      if (Direction == MovingDirection.Left && MoveDirection > 0)
        MoveDirection = -1;
      if(Direction == MovingDirection.Right && MoveDirection < 0)
        MoveDirection = 1;
      
      if (CanJump()) 
        Jump();
    }

    private void Jump() => 
      _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpHeight);

    private bool CanJump() => 
      Input.GetKeyDown(KeyCode.Space) && _grounding.IsGrounded;

    public void UpdateProgress(PlayerProgress progress)
    {
      Vector3Data savedPosition = gameObject.transform.position.AsVector3Data();
      
      if(savedPosition != null) 
        progress.Position = new Vector3Data(savedPosition.X, savedPosition.Y, savedPosition.Z);
    }

    public void LoadProgress(PlayerProgress progress)
    {
      Vector3 savedPosition = progress.Position.AsUnityVector();
      transform.position = savedPosition.AddY();
    }

    
    
    
    
    public void ChangeDirectionTo(MovingDirection direction)
    {
      Direction = direction;
      
      if(Direction == MovingDirection.Right)
        transform.localScale = new Vector3(1f, 1f, 1f);
      
      if (Direction == MovingDirection.Left) 
        transform.localScale = new Vector3(-1f, 1f, 1f);
      
    }
  }
}