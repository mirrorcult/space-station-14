using Content.Server.GameObjects.Components.Disposal;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.EntitySystems.Disposal
{
    public sealed class DisposalTubeSystem : EntitySystem
    {
        public override void Initialize()
        {
            base.Initialize();

            SubscribeLocalEvent<DisposalTubeComponent, PhysicsBodyTypeChangedEvent>(BodyTypeChanged);
        }

        private static void BodyTypeChanged(
            EntityUid uid,
            DisposalTubeComponent component,
            PhysicsBodyTypeChangedEvent args)
        {
            component.AnchoredChanged();
        }
    }
}
