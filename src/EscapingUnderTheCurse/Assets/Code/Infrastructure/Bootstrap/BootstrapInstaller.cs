using Code.Infrastructure.Factory;
using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.UI;
using CodeBase.Infrastructure.Bootstrap;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.PersistentProgress;
using CodeBase.Infrastructure.SaveLoad;
using Zenject;

namespace Code.Infrastructure.Bootstrap
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
  {
    public LoadingCurtain Curtain;
    
    public override void InstallBindings()
    {
      BindCurtain();
      BindInfrastructure();
      BindAssetManagement();
      BindProgress();
      BindGameplayFactories();
      BindInstaller();
    }

    private void BindGameplayFactories()
    {
    }

    private void BindInstaller()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    }

    private void BindProgress()
    {
      Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void BindAssetManagement()
    {
      Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }

    private void BindInfrastructure()
    {
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.BindInterfacesTo<GameStateMachine>().AsSingle();
    }

    private void BindCurtain()
    {
      LoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(Curtain);
      Container.Bind<LoadingCurtain>().FromInstance(curtain).AsSingle();
    }


    public void Initialize()
    {
      Container.Resolve<IStatesInitializer>().InitStates();
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
  }
}