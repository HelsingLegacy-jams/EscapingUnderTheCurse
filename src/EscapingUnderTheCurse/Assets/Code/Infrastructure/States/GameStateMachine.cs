using System;
using System.Collections.Generic;

namespace Code.Infrastructure.States
{
  public class GameStateMachine : IGameStateMachine, IStatesInitializer
  {
    private readonly IStateFactory _factory;
    private readonly Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(IStateFactory factory)
    {
      _factory = factory;
    }

    public void InitStates()
    {
      _states.Add(typeof(BootstrapState), _factory.Create<BootstrapState>(this));
      _states.Add(typeof(RestartState), _factory.Create<RestartState>(this));
      _states.Add(typeof(LoadProgressState), _factory.Create<LoadProgressState>(this));
      _states.Add(typeof(LoadLevelState), _factory.Create<LoadLevelState>(this));
      _states.Add(typeof(GameLoopState), _factory.Create<GameLoopState>(this));
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