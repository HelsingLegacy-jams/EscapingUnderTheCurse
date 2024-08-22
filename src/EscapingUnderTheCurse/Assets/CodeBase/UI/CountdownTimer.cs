using CodeBase.Infrastructure.Countdown;
using CodeBase.Infrastructure.Injector;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
  public class CountdownTimer : MonoBehaviour, ITimerProvider
  {
    public TextMeshProUGUI CountdownField;

    private float _duration;

    private ITimer _timeService;

    public void Construct(ITimer timerService)
    {
      _timeService = timerService;
      TimerUpdateSubscription();
    }

    private void Update()
    {
      if (!_timeService.IsCountdown)
        return;

      Countdown();
    }

    private void OnDestroy() =>
      _timeService.TimerUpdated -= SetTimerValue;

    private void TimerUpdateSubscription() =>
      _timeService.TimerUpdated += SetTimerValue;

    private void Countdown()
    {
      _duration -= Time.deltaTime;

      if (_duration <= 0)
      {
        _timeService.ResetTimer();
        _duration = 0f;
      }

      ShowTime(_duration);
    }

    private void SetTimerValue(float duration)
    {
      _duration = duration;
      ShowTime(_duration);
    }

    private void ShowTime(float duration)
    {
      float seconds = Mathf.FloorToInt(duration);
      float milliSeconds = (duration - Mathf.FloorToInt(duration)) * 1000f;

      CountdownField.text = string.Format($"{seconds:00}:{milliSeconds:000}");
    }
  }
}