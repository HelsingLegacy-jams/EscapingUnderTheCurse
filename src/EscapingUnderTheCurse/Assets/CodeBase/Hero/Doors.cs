using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Hero
{
  public class Doors : MonoBehaviour
  {
    public Sprite DoorOpened;
    private bool _isOpened = false;
    private HudController _hud;

    private void OnTriggerEnter2D(Collider2D other)
    {
      _hud = FindObjectOfType<HudController>();

      if (_isOpened)
      {
        _hud.ShowVictory();
        var hero = FindObjectOfType<HeroMove>();
        hero.GetComponent<HeroMove>().SwitchOff();
      }
    }

    public void Open()
    {
      GetComponent<SpriteRenderer>().sprite = DoorOpened;
      _isOpened = true;
    }
  }
}