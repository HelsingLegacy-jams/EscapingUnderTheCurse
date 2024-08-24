using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using CodeBase.Infrastructure.DIContainer;
using CodeBase.UI;

namespace CodeBase.Infrastructure.Bootstrap
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
    }
  }
}