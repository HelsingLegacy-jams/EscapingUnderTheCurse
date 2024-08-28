using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
  public class RigidBodyRegistrar : EntityComponentRegistrar
  {
    public Rigidbody2D Rigidbody;
    
    public override void RegisterComponent()
    {
      Entity.AddRigidbody2D(Rigidbody);
    }

    public override void UnregisterComponent()
    {
      if (Entity.hasRigidbody2D)
        Entity.RemoveRigidbody2D();
    }
  }
}