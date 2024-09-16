using Code.Common;
using Code.Gameplay.Common;
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
        if (hero.isMoving)
        {
          hero.HeroAnimator.Moving(hero.isMoving);
          hero.HeroAnimator.VelocityAxisX(hero.Rigidbody2D.velocity.x);
        }
        else if (!hero.Rigidbody2D.IsTouchingLayers(CollisionLayer.Ground.AsMask()))
        {
          float velocityY = hero.Rigidbody2D.velocity.y;
          hero.HeroAnimator.VelocityAxisY(velocityY);
          if(velocityY > 0.05)
            hero.HeroAnimator.JumpingUp(true);
          else
          {
            hero.HeroAnimator.JumpingUp(true);
            hero.HeroAnimator.FallingDown(true);
          }
        }
        else
          hero.HeroAnimator.PlayIdle();
      }
    }
  }
}