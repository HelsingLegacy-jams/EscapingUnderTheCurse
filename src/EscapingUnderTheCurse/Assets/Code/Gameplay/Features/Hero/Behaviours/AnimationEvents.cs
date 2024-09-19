using Code.Gameplay.Features.Hero.Provider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Hero.Behaviours
{
  public class AnimationEvents : MonoBehaviour
  {
    private GameEntity _hero;

    [Inject]
    public void Construct(IHeroProvider provider) => 
      _hero = provider.Hero;

    public void OnSwingEnd() => 
      _hero.HeroAnimator.SetAttack(false);

    public void OnPerformingSwing()
    {
    }

    public void OnPerformingCompletion()
    {
    }
  }
}