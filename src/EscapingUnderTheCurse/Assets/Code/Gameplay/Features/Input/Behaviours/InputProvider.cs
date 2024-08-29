using Code.Gameplay.Features.Hero.Provider;
using Code.Infrastructure.View;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Input.Behaviours
{
  public class InputProvider : MonoBehaviour
  {
    public EntityBehaviour EntityBehaviour;
    private IHeroProvider _heroProvider;

    [Inject]
    public void Construct(IHeroProvider provider) =>
      _heroProvider = provider;

    private void Update()
    {
      EntityBehaviour.Entity.isMoving = UnityEngine.Input.GetKey(KeyCode.W);
    }
  }
}