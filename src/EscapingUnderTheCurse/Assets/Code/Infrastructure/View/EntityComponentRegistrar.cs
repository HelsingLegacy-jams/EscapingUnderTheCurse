namespace Code.Infrastructure.View
{
  public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
  {
    public abstract void UnregisterComponent();
    public abstract void RegisterComponent();
  }
}