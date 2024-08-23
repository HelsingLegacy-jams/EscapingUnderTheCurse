using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Bootstrap
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}