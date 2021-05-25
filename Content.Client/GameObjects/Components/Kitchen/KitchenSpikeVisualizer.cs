using Content.Shared.GameObjects.Components.Kitchen;
using JetBrains.Annotations;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Client.GameObjects.Components.Kitchen
{
    public class KitchenSpikeVisualizer : AppearanceVisualizer
    {
        [DataField("bloodyLayerState")] private string bloodyLayerState = "blood";
        [DataField("bodyLayerState")] private string bodyLayerState = "human";

        [UsedImplicitly]
        public override void InitializeEntity(IEntity entity)
        {
            base.InitializeEntity(entity);

            var sprite = entity.GetComponent<ISpriteComponent>();

            sprite.LayerMapSet(KitchenSpikeVisuals.Blood, sprite.AddLayerState(bloodyLayerState));
            sprite.LayerSetVisible(KitchenSpikeVisuals.Blood, false);
            sprite.LayerMapSet(KitchenSpikeVisuals.Body, sprite.AddLayerState(bodyLayerState));
            sprite.LayerSetVisible(KitchenSpikeVisuals.Body, false);
        }

        public override void OnChangeData(AppearanceComponent component)
        {
            base.OnChangeData(component);

            var sprite = component.Owner.GetComponent<ISpriteComponent>();
            if (component.TryGetData(KitchenSpikeVisuals.Blood, out bool bloody))
            {
                sprite.LayerSetVisible(KitchenSpikeVisuals.Blood, true);
            }
            else if (component.TryGetData(KitchenSpikeVisuals.Body, out KitchenSpikeBodyState state))
            {
                sprite.LayerSetVisible(KitchenSpikeVisuals.Body, state.HasBody);
                if (state.SpeciesId != string.Empty)
                    sprite.LayerSetState(KitchenSpikeVisuals.Body, state.SpeciesId);
            }
        }
    }
}
