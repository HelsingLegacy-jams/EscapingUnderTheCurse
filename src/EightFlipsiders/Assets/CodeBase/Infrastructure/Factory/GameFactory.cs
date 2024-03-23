using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public class GameFactory
  {
    private readonly AssetProvider _assetProvider;

    public GameFactory(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public GameObject CreateHero(GameObject initialPoint) =>
      _assetProvider.Instantiate(AssetPath.Hero, at: initialPoint.transform.position);

    public GameObject CreateHud() => 
      _assetProvider.Instantiate(AssetPath.Hud);
  }
}