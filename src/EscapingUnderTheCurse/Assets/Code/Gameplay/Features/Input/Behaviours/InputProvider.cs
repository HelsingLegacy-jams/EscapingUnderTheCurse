using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Hero.Provider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Input.Behaviours
{
  public class InputProvider : MonoBehaviour
  {
    private IHeroProvider _heroProvider;

    [Inject]
    public void Construct(IHeroProvider provider) =>
      _heroProvider = provider;

    private void Update()
    {
      _heroProvider.Hero.isMoving = UnityEngine.Input.GetKey(KeyCode.W);

      _heroProvider.Hero.isJumping = UnityEngine.Input.GetKey(KeyCode.Space);

      if (UnityEngine.Input.GetKey(KeyCode.A) && !_heroProvider.Hero.isAttacking)
      {
        _heroProvider.Hero.isAttacking = true;
        _heroProvider.Hero.ReplaceAttackType(AttackTypeID.Swing);
      }
    }
  }
}