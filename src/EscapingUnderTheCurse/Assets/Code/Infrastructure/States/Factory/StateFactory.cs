using Zenject;

namespace Code.Infrastructure.States.Factory
{
  public class StateFactory : IStateFactory
  {
    private IInstantiator _instantiator;

    public StateFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public TState Create<TState>() where TState : IState => 
      _instantiator.Instantiate<TState>();
    
    public TState Create<TState>(params object[] objects) where TState : IState => 
      _instantiator.Instantiate<TState>(objects);
  }
}