using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
  public class HeroGrounderRegistrar : EntityComponentRegistrar
  {
    public HeroGrounder Grounder;

    public override void RegisterComponent()
    {
      if (Grounder is IHeroGrounder grounder)
        Entity.AddHeroGrounder(grounder);
    }

    public override void UnregisterComponent()
    {
      if (Entity.hasHeroGrounder)
        Entity.RemoveHeroGrounder();
    }
  }
}