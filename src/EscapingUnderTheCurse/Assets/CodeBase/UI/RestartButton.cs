using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
  public class RestartButton : MonoBehaviour, IPointerClickHandler
  {
    private GameStateMachine _stateMachine;

    public void OnPointerClick(PointerEventData eventData) => 
      _stateMachine.Enter<RestartState>();

    private void FixedUpdate()
    {
      if (_stateMachine != null)
        return;

      _stateMachine = FindObjectOfType<GameBootstrapper>().StateMachine();
    }
  }
}