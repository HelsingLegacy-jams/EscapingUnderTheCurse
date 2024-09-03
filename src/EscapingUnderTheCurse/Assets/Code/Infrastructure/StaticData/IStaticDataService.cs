using Code.Gameplay.Configs;

namespace Code.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    HeroStats HeroConfig { get; }
  }
}