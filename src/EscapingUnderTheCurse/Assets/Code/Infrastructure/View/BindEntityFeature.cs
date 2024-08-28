using Code.Infrastructure.Factory;
using Code.Infrastructure.View.Systems;

namespace Code.Infrastructure.View
{
  public sealed class BindEntityFeature : Feature
  {
    public BindEntityFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityViewSystem>());
    }
  }
}