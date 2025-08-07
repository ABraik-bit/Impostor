using System.Numerics;
using System.Threading.Tasks;

namespace Impostor.Api.Net.Inner.Objects.Components
{
    public interface IInnerCustomNetworkTransform : IInnerNetObject
    {
        /// <summary>
        ///     Gets position where the object thinks it is (not interpolated).
        /// </summary>
        Vector2 Position { get; }

        IMessageReader PacketMessageReader { get; }

        /// <summary>
        ///     Increments the last sequence id.
        /// </summary>
        /// <param name="value">The value to increment.</param>
        /// <returns>The new value.</returns>
        ushort IncrementLastSequenceId(ushort value);

        /// <summary>
        ///     Snaps the current to the given position <see cref="IInnerPlayerControl" />.
        /// </summary>
        /// <param name="position">The target position.</param>
        /// <returns>Task that must be awaited.</returns>
        ValueTask SnapToAsync(Vector2 position);
    }
}
