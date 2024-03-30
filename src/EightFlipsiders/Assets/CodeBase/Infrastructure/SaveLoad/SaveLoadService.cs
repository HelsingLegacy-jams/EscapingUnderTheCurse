using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.SaveLoad
{
  class SaveLoadService : ISaveLoadService
  {
    private readonly IPersistentProgressService _progress;

    public SaveLoadService(IPersistentProgressService progress)
    {
      _progress = progress;
    }

    private const string ProgressKey = "Progress";

    public void SaveProgress() => 
      PlayerPrefs.SetString(ProgressKey, _progress.Progress.ToJson());

    public PlayerProgress LoadProgress() => 
      PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerProgress>();
  }
}