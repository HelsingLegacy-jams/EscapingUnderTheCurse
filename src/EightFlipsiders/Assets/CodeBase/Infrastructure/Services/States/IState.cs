namespace CodeBase.Infrastructure.Services.States
{
  public interface IState
  {
    void Enter();
    void Exit();
  }
}