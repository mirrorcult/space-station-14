using System;
using Robust.Shared.Serialization;

namespace Content.Shared.GameObjects.Components.Kitchen
{
    [Serializable, NetSerializable]
    public enum KitchenSpikeVisuals
    {
        Blood,
        Body
    }

    [Serializable, NetSerializable]
    public struct KitchenSpikeBodyState
    {
        public bool HasBody;
        public string SpeciesId;

        public KitchenSpikeBodyState(bool body, string id)
        {
            HasBody = body;
            SpeciesId = id;
        }
    }
}
