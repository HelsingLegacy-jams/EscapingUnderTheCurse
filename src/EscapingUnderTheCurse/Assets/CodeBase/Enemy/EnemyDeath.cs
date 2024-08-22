using UnityEngine;

namespace CodeBase.Enemy
{
  public class EnemyDeath : MonoBehaviour
  {
    public GameObject Enemy;
    
    private EnemyAnimator _animator;

    private void Awake() => 
      _animator = GetComponent<EnemyAnimator>();

    public void Die() => 
      _animator.PlayDeath();

    public void OnDeath() => 
      Destroy(Enemy);
  }
}