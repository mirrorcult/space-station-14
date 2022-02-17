using Content.Server.Roles;
using JetBrains.Annotations;

namespace Content.Server.ShipBattle;

public sealed class RedTeamRole : Role
{
    public RedTeamRole(Mind.Mind mind) : base(mind)
    {
    }

    public override string Name => Loc.GetString("ship-battle-red-team");
    public override bool Antagonist => true;
}

public sealed class BluTeamRole : Role
{
    public BluTeamRole(Mind.Mind mind) : base(mind)
    {
    }

    public override string Name => Loc.GetString("ship-battle-blu-team");
    public override bool Antagonist => true;
}
