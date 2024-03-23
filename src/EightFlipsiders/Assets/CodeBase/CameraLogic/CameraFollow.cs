using UnityEngine;

namespace CodeBase.CameraLogic
{
  public class CameraFollow : MonoBehaviour
  {
    [SerializeField] private Transform _folliwing;

    private void LateUpdate()
    {
      if (_folliwing == null)
        return;

      var position = _folliwing.position;
      position.z += 35;

      transform.position = position;
    }

    public void Follow(GameObject following) =>
      _folliwing = following.transform;
  }
}