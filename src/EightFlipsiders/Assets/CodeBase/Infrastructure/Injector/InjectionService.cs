using System.Collections.Generic;
using CodeBase.Infrastructure.Countdown;
using CodeBase.Triggers;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.Injector
{
  public class InjectionService : IInjectionService
  {
    private readonly ITimer _timer;

    public InjectionService(ITimer timer)
    {
      _timer = timer;
    }

    public void InjectTimer()
    {
      TriggerBase[] triggers = Object.FindObjectsOfType<TriggerBase>();
      CountdownTimer[] countdowns = Object.FindObjectsOfType<CountdownTimer>();

      InjectTo(triggers);
      InjectTo(countdowns);
    }

    private void InjectTo<T>(IEnumerable<T> constructors) where T : ITimerProvider
    {
      foreach (T constructor in constructors) 
        constructor.Construct(_timer);
    }
  }
}