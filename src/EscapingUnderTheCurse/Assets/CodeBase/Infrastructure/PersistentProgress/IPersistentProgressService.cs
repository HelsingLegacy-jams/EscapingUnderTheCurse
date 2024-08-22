using CodeBase.Data;
using CodeBase.Infrastructure.DIContainer;

namespace CodeBase.Infrastructure.PersistentProgress
{
  public interface IPersistentProgressService : IService
  {
    PlayerProgress Progress { get; set; }
  }
}