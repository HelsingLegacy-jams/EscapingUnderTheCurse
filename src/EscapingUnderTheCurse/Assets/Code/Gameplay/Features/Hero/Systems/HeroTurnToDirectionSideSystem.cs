using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class HeroTurnToDirectionSideSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _hero;
    private readonly List<GameEntity> _buffer = new (4);

    public HeroTurnToDirectionSideSystem(GameContext game)
    {
      _hero = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero, 
          GameMatcher.Transform, 
          GameMatcher.DirectionModifier));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _hero.GetEntities(_buffer))
      {
        if(Mathf.RoundToInt(hero.Transform.localScale.x) == hero.DirectionModifier)
          return;
        
        hero.Transform.localScale = new Vector3(hero.DirectionModifier, hero.Transform.localScale.y, hero.Transform.localScale.z);
      }
    }
  }
}