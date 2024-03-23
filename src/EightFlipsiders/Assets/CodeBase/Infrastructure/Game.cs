using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.Services.Scene;
using CodeBase.Infrastructure.States;
using CodeBase.UI;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
    }
  }
}