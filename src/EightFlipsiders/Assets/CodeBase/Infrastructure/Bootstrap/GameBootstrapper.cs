using CodeBase.Infrastructure.Services.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Bootstrap
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(this);
      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(gameObject);
    }
  }
}
