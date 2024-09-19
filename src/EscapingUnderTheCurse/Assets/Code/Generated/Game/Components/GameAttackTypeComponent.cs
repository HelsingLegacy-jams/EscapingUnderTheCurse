//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAttackType;

    public static Entitas.IMatcher<GameEntity> AttackType {
        get {
            if (_matcherAttackType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackType = matcher;
            }

            return _matcherAttackType;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Hero.AttackType attackType { get { return (Code.Gameplay.Features.Hero.AttackType)GetComponent(GameComponentsLookup.AttackType); } }
    public Code.Gameplay.Features.Hero.AttackTypeID AttackType { get { return attackType.Value; } }
    public bool hasAttackType { get { return HasComponent(GameComponentsLookup.AttackType); } }

    public GameEntity AddAttackType(Code.Gameplay.Features.Hero.AttackTypeID newValue) {
        var index = GameComponentsLookup.AttackType;
        var component = (Code.Gameplay.Features.Hero.AttackType)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.AttackType));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAttackType(Code.Gameplay.Features.Hero.AttackTypeID newValue) {
        var index = GameComponentsLookup.AttackType;
        var component = (Code.Gameplay.Features.Hero.AttackType)CreateComponent(index, typeof(Code.Gameplay.Features.Hero.AttackType));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAttackType() {
        RemoveComponent(GameComponentsLookup.AttackType);
        return this;
    }
}
