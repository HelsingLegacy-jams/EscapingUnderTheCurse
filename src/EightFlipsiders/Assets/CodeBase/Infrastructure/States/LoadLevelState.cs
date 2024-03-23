using CodeBase.Infrastructure.Scene;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";
    
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly LoadingCurtain _curtain;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
    {
      _sceneLoader = sceneLoader;
      _stateMachine = stateMachine;
      _curtain = curtain;
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
      
      GameObject hero = CreateHero(initialPoint);
      CreateHud();
      
      _stateMachine.Enter<GameLoopState>();
    }

    public GameObject CreateHud()
    {
      return Instantiate("Hud/Hud");
    }

    public GameObject CreateHero(GameObject initialPoint)
    {
      return Instantiate("Hero/Hero", at: initialPoint.transform.position);
    }

    private GameObject Instantiate(string heroHero)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab);
    }

    public GameObject Instantiate(string heroHero, Vector3 at)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab, at, Quaternion.identity);
    }
  }
}