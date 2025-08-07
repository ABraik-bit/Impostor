using Impostor.Api.Events;
using Impostor.Api.Events.Player;
using Microsoft.Extensions.Logging;

namespace Impostor.Plugins.Example.Handlers
{
    public class VentEventListener : IEventListener
    {
        private readonly ILogger<VentEventListener> _logger;

        public VentEventListener(ILogger<VentEventListener> logger)
        {
            _logger = logger;
        }

        [EventListener]
        public void OnPlayerEnterVent(IPlayerEnterVentEvent e)
        {
            _logger.LogInformation("Player {player} attempting to enter vent {vent} ({ventId})", 
                e.PlayerControl.PlayerInfo.PlayerName, e.Vent.Name, e.Vent.Id);

            // Example: Cancel vent entry for specific players or conditions
            if (e.PlayerControl.PlayerInfo.PlayerName.Contains("Blocked"))
            {
                e.IsCancelled = true;
                _logger.LogInformation("Blocked {player} from entering vent {vent}", 
                    e.PlayerControl.PlayerInfo.PlayerName, e.Vent.Name);
            }

            // Example: Cancel vent entry for specific vents
            if (e.Vent.Id == 0) // Assuming vent ID 0 is a restricted vent
            {
                e.IsCancelled = true;
                _logger.LogInformation("Blocked {player} from entering restricted vent {vent}", 
                    e.PlayerControl.PlayerInfo.PlayerName, e.Vent.Name);
            }
        }

        [EventListener]
        public void OnPlayerExitVent(IPlayerExitVentEvent e)
        {
            _logger.LogInformation("Player {player} attempting to exit vent {vent} ({ventId})", 
                e.PlayerControl.PlayerInfo.PlayerName, e.Vent.Name, e.Vent.Id);

            // Example: Cancel vent exit for specific players or conditions
            if (e.PlayerControl.PlayerInfo.PlayerName.Contains("Trapped"))
            {
                e.IsCancelled = true;
                _logger.LogInformation("Trapped {player} in vent {vent}", 
                    e.PlayerControl.PlayerInfo.PlayerName, e.Vent.Name);
            }
        }
    }
} 