using Content.Server.GameTicking;
using Content.Server.GameTicking.Rules;
using Content.Server.Maps;
using Robust.Shared.Prototypes;

namespace Content.Server.ShipBattle;

public sealed class ShipBattleRuleSystem : GameRuleSystem
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    public override string Prototype => "ShipBattle";

    public static string MapOverride => "commander";

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LoadingMapsEvent>(OnLoadingMaps);
    }

    private void OnLoadingMaps(LoadingMapsEvent ev)
    {
        if (!Enabled)
            return;

        if (!_prototypeManager.TryIndex<GameMapPrototype>(MapOverride, out var proto))
            return;

        // Override the mainframe.
        ev.Maps = new() { proto };
    }

    public override void Started()
    {
    }

    public override void Ended()
    {
    }
}
