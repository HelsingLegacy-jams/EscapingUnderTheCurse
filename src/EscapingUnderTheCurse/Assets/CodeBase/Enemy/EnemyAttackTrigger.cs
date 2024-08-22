using UnityEngine;

namespace CodeBase.Enemy
{
  public class EnemyAttackTrigger : MonoBehaviour
  {
    public EnemyAttack Attack;
    public EnemyManipulator Manipulator;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        Attack.SetReadiness();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        Manipulator.FlipToOppositeSide();
    }
  }
}