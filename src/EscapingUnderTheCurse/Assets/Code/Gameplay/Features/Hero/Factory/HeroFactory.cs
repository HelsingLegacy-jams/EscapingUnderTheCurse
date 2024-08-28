using Code.Common;
using Code.Common.Entity;
using Code.Gameplay.Features.Movement;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    public GameEntity CreateHero(Vector2 at)
    {
      return CreateEntity.Empty()
          .AddId(1)
          .AddViewPath("Hero/Hero")
          .AddWorldPosition(at)
          .AddDirection(MovingDirection.Right)
          .With(x=>x.isHero = true)
          .With(x=>x.isMovementAvailable = true)
        ;
    }
  }
}