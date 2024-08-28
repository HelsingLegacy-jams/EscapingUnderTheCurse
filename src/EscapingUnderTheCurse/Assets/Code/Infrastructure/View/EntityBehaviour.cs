﻿using UnityEngine;

namespace Code.Infrastructure.View
{
  public class EntityBehaviour : MonoBehaviour, IEntityView
  {
    private GameEntity _entity;

    public GameEntity Entity => _entity;

    public void SetEntity(GameEntity entity)
    {
      _entity = entity;
      
      _entity.Retain(this);

      RegisterComponents();
    }

    public void ReleaseEntity()
    {
      UnregisterComponents();
      
      _entity.Release(this);
      _entity = null;
    }

    private void RegisterComponents()
    {
      foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.RegisterComponent();
    }

    private void UnregisterComponents()
    {
      foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.UnregisterComponent();
    }
  }
}