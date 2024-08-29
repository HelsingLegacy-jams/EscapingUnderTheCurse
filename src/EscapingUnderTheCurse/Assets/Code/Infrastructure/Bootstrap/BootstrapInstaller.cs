using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Hero.Provider;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.View.Factory;
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
      BindContexts();
      BindInfrastructure();
      BindAssetManagement();
      BindGameplayServices();
      BindGameplayFactories();
      BindInstaller();
    }

    public void Initialize()
    {
      Container.Resolve<IStatesInitializer>().InitStates();
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }

    private void BindCurtain()
    {
      LoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(Curtain);
      Container.Bind<LoadingCurtain>().FromInstance(curtain).AsSingle();
    }

    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }

    private void BindInfrastructure()
    {
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.BindInterfacesTo<GameStateMachine>().AsSingle();
    }

    private void BindAssetManagement()
    {
      Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }

    private void BindGameplayServices()
    {
      Container.Bind<IHeroProvider>().To<HeroProvider>().AsSingle();
      Container.Bind<IUnityTimeService>().To<UnityTimeService>().AsSingle();
      Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void BindGameplayFactories()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
      Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
    }

    private void BindInstaller()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    }
  }
}