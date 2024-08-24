using System;
using System.Collections.Generic;
using Code.Infrastructure.Scenes;
using CodeBase.Infrastructure.DIContainer;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Injector;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using CodeBase.UI;

namespace Code.Infrastructure.States
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
        [typeof(RestartState)] = new RestartState(this, sceneLoader, curtain),

        [typeof(LoadProgressState)] = new LoadProgressState
        (
          this, sceneLoader, curtain, services.Single<IPersistentProgressService>(),
          services.Single<ISaveLoadService>()
        ),
        [typeof(LoadLevelState)] = new LoadLevelState
        (
          this, curtain, services.Single<IGameFactory>(), services.Single<IInjectionService>(), 
          services.Single<IPersistentProgressService>()
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