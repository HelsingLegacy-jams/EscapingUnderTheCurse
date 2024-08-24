using Code.Infrastructure.States;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.Bootstrap
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain CurtainPrefab;
    
    private Game _game;
    private bool _isConstructed;

    private void Awake()
    {
      _game = new Game(this, Instantiate(CurtainPrefab));

      _game.StateMachine.Enter<BootstrapState>();
      
      DontDestroyOnLoad(gameObject);
    }

    public GameStateMachine StateMachine() => 
      _game.StateMachine;
  }
}
