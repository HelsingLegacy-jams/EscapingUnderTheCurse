using Entitas;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class Moving : IComponent {}
  [Game] public class MovementAvailable : IComponent {}
  
  [Game] public class Speed : IComponent { public float Value; }
  [Game] public class Direction : IComponent { public MovingDirection Value; }
  [Game] public class DirectionModifier : IComponent { public int Value; }
}