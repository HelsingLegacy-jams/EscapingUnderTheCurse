using UnityEngine;

namespace CodeBase.Hero
{
  public class DoorKey : MonoBehaviour
  {
    public Doors Doors;

    private void OnTriggerEnter2D(Collider2D other)
    {
      Doors.Open();
    }
  }
}