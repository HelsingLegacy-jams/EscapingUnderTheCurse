namespace Code.Gameplay.Common.Time
{
  public interface IUnityTimeService
  {
    float DeltaTime { get; }
    void StopTime();
    void StartTime();
  }
}