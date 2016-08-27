using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    /// <summary>
    /// This is the overall model for gameplay, the entire simulation stems
    /// from an instance of this object.
    /// </summary>
    class GameplayModel
    {
        private Random _rand => new Random();

        /// <summary>
        /// Model of Dolittle Widgets Corporation
        /// </summary>
        public Company Company { get; private set; }

        /// <summary>
        /// This model represents the thing the player is managing for the simulation.
        /// </summary>
        public ITDepartment ITDepartment { get; private set; }

        /// <summary>
        /// Use Static factory.
        /// </summary>
        private GameplayModel() { }

        /// <summary>
        /// Create a new model of gameplay, called when new game is started.
        /// </summary>
        /// <returns></returns>
        public static GameplayModel Create(string playerName, Gender gender)
        {
            var gameplayModel = new GameplayModel();
            gameplayModel.Company = Company.Create(gameplayModel._rand, playerName, gender);
            return gameplayModel;
        }
    }
}
