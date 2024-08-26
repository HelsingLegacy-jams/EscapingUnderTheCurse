using Code.Common.Entity;
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
        ;
      
      EntityView.SetEntity(entity);
    }
  }
}