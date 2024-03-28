using CodeBase.Infrastructure.Countdown;
using CodeBase.Infrastructure.DIContainer;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Injector;
using CodeBase.Infrastructure.Scene;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;
      
      RegisterServices();
    }

    public void Enter()
    {
      _sceneLoader.Load("Initial", EnterLoadLevel);
    }

    private void RegisterServices()
    {
      _services.RegisterSingle<ITimer>(new TimerService());
      _services.RegisterSingle<IInjectionService>(new InjectionService(_services.Single<ITimer>()));
      _services.RegisterSingle<IAssets>(new AssetProvider());
      _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
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