using UnityEngine;

namespace Code.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntity(GameEntity entity, Vector2 at);
  }
}