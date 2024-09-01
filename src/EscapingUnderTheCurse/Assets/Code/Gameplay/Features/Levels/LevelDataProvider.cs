using UnityEngine;

namespace Code.Gameplay.Features.Levels
{
  public class LevelDataProvider : ILevelDataProvider, ILevelDataBinder
  {
    public Vector2 StartPoint { get; private set; }

    public void SetHeroInitPoint(Vector2 startPoint) => 
      StartPoint = startPoint;
  }
}