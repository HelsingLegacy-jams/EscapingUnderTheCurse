using System;

namespace CodeBase.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public Vector3Data Position;

    public PlayerProgress(Vector3Data position)
    {
      Position = position;
    }
  }
}