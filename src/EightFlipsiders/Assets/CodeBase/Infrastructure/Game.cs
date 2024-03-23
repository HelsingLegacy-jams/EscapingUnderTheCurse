using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.Services.Scene;
using CodeBase.Infrastructure.Services.States;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
    }
  }
}