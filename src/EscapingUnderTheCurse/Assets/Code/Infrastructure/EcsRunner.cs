using Code.Gameplay.Features;
using Code.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
  public class EcsRunner : MonoBehaviour
  {
    private ISystemFactory _systems;
    private BattleFeature _battleFeature;

    [Inject]
    public void Construct(ISystemFactory systems) => 
      _systems = systems;

    private void Start()
    {
      _battleFeature = _systems.Create<BattleFeature>();
      _battleFeature.Initialize();
    }

    private void Update()
    {
      _battleFeature.Execute();
      _battleFeature.Cleanup();
    }

    private void OnDestroy()
    {
      _battleFeature.TearDown();
    }
  }
}