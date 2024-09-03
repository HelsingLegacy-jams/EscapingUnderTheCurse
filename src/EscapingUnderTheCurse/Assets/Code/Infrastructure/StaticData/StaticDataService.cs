using Code.Gameplay.Configs;
using Code.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;

namespace Code.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService, IStaticDataBinder
  {
    private readonly IAssets _assets;

    public StaticDataService(IAssets assets) => 
      _assets = assets;

    public HeroStats HeroConfig { get; private set; }

    public void SetHeroStats() => 
      HeroConfig = _assets.LoadHeroConfig(AssetPath.HeroConfig);
  }
}