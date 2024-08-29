using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class HeroMoveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _hero;
    private readonly IUnityTimeService _time;
    private readonly List<GameEntity> _buffer = new (4);

    public HeroMoveSystem(GameContext game, IUnityTimeService time)
    {
      _time = time;
      _hero = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Speed,
          GameMatcher.DirectionModifier,
          GameMatcher.Moving,
          GameMatcher.MovementAvailable));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _hero.GetEntities(_buffer)) 
        Move(hero);
    }

    private void Move(GameEntity hero) => 
      hero.Rigidbody2D.velocity = Velocity(hero, hero.DirectionModifier);

    private Vector2 Velocity(GameEntity hero, int directionModifier) => 
      new(directionModifier * hero.Speed * _time.DeltaTime, hero.Rigidbody2D.velocity.y);
  }
}