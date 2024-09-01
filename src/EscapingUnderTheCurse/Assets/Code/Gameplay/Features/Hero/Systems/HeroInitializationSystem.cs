using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Hero.Provider;
using Code.Gameplay.Features.Levels;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class HeroInitializationSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly IHeroProvider _heroProvider;
    private readonly ILevelDataProvider _levelDataProvider;

    public HeroInitializationSystem(IHeroFactory heroFactory, IHeroProvider heroProvider, ILevelDataProvider levelDataProvider)
    {
      _heroFactory = heroFactory;
      _heroProvider = heroProvider;
      _levelDataProvider = levelDataProvider;
    }

    public void Initialize()
    {
      GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
      
      _heroProvider.SetHero(hero);
    }
  }
}