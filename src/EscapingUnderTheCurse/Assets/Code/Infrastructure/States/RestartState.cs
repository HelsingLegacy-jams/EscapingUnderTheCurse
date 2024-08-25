using Code.Infrastructure.Scenes;
using Code.Infrastructure.States.StateMachine;
using Code.UI;
using CodeBase.UI;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class RestartState : IState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;

    public RestartState(GameStateMachine stateMachine, ISceneLoader sceneLoader, LoadingCurtain curtain)
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