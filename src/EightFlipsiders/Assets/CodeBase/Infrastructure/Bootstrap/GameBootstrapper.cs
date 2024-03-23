using UnityEngine;

namespace CodeBase.Infrastructure.Bootstrap
{
  public class GameBootstrapper : MonoBehaviour
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game();
      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(gameObject);
    }
  }
}
