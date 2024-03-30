using UnityEngine;

namespace CodeBase.Enemy
{
  public class EnemyManipulator : MonoBehaviour
  {
    public float BodySize = 2f;

    public void FlipToOppositeSide()
    {
      if(transform.localScale.x > 0)
        transform.localScale = new Vector3(-BodySize, BodySize, 1f);
      else
        transform.localScale = new Vector3(BodySize, BodySize, 1f);
    }
  }
}