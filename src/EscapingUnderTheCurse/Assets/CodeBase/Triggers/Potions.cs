using UnityEngine;

namespace CodeBase.Triggers
{
  public class Potions : MonoBehaviour
  {
    public CurseType Curse;

    private void OnTriggerEnter2D(Collider2D other)
    {
      // other.GetComponent<HeroMove>().SetCurse(Curse);
    }
  }
}