using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Hero
{
  public class EnemyKiller : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other) => 
      other.GetComponent<EnemyDeath>().Die();
  }
}