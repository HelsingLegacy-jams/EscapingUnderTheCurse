using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
  public class HeroAnimatorRegistrar : EntityComponentRegistrar
  {
    public HeroAnimator Animator;
    
    public override void RegisterComponent() => 
      Entity.AddHeroAnimator(Animator);

    public override void UnregisterComponent()
    {
      if (Entity.hasHeroAnimator)
        Entity.RemoveHeroAnimator();
    }
  }
}