namespace Code.Infrastructure.States
{
  public interface IStateFactory
  {
    TState Create<TState>() where TState : IState;
    TState Create<TState>(params object[] objects) where TState : IState;
  }
}