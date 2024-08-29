using Code.Infrastructure.States.StateMachine;
using Code.UI;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.PersistentProgress;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";

    private CameraFollow _camera;

    private readonly IGameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;

    public LoadLevelState(IGameStateMachine stateMachine, LoadingCurtain curtain, 
      IGameFactory gameFactory, IPersistentProgressService progressService)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _gameFactory = gameFactory;
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
      GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
      
      // GameObject hero = _gameFactory.CreateHero(initialPoint);
      // hero.GetComponent<ISavedProgress>().LoadProgress(_progressService.Progress);
      
      // _gameFactory.CreateHud();

      // _camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
      // _camera.Follow(hero);

      _stateMachine.Enter<GameLoopState>();
    }
  }
}