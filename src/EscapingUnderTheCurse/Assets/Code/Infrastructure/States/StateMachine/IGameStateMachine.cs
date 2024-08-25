namespace Code.Infrastructure.States.StateMachine
{
  public interface IGameStateMachine
  {
    void Enter<TState>() where TState : IState;
  }
}