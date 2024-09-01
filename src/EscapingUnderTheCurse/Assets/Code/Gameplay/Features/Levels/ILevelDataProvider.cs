using UnityEngine;

namespace Code.Gameplay.Features.Levels
{
  public interface ILevelDataProvider
  {
    Vector2 StartPoint { get; }
  }
}