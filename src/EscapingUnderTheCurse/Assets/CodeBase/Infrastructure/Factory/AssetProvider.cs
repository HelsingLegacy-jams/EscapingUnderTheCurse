using Code.Gameplay.Configs;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public class AssetProvider : IAssets
  {
    public GameObject Instantiate(string heroHero, Vector3 at)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string heroHero)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab);
    }

    public T LoadAsset<T>(string entityViewPath) where T : Component => 
      Resources.Load<T>(entityViewPath);
    
    public HeroStats LoadHeroConfig(string configPath) => 
      Resources.Load<HeroStats>(configPath);
  }
}