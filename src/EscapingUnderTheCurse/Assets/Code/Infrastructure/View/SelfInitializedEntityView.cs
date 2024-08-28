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
      var entity = CreateEntity
          .Empty()
          .AddView(EntityView)
          .AddSpeed(5)
          .AddDirection(MovingDirection.Right)
        ;
      
      EntityView.SetEntity(entity);
    }
  }
}