using CodeBase.Data;
using CodeBase.Infrastructure.DIContainer;

namespace CodeBase.Infrastructure.SaveLoad
{
  public interface ISaveLoadService : IService
  {
    void SaveProgress();
    PlayerProgress LoadProgress();
  }
}