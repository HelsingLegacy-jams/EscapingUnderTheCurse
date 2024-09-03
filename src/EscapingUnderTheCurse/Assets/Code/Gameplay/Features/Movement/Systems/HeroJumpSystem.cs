using Code.Common;
using Code.Gameplay.Common;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class HeroJumpSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _grounds;

    public HeroJumpSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Rigidbody2D,
          GameMatcher.JumpingForce,
          GameMatcher.Jumping));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      {
        if (hero.Rigidbody2D.IsTouchingLayers(CollisionLayer.Ground.AsMask()))
          hero.Rigidbody2D.velocity = new Vector2(hero.Rigidbody2D.velocity.x, hero.JumpingForce);
      }
    }
  }
}