using CodeBase.Hero;
using CodeBase.Infrastructure.Countdown;
using CodeBase.Infrastructure.Injector;
using UnityEngine;

namespace CodeBase.Triggers
{
  public class TimerTrigger : MonoBehaviour, ITimerProvider
  {
    public float Duration;
    public MovingDirection MovingDirection;
    
    private ITimer _timer;

    public void Construct(ITimer timerService) => 
      _timer = timerService;

    private void OnTriggerEnter2D(Collider2D other)
    {
      // if (other.GetComponentInParent<HeroMove>().Direction == MovingDirection)
        if (!_timer.IsCountdown)
          _timer.SetTimer(Duration);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      // if (other.GetComponentInParent<HeroMove>().Direction == MovingDirection) 
        _timer.StartCountdown();
    }
  }
}