namespace Code.Infrastructure.View
{
  public interface IEntityComponentRegistrar
  {
    void UnregisterComponent();
    void RegisterComponent();
  }
}