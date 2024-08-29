namespace Code.Gameplay.Features.Hero.Provider
{
  public interface IHeroProvider
  {
    GameEntity Hero { get; }
    void SetHero(GameEntity hero);
  }
}