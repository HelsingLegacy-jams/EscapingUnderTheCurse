using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Scene;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";

    private CameraFollow _camera;
    
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    
    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, 
      IGameFactory gameFactory)
    {
      _sceneLoader = sceneLoader;
      _stateMachine = stateMachine;
      _curtain = curtain;
      _gameFactory = gameFactory;
    }

    public void Enter()
    {
      _curtain.Show();
      _sceneLoader.Load("Main", OnLoaded);
    }

    public void Exit()
    {
      _curtain.Hide();
    }

    private void OnLoaded()
    {
      var initialPoint = GameObject.FindWithTag(InitialPointTag);
      
      GameObject hero = _gameFactory.CreateHero(initialPoint);
      _gameFactory.CreateHud();

      _camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
      _camera.Follow(hero);
      
      _stateMachine.Enter<GameLoopState>();
    }
  }
}