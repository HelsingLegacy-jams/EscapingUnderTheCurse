namespace Code.Infrastructure.States
{
  public interface IGameStateMachine
  {
    void Enter<TState>() where TState : IState;
  }
}