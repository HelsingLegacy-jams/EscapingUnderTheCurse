namespace Code.Gameplay.Features.Hero.Provider
{
  public class HeroProvider : IHeroProvider
  {
    private GameEntity _hero;
    public GameEntity Hero => _hero;

    public void SetHero(GameEntity hero) => _hero = hero;
  }
}