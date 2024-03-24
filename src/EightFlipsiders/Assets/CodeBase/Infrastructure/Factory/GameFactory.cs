using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssets _assets;

    public GameFactory(IAssets assets)
    {
      _assets = assets;
    }

    public GameObject CreateHero(GameObject initialPoint) =>
      _assets.Instantiate(AssetPath.Hero, at: initialPoint.transform.position);

    public GameObject CreateHud() => 
      _assets.Instantiate(AssetPath.Hud);
  }
}