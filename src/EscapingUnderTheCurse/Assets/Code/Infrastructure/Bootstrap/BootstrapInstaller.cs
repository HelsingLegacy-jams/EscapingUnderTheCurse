using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.UI;
using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using CodeBase.UI;
using Zenject;

namespace Code.Infrastructure.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
  {
    public LoadingCurtain Curtain;
    
    public override void InstallBindings()
    {
      LoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(Curtain);
      Container.Bind<LoadingCurtain>().FromInstance(curtain).AsSingle();
      
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.BindInterfacesTo<GameStateMachine>().AsSingle();

      Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

      Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
      
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    }


    public void Initialize()
    {
      Container.Resolve<IStatesInitializer>().InitStates();
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
  }
}