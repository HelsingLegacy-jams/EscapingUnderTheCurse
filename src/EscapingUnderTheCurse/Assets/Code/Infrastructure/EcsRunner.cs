using Code.Gameplay.Features;
using Code.Infrastructure.Factory;
using UnityEngine;

namespace Code.Infrastructure
{
  public class EcsRunner : MonoBehaviour
  {
    private ISystemFactory systems;
    private BattleFeature _battleFeature;
    
    private void Start()
    {
      _battleFeature = systems.Create<BattleFeature>();
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