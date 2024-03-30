using CodeBase.Infrastructure.DIContainer;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    GameObject CreateHero(GameObject initialPoint);
    GameObject CreateHud();
  }
}