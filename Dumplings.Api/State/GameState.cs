using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.State
{
    /// <summary>
    /// Enum to present visual game states, or screen changes e.g main menu, game end banner etc
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Pre-Splash screen
        /// </summary>
        INITIALISING,

        /// <summary>
        /// Splash Screen
        /// </summary>
        LOADING,

        /// <summary>
        /// Main Menu
        /// </summary>
        MAIN_MENU,

        /// <summary>
        /// Single Player game play
        /// </summary>
        OFFLINE_PLAY,

        /// <summary>
        /// When a game is lost or won
        /// </summary>
        END_OF_GAME
    }
}
