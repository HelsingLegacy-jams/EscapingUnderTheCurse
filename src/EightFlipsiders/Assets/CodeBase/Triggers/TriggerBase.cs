using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Triggers
{
  public class TriggerBase : MonoBehaviour
  {
    public MovingDirection Direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
      other.GetComponent<HeroMove>().Direction = Direction;
    }
  }
}