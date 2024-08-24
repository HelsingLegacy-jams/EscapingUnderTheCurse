using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Injector;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.UI;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";

    private CameraFollow _camera;

    private readonly GameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IInjectionService _injector;
    private readonly IPersistentProgressService _progressService;

    public LoadLevelState(GameStateMachine stateMachine, LoadingCurtain curtain, 
      IGameFactory gameFactory, IInjectionService injector, IPersistentProgressService progressService)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _gameFactory = gameFactory;
      _injector = injector;
      _progressService = progressService;
    }

    public void Enter()
    {
      InitWorld();
    }

    public void Exit()
    {
      _curtain.Hide();
    }

    private void InitWorld()
    {
      var initialPoint = GameObject.FindWithTag(InitialPointTag);
      
      GameObject hero = _gameFactory.CreateHero(initialPoint);
      hero.GetComponent<ISavedProgress>().LoadProgress(_progressService.Progress);
      
      _gameFactory.CreateHud();

      _camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
      _camera.Follow(hero);

      _injector.InjectTimer();
      
      _stateMachine.Enter<GameLoopState>();
    }
  }
}