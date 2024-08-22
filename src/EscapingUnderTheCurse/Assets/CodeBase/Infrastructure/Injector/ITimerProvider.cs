using CodeBase.Infrastructure.Countdown;

namespace CodeBase.Infrastructure.Injector
{
  public interface ITimerProvider
  {
    void Construct(ITimer timerService);
  }
}