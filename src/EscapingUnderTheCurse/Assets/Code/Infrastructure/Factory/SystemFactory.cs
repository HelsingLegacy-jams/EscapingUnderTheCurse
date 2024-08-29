using Entitas;
using Zenject;

namespace Code.Infrastructure.Factory
{
  class SystemFactory : ISystemFactory
  {
    private IInstantiator _instantiator;

    public SystemFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public T Create<T>() where T : ISystem => 
      _instantiator.Instantiate<T>();

    public T Create<T>(params object[] obj) where T : ISystem => 
      _instantiator.Instantiate<T>(obj);
  }
}