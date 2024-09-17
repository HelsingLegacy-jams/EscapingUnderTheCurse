using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
  public class HeroGrounder : MonoBehaviour, IHeroGrounder
  {
    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Ground"))
        IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Ground"))
        IsGrounded = false;
    }
  }
}