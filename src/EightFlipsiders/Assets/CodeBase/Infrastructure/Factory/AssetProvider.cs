using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public class AssetProvider
  {
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