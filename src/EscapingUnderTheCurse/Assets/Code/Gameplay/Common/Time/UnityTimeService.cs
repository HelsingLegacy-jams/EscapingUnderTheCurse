namespace Code.Gameplay.Common.Time
{
  public class UnityTimeService : IUnityTimeService
  {
    private bool _paused;
    
    public float DeltaTime => !_paused ? UnityEngine.Time.deltaTime : 0;

    public void StopTime() => _paused = true;
    public void StartTime() => _paused = false;
  }
}