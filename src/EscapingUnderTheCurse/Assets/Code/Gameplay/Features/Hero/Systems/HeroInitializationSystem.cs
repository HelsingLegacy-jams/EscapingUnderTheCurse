using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Hero.Provider;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class HeroInitializationSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly IHeroProvider _heroProvider;

    public HeroInitializationSystem(IHeroFactory heroFactory, IHeroProvider heroProvider)
    {
      _heroFactory = heroFactory;
      _heroProvider = heroProvider;
    }

    public void Initialize()
    {
      GameEntity hero = _heroFactory.CreateHero(Vector2.zero);
      
      _heroProvider.SetHero(hero);
    }
  }
}