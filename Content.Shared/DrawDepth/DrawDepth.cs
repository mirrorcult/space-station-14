#nullable enable
using Robust.Shared.Serialization;
using DrawDepthTag = Robust.Shared.GameObjects.DrawDepth;

namespace Content.Shared.DrawDepth
{
    [ConstantsFor(typeof(DrawDepthTag))]
    public enum DrawDepth
    {
        LowFloors = DrawDepthTag.Default - 7,
        /// <summary>
        /// Things that are beneath regular floors, such as wires.
        /// </summary>
        BelowFloor = DrawDepthTag.Default - 6,
        FloorTiles = DrawDepthTag.Default - 5,
        /// <summary>
        /// Things that are actually right on the floor, like vents.
        /// </summary>
        FloorObjects = DrawDepthTag.Default - 4,
        Walls = DrawDepthTag.Default - 3,
        WallTops = DrawDepthTag.Default - 2,
        WallMountedItems = DrawDepthTag.Default - 1,
        Objects = DrawDepthTag.Default,
        Items = DrawDepthTag.Default + 1,
        Mobs = DrawDepthTag.Default + 2,
        HighlightedItems = DrawDepthTag.Default + 3,
        Effects = DrawDepthTag.Default + 4,
        Ghosts = DrawDepthTag.Default + 5,
        Overlays = DrawDepthTag.Default + 6,
    }
}
