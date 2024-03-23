using CodeBase.Infrastructure.Scene;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      _sceneLoader.Load("Initial", EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void EnterLoadLevel()
    {
      _stateMachine.Enter<LoadLevelState>();
    }
  }
}