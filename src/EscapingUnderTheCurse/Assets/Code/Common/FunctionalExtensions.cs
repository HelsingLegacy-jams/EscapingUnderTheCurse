using System;

namespace Code.Common
{
  public static class FunctionalExtensions
  {
    public static T With<T>(this T self, Action<T> set)
    {
      set.Invoke(self);
      return self;
    }
    public static T With<T>(this T self, Action<T> set, bool when)
    {
      if(when)
        set.Invoke(self);
      return self;
    }
  }
}