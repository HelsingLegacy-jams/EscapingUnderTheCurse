using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class HeroAnimationControllingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;

    public HeroAnimationControllingSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.HeroAnimator));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      {
        if (hero.isAttacking && hero.HeroGrounder.IsGrounded)
        {
          hero.HeroAnimator.SetAttack(hero.isAttacking);
          hero.HeroAnimator.PlayAttack(hero.AttackType);
          hero.isAttacking = false;
          hero.isProcessingAttack = true;
        }
        
        else if (hero.isMoving && hero.HeroGrounder.IsGrounded && !hero.isProcessingAttack)
        {
          hero.HeroAnimator.Moving(hero.isMoving);
          hero.HeroAnimator.Grounded(hero.HeroGrounder.IsGrounded);
          hero.HeroAnimator.VelocityAxisX(hero.Rigidbody2D.velocity.x);
        }
        
        else if (!hero.HeroGrounder.IsGrounded && !hero.isProcessingAttack)
        {
          float velocityY = hero.Rigidbody2D.velocity.y;

          hero.HeroAnimator.VelocityAxisY(velocityY);

          if (velocityY > 0.05f)
            hero.HeroAnimator.JumpingUp(true);
          else if (velocityY < 0.05f)
          {
            hero.HeroAnimator.JumpingUp(true);
            hero.HeroAnimator.FallingDown(true);
          }
        }
        
        else if(hero.HeroGrounder.IsGrounded && !hero.isMoving && !hero.isProcessingAttack)
          hero.HeroAnimator.PlayIdle();
      }
    }
  }
}