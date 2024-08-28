using Entitas;

namespace Code.Infrastructure.Factory
{
  public interface ISystemFactory
  {
    T Create<T>() where T : ISystem;
    T Create<T>(params object[] obj) where T : ISystem;
  }
}