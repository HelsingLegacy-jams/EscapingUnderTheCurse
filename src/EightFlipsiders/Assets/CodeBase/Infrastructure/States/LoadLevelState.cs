using CodeBase.Infrastructure.Services.Scene;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(SceneLoader sceneLoader)
    {
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      _sceneLoader.Load("Main", OnLoaded);
    }

    private void OnLoaded()
    {
      var initialPoint = GameObject.FindWithTag(InitialPointTag);
      
      GameObject hero = Instantiate("Hero/Hero", at: initialPoint.transform.position);
      Instantiate("Hud/Hud");
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

    public void Exit()
    {
    }
  }
}