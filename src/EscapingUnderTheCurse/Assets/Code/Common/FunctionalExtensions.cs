using System;
using Code.Gameplay.Common;

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

    public static int AsMask(this CollisionLayer layerMask) => 
      1 << (int)layerMask;
  }
}