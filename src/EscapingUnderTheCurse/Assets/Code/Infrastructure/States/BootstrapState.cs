using Code.Infrastructure.Scenes;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Code.UI;
using CodeBase.UI;

namespace Code.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly IGameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;
    private readonly IStaticDataBinder _staticData;

    public BootstrapState(ISceneLoader sceneLoader, IGameStateMachine stateMachine, LoadingCurtain curtain, IStaticDataBinder staticData)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _staticData = staticData;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      _curtain.Show();
      _staticData.SetHeroStats();
      _sceneLoader.Load("Initial", EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void EnterLoadLevel() => 
      _stateMachine.Enter<LoadProgressState>();
  }
}