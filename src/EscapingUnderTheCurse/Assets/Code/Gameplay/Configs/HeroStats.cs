using UnityEngine;

namespace Code.Gameplay.Configs
{
  [CreateAssetMenu(menuName = "Configs/Hero", fileName = "HeroStats")]
  public class HeroStats : ScriptableObject
  {
    public float Speed;
    public float JumpingForce;
  }
}