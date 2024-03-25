using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.DIContainer;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Injector;
using CodeBase.Infrastructure.Scene;
using CodeBase.UI;

namespace CodeBase.Infrastructure.States
{
  public class GameStateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices services)
    {
      _states = new Dictionary<Type, IState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
        [typeof(LoadLevelState)] = new LoadLevelState
        (
          this, sceneLoader, curtain, services.Single<IGameFactory>(), services.Single<IInjectionService>()
        ),
        [typeof(GameLoopState)] = new GameLoopState(this),
        
      };
    }

    public void Enter<TState>() where TState : IState
    {
      _activeState?.Exit();
      
      IState state = _states[typeof(TState)];
      _activeState = state;
      
      state.Enter();
    }
  }
}