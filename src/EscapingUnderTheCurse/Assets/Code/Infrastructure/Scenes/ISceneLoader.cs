using System;

namespace Code.Infrastructure.Scenes
{
  public interface ISceneLoader
  {
    void Load(string nextScene, Action onLoaded = null);
  }
}