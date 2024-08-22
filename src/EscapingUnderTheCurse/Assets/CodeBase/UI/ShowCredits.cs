using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
  public class ShowCredits : MonoBehaviour, IPointerClickHandler
  {
    public GameObject Credits;
    
    public void OnPointerClick(PointerEventData eventData)
    {
      Credits.SetActive(true);
    }
  }
}