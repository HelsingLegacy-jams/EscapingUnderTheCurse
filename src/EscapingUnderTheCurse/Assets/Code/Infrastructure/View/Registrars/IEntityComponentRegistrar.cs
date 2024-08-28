namespace Code.Infrastructure.View.Registrars
{
  public interface IEntityComponentRegistrar
  {
    void UnregisterComponent();
    void RegisterComponent();
  }
}