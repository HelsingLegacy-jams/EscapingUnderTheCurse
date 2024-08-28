using Code.Common.Entity;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    public GameEntity CreateHero(Vector2 at)
    {
      return CreateEntity.Empty()
          .AddViewPath("Hero/Hero")
          .AddWorldPosition(at)
        ;
    }
  }
}