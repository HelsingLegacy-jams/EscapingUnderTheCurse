using Code.Features.Hero.Behaviours;
using Entitas;

namespace Code.Features.Movement
{
  [Game] public class Moving : IComponent {}
  [Game] public class MovementAvailable : IComponent {}
  
  [Game] public class Speed : IComponent { public float Value; }
  [Game] public class Direction : IComponent { public MovingDirection Value; }
  [Game] public class HeroMoverComponent : IComponent { public HeroMover Value; }
}