using System.Collections;
using CodeBase.Infrastructure.Countdown;
using CodeBase.Infrastructure.Injector;
using UnityEngine;

namespace CodeBase.Triggers
{
  public class UnderlingBase : MonoBehaviour, ITimerProvider
  {
    //Collider to prevent hero moving while on moving part
    // public Collider2D collider;
    
    private Vector3 _startingPosition;

    private ITimer _timer;

    public void Construct(ITimer timerService) =>
      _timer = timerService;

    private void Start() =>
      _startingPosition = transform.position;

    public void ObstacleToPosition(float time)
    {
      StartCoroutine(ToNormalPosition(time));
    }

    private IEnumerator ToNormalPosition(float time)
    {
      float returnTime = 1.5f;
      float elapsedTime = 0f;

      yield return new WaitForSeconds(time);

      while (elapsedTime < returnTime)
      {
        yield return new WaitForFixedUpdate();
        elapsedTime += Time.deltaTime;
        
        transform.position = Vector3.Lerp(transform.position, _startingPosition, elapsedTime / returnTime);
      }
      
      //release hero movement if stay on trigger
    }
  }
}