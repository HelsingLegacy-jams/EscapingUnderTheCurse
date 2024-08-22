using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
  public class CloseButton : MonoBehaviour, IPointerClickHandler
  {
    public GameObject Window;
    
    public void OnPointerClick(PointerEventData eventData) => 
      Window.SetActive(false);
  }
}