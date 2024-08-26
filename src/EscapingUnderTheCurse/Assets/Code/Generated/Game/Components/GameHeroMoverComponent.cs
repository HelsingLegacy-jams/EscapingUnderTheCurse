//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHeroMover;

    public static Entitas.IMatcher<GameEntity> HeroMover {
        get {
            if (_matcherHeroMover == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HeroMover);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHeroMover = matcher;
            }

            return _matcherHeroMover;
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

    public Code.Features.Movement.HeroMoverComponent heroMover { get { return (Code.Features.Movement.HeroMoverComponent)GetComponent(GameComponentsLookup.HeroMover); } }
    public Code.Features.Hero.Behaviours.HeroMover HeroMover { get { return heroMover.Value; } }
    public bool hasHeroMover { get { return HasComponent(GameComponentsLookup.HeroMover); } }

    public GameEntity AddHeroMover(Code.Features.Hero.Behaviours.HeroMover newValue) {
        var index = GameComponentsLookup.HeroMover;
        var component = (Code.Features.Movement.HeroMoverComponent)CreateComponent(index, typeof(Code.Features.Movement.HeroMoverComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHeroMover(Code.Features.Hero.Behaviours.HeroMover newValue) {
        var index = GameComponentsLookup.HeroMover;
        var component = (Code.Features.Movement.HeroMoverComponent)CreateComponent(index, typeof(Code.Features.Movement.HeroMoverComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHeroMover() {
        RemoveComponent(GameComponentsLookup.HeroMover);
        return this;
    }
}
