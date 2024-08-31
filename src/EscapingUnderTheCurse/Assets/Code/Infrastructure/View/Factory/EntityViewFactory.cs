using CodeBase.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private IAssets _assets;
    private IInstantiator _instantiator;

    public EntityViewFactory(IInstantiator instantiator, IAssets assets)
    {
      _instantiator = instantiator;
      _assets = assets;
    }

    public EntityBehaviour CreateViewForEntityWithPath(GameEntity entity, Vector2 at)
    {
      EntityBehaviour viewPrefab = _assets.LoadAsset<EntityBehaviour>(entity.ViewPath);
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        viewPrefab,
        position: at,
        Quaternion.identity,
        parentTransform: null
      );
      
      view.SetEntity(entity);

      return view;
    }
    
    public EntityBehaviour CreateViewForEntityWithPrefab(GameEntity entity, Vector2 at)
    {
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        entity.ViewPrefab,
        position: at,
        Quaternion.identity,
        parentTransform: null
      );
      
      view.SetEntity(entity);

      return view;
    }
  }
}