using Code.Infrastructure.Scenes;
using Code.Infrastructure.States.StateMachine;
using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly ISceneLoader _sceneLoader;

    public LoadProgressState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IPersistentProgressService progressService, 
      ISaveLoadService saveLoadService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }


    public void Enter()
    {
      _sceneLoader.Load("Main", OnLoaded);
    }

    private void OnLoaded()
    {
      LoadProgressOrInitNew();
      _stateMachine.Enter<LoadLevelState>();
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew() => 
      _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

    private PlayerProgress NewProgress()
    {
      Vector3 position = GameObject.FindWithTag("InitialPoint").transform.position;

      return new PlayerProgress(position.AsVector3Data());
    }
  }
}