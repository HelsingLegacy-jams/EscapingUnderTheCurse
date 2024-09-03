using Code.Gameplay.Configs;
using CodeBase.Infrastructure.DIContainer;

using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IAssets : IService
  {
    GameObject Instantiate(string heroHero, Vector3 at);
    GameObject Instantiate(string heroHero);
    T LoadAsset<T>(string entityViewPath) where T : Component;
    HeroStats LoadHeroConfig(string configPath);
  }
}