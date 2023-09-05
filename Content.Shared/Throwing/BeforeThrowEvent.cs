using System.Numerics;

namespace Content.Shared.Throwing
{
    public abstract class BaseBeforeThrowEvent : HandledEntityEventArgs
    {
        protected BaseBeforeThrowEvent(EntityUid itemUid, Vector2 direction, float throwStrength, EntityUid playerUid)
        {
            ItemUid = itemUid;
            Direction = direction;
            ThrowStrength = throwStrength;
            PlayerUid = playerUid;
        }

        public EntityUid ItemUid { get; set; }
        public Vector2 Direction { get; }
        public float ThrowStrength { get; set;}
        public EntityUid PlayerUid { get; }
    }

    /// <summary>
    ///     Raised directed on the player throwing an entity so systems can override behavior
    ///     or change the item being thrown (or strength.)
    /// </summary>
    public sealed class BeforeThrowEvent : BaseBeforeThrowEvent
    {
        public BeforeThrowEvent(EntityUid itemUid, Vector2 direction, float throwStrength, EntityUid playerUid) : base(itemUid, direction, throwStrength, playerUid)
        {
        }
    }

    /// <summary>
    ///     Raised directed on the item being thrown so systems can override behavior
    ///     or change the item being thrown (or strength.)
    /// </summary>
    public sealed class BeforeThrownEvent : BaseBeforeThrowEvent
    {
        public BeforeThrownEvent(EntityUid itemUid, Vector2 direction, float throwStrength, EntityUid playerUid) : base(itemUid, direction, throwStrength, playerUid)
        {
        }
    }
}
