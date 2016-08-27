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
        /// Global randomness for the simulation. Used to make checks for things like
        /// technical failures, software tickets, etc... Minor entropy but should
        /// not have major affect on the decision as to whether or not the player wins.
        /// </summary>
        public Random Rand => _rand;

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
        public GameplayModel Create()
        {
            return new GameplayModel();
        }
    }
}
