using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using Zenject;

namespace Code.Infrastructure.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.BindInterfacesTo<GameStateMachine>().AsSingle();
      
      
      Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }


    public void Initialize()
    {
      Container.Resolve<IStatesInitializer>().InitStates();
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
  }
}