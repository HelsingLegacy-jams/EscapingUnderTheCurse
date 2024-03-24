﻿using System;
using System.Collections;
using CodeBase.Infrastructure.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Scene
{
  public class SceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Load(string nextScene, Action onLoaded = null)
    {
      _coroutineRunner.StartCoroutine(LoadScene(nextScene, onLoaded));
    }

    private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
    {
      if (SceneManager.GetActiveScene().name == nextScene)
      {
        onLoaded?.Invoke();
        yield break;
      }

      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

      while (!waitNextScene.isDone)
        yield return null;
      
      onLoaded?.Invoke();
    }
  }
}