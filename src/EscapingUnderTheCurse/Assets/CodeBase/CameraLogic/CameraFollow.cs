using UnityEngine;

namespace CodeBase.CameraLogic
{
  public class CameraFollow : MonoBehaviour
  {
    public float Distance;
    
    [SerializeField] private Transform _folliwing;

    private void LateUpdate()
    {
      if (_folliwing == null)
        return;

      var position = _folliwing.position;
      position.z -= Distance;

      transform.position = position;
    }

    public void Follow(GameObject following) =>
      _folliwing = following.transform;
  }
}