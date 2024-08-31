﻿using System.Collections.Generic;
using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
  public class BindEntityViewFromPrefabSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(64);

    public BindEntityViewFromPrefabSystem(GameContext game, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ViewPrefab,
          GameMatcher.WorldPosition)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        _entityViewFactory.CreateViewForEntityWithPath(entity, at: entity.WorldPosition);
      }
    }
  }
}