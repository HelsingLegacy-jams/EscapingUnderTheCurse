using CodeBase.Infrastructure.Services.Scene;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly GameStateMachine _stateMachine;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
    {
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
      _curtain.Show();
      _sceneLoader.Load("Main", OnLoaded);
    }

    public void Exit() => 
      _curtain.Hide();

    private void OnLoaded()
    {
      var initialPoint = GameObject.FindWithTag(InitialPointTag);
      
      GameObject hero = Instantiate("Hero/Hero", at: initialPoint.transform.position);
      Instantiate("Hud/Hud");
      
      _stateMachine.Enter<GameLoopState>();
    }

    private static GameObject Instantiate(string heroHero)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab);
    }

    private static GameObject Instantiate(string heroHero, Vector3 at)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab, at, Quaternion.identity);
    }
  }
}