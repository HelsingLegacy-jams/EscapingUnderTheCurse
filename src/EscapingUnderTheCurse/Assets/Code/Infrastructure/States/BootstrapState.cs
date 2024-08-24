using Code.Infrastructure.Scenes;

namespace Code.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;

    public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
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
      _stateMachine.Enter<LoadProgressState>();
    }
  }
}