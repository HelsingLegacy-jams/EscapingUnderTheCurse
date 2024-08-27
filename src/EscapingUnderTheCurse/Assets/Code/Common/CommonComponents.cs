using Code.Infrastructure.View;
using Entitas;

namespace Code.Common
{
  [Game] public class View : IComponent { public EntityBehaviour Value; }
  [Game] public class ViewPath : IComponent { public EntityBehaviour Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
}