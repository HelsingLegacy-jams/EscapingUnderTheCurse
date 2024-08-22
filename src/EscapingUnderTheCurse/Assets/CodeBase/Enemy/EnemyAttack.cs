using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Enemy
{
  public class EnemyAttack : MonoBehaviour
  {
    [Header("Attack activation delay.")] 
    public float AttackCooldown = 3f;

    [Header("Radius of Attack Capsule")] 
    public float Cleavage = 0f;

    [FormerlySerializedAs("AttackRadius")] [Header("Center of attack point.")]
    public float AttackOffset = -1.2f;

    public EnemyAnimator _animator;

    private bool _isReadyToAttack = false;
    private bool _isAttacking = false;
    private Collider2D[] _hits = new Collider2D[1];
    private int _layerMask;
    private float _attackCooldown;

    private void Awake()
    {
      _layerMask = 1 << LayerMask.NameToLayer("Player");
      _attackCooldown = AttackCooldown;
    }

    private void Update()
    {
      if (!_isReadyToAttack)
        return;

      UpdateCooldown();

      if (CanAttack())
        StartAttack();
    }

    public void OnAttack()
    {
      if (Hit(out Collider2D hit))
      {
        Debug.Log(hit);
      }
    }

    public void OnAttackComplete()
    {
      _attackCooldown = AttackCooldown;
      _isAttacking = false;
    }

    public void SetReadiness() => 
      _isReadyToAttack = true;

    private bool Hit(out Collider2D hit)
    {
      int hitBoxCount = Physics2D.OverlapCapsuleNonAlloc(StartPoint(), new Vector2(0.5f, 2f),
        CapsuleDirection2D.Vertical, Cleavage, _hits, _layerMask);

      hit = _hits.FirstOrDefault();
      
      return hitBoxCount > 0;
    }

    private Vector2 StartPoint() => 
      new(transform.position.x - AttackOffset, transform.position.y);

    private void UpdateCooldown()
    {
      if (!CooldownIsUp())
        _attackCooldown -= Time.deltaTime;
    }

    private bool CanAttack() =>
      !_isAttacking && CooldownIsUp();

    private void StartAttack()
    {
      _animator.PlayAttack();

      _isAttacking = true;
    }

    private bool CooldownIsUp() =>
      _attackCooldown <= 0;
  }
}