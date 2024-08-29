using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Factory;

namespace Code.Gameplay.Features.Hero
{
  public class HeroFeature : Feature
  {
    public HeroFeature(ISystemFactory systems)
    {
      Add(systems.Create<HeroInitializationSystem>());
      
      Add(systems.Create<HeroDirectionProviderSystem>());
      Add(systems.Create<HeroTurnToDirectionSideSystem>());
    }
  }
}