using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class HeroMoveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _hero;

    public HeroMoveSystem(GameContext game)
    {
      _hero = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _hero)
      {
        
      }
    }
  }
}