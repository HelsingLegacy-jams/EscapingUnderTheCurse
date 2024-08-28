using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
  public class BindEntityViewSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private IEntityViewFactory _entityViewFactory;

    public BindEntityViewSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ViewPath,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        _entityViewFactory.CreateViewForEntity(entity, at: entity.WorldPosition);
      }
    }
  }
}