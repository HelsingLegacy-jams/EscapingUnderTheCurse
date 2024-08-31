using UnityEngine;

namespace Code.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntityWithPath(GameEntity entity, Vector2 at);
    EntityBehaviour CreateViewForEntityWithPrefab(GameEntity entity, Vector2 at);
  }
}