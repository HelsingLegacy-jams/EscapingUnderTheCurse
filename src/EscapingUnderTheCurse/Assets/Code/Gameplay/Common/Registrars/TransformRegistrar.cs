using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Registrars
{
  public class TransformRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponent() => 
      Entity.AddTransform(transform);

    public override void UnregisterComponent()
    {
      if(Entity.hasTransform)
        Entity.RemoveTransform();
    }
  }
}