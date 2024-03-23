using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Scene;
using CodeBase.UI;

namespace CodeBase.Infrastructure.Services.States
{
  public class GameStateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
    {
      _states = new Dictionary<Type, IState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
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