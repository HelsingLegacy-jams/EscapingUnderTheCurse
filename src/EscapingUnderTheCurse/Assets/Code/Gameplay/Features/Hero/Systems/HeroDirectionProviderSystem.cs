using System.Collections.Generic;
using Code.Gameplay.Features.Movement;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class HeroDirectionProviderSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _hero;
    private readonly List<GameEntity> _buffer = new (4);

    public HeroDirectionProviderSystem(GameContext game)
    {
      _hero = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Direction));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _hero.GetEntities(_buffer))
      {
        if (hero.Direction == MovingDirection.Right) 
          hero.ReplaceDirectionModifier(1);

        if (hero.Direction == MovingDirection.Left) 
          hero.ReplaceDirectionModifier(-1);
      }
    }
  }
}