using System;

namespace CodeBase.Infrastructure.Countdown
{
  public class TimerService : ITimer
  {
    public bool IsCountdown { get; private set; }
    
    public event Action<float> TimerUpdated;

    public void SetTimer(float duration) => 
      TimerUpdated?.Invoke(duration);

    public void StartCountdown() => 
      IsCountdown = true;

    public void ResetTimer() => 
      IsCountdown = false;
  }
}