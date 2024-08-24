using Code.Infrastructure.Scenes;
using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using CodeBase.UI;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly SceneLoader _sceneLoader;

    public LoadProgressState(GameStateMachine stateMachine, SceneLoader sceneLoader,
      LoadingCurtain curtain, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }

    private readonly LoadingCurtain _curtain;


    public void Enter()
    {
      _curtain.Show();
      
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