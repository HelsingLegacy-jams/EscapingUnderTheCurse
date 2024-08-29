using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features
{
  public class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityFeature>());
      
      Add(systems.Create<HeroFeature>());
      Add(systems.Create<MovementFeature>());
    }
  }
}