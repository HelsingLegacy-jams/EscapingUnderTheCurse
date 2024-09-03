using Code.Gameplay.Features.Movement;
using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroMove : MonoBehaviour, ISavedProgress
  {
    public MovingDirection Direction;

    private void Awake()
    {
      GetComponent<Rigidbody2D>();
    }
    
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