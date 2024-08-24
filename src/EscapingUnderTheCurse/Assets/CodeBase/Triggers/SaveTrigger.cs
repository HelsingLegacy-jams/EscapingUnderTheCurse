using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using UnityEngine;

namespace CodeBase.Triggers
{
  public class SaveTrigger : MonoBehaviour
  {
    private IPersistentProgressService _progress;
    private ISaveLoadService _saveLoadService;

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //   other
    //     .GetComponent<ISavedProgress>()
    //     .UpdateProgress(_progress.Progress);
    //   
    //   _saveLoadService.SaveProgress();
    //   gameObject.SetActive(false);
    // }
  }
}