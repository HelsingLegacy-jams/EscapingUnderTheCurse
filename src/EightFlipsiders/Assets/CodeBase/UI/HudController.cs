using UnityEngine;

namespace CodeBase.UI
{
  public class HudController : MonoBehaviour
  {
    public GameObject Victory;

    public void ShowVictory() => 
      Victory.SetActive(true);
  }
}