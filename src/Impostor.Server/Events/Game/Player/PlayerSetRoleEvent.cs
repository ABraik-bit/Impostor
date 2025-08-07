using Impostor.Api.Events.Player;
using Impostor.Api.Games;
using Impostor.Api.Innersloth;
using Impostor.Api.Net;
using Impostor.Api.Net.Inner.Objects;

namespace Impostor.Server.Events.Game.Player
{
    public class PlayerSetRoleEvent : IPlayerSetRoleEvent
    {
        public PlayerSetRoleEvent(IGame game, IClientPlayer clientPlayer, IInnerPlayerControl playerControl, IInnerPlayerInfo playerInfo,  RoleTypes role)
        {
            Game = game;
            ClientPlayer = clientPlayer;
            PlayerControl = playerControl;
            PlayerInfo = playerInfo;
            Role = role;
        }

        public IGame Game { get; }

        public IClientPlayer ClientPlayer { get; }

        public IInnerPlayerControl PlayerControl { get; }

        public IInnerPlayerInfo PlayerInfo { get; }

        public RoleTypes Role { get; }

        public bool IsCancelled { get; set; }
    }
}
