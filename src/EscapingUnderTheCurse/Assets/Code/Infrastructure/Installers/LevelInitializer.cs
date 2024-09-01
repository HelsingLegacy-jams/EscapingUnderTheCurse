using Code.Gameplay.Features.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
    public Transform InitPoint;
    private ILevelDataBinder _levelDataBinder;

    [Inject]
    public void Construct(ILevelDataBinder levelDataBinder) => 
      _levelDataBinder = levelDataBinder;

    public void Initialize()
    {
      _levelDataBinder.SetHeroInitPoint(InitPoint.position);
    }
  }
}