using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class HeroMovementAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;

    public HeroMovementAnimationSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Moving));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      {
        // hero.HeroAnimator.Moving(hero.isMoving);
        // hero.HeroAnimator.Velocity(hero.Rigidbody2D.velocity.x);
      }
    }
  }
}