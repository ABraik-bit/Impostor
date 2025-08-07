using Impostor.Api.Events.Player;
using Impostor.Api.Innersloth;

namespace Impostor.Api.Events.Player
{
    public interface IPlayerSetRoleEvent : IPlayerEvent, IEventCancelable
    {
        /// <summary>
        ///     Gets the role set by the host.
        /// </summary>
        RoleTypes Role { get; }
    }
}
