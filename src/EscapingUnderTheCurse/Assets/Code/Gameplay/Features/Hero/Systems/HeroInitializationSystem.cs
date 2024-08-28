using Code.Gameplay.Features.Hero.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class HeroInitializationSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;

    public HeroInitializationSystem(IHeroFactory heroFactory)
    {
      _heroFactory = heroFactory;
    }

    public void Initialize()
    {
      _heroFactory.CreateHero(Vector2.zero);
    }
  }
}