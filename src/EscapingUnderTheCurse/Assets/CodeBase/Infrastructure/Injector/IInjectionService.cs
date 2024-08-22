using CodeBase.Infrastructure.DIContainer;

namespace CodeBase.Infrastructure.Injector
{
  public interface IInjectionService : IService
  {
    void InjectTimer();
  }
}