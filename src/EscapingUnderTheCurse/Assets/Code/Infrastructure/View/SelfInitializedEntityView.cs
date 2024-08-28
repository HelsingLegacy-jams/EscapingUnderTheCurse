using Code.Common.Entity;
using Code.Gameplay.Features.Movement;
using UnityEngine;

namespace Code.Infrastructure.View
{
  public class SelfInitializedEntityView : MonoBehaviour
  {
    public EntityBehaviour EntityView;
    
    private void Start()
    {
      GameEntity entity = CreateEntity.Empty()
          .AddId(55)
          .AddWorldPosition(Vector2.zero)
          .AddSpeed(5)
          .AddDirection(MovingDirection.Right)
        ;
      
      EntityView.SetEntity(entity);
    }
  }
}