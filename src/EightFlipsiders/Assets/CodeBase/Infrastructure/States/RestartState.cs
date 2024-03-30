using CodeBase.Infrastructure.Scene;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class RestartState : IState
  {
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;

    public RestartState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
    }

    public void Enter()
    {
      _curtain.Show();
      
      _sceneLoader.Load("Initial", OnLoaded);
    }

    public void Exit() => 
      ClearPrefs();

    private static void ClearPrefs()
    {
      PlayerPrefs.DeleteAll();
      PlayerPrefs.Save();
    }

    private void OnLoaded() => 
      _stateMachine.Enter<LoadProgressState>();
  }
}