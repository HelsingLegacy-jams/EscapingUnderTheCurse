using Code.Common;
using Code.Common.Entity;
using Code.Gameplay.Configs;
using Code.Gameplay.Features.Movement;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly IStaticDataService _staticData;

    public HeroFactory(IStaticDataService staticData)
    {
      _staticData = staticData;
    }

    public GameEntity CreateHero(Vector2 at)
    {
      HeroStats config = _staticData.HeroConfig;
      
      return CreateEntity.Empty()
          .AddId(1)
          .AddViewPath("Hero/Hero")
          .AddWorldPosition(at)
          .AddSpeed(config.Speed)
          .AddJumpingForce(config.JumpingForce)
          .AddDirection(MovingDirection.Right)
          .With(x=>x.isHero = true)
          .With(x=>x.isMovementAvailable = true)
        ;
    }
  }
}