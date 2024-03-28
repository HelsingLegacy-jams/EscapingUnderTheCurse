using CodeBase.Hero;
using CodeBase.Infrastructure.Countdown;
using CodeBase.Infrastructure.Injector;
using UnityEngine;

namespace CodeBase.Triggers
{
  public class TriggerBase : MonoBehaviour, ITimerProvider
  {
    public float Duration;
    public MovingDirection MovingDirection;
    public UnderlingBase Underling;
    
    private ITimer _timer;

    public void Construct(ITimer timerService) => 
      _timer = timerService;

    private void OnTriggerEnter2D(Collider2D other)
    {
      // Coroutine to hide obstacle
      // Coroutine to stop Hero moving for the time until obstacle will be hided
      if (!_timer.IsCountdown)
        _timer.SetTimer(Duration);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      
      _timer.StartCountdown();
    }
  }
}