using System;
using CodeBase.Infrastructure.DIContainer;

namespace CodeBase.Infrastructure.Countdown
{
  public interface ITimer : IService
  {
    event Action<float> TimerUpdated;
    bool IsCountdown { get; }
    void SetTimer(float duration);
    void StartCountdown();
    void ResetTimer();
  }
}