using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public class GameFactory
  {
    public GameObject CreateHero(GameObject initialPoint) => 
      Instantiate(AssetPath.Hero, at: initialPoint.transform.position);

    public GameObject CreateHud() => 
      Instantiate(AssetPath.Hud);

    public GameObject Instantiate(string heroHero, Vector3 at)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string heroHero)
    {
      var heroPrefab = Resources.Load<GameObject>(heroHero);
      return Object.Instantiate(heroPrefab);
    }
  }
}