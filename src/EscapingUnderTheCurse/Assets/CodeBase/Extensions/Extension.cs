using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Extensions
{
  public static class Extension
  {
    public static Vector3Data AsVector3Data(this Vector3 vector) =>
      new Vector3Data(vector.x, vector.y, vector.z);

    public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
      new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);

    public static string ToJson(this object obj) =>
      JsonUtility.ToJson(obj);

    public static T ToDeserialized<T>(this string json) => 
      JsonUtility.FromJson<T>(json);

    public static Vector3 AddY(this Vector3 vector3) => 
      new Vector3(vector3.x, vector3.y + 0.5f, vector3.z);
  }
}