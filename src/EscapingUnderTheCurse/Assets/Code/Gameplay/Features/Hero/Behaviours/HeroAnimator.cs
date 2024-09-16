using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
  public class HeroAnimator : MonoBehaviour
  {
    [SerializeField] private Animator _animator;

    private static readonly int VelocityAxisXHash = Animator.StringToHash("VelocityAxisX");
    private static readonly int VelocityAxisYHash = Animator.StringToHash("VelocityAxisY");
    private static readonly int MovingHash = Animator.StringToHash("isMoving");
    private static readonly int JumpingHash = Animator.StringToHash("isJumping");
    private static readonly int GroundedHash = Animator.StringToHash("isGrounded");
    private static readonly int JumpingUpHash = Animator.StringToHash("isJumpingUp");
    private static readonly int FallingDownHash = Animator.StringToHash("isFallingDown");
    
    public void Moving(bool isMoving) => 
      _animator.SetBool(MovingHash, isMoving);

    public void Jumping(bool isJumping)
    {
      _animator.SetBool(JumpingHash, isJumping);
      _animator.SetBool(GroundedHash, !isJumping);
    }

    public void JumpingUp(bool isJumpingUp) => 
      _animator.SetBool(JumpingUpHash, isJumpingUp);
    
    public void FallingDown(bool isFalling) => 
      _animator.SetBool(FallingDownHash, isFalling);

    public void VelocityAxisX(float velocityX) => 
      _animator.SetFloat(VelocityAxisXHash, velocityX);
    
    public void VelocityAxisY(float velocityY) => 
      _animator.SetFloat(VelocityAxisYHash, velocityY);

    public void PlayIdle()
    {
      _animator.SetBool(MovingHash, false);
      
    }
  }
}