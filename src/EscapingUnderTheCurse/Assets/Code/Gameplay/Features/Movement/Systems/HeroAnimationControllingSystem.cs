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
        
        if (hero.isMoving && hero.HeroGrounder.IsGrounded)
        {
          hero.HeroAnimator.Moving(hero.isMoving);
          hero.HeroAnimator.Grounded(hero.HeroGrounder.IsGrounded);
          hero.HeroAnimator.VelocityAxisX(hero.Rigidbody2D.velocity.x);
        }
        
        if (!hero.HeroGrounder.IsGrounded)
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
        
        if(hero.HeroGrounder.IsGrounded && !hero.isMoving)
          hero.HeroAnimator.PlayIdle();
      }
    }
  }
}