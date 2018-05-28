using System;
using System.Drawing;

using SOFT152SteeringLibrary;

namespace SOFT152Steering
{
    class AntAgent
    {
        /// <summary>
        /// The speed of the agent as used in all three movment methods 
        /// Ideal value depends on timer tick interval and realistic motion of
        /// agents needed. Suggest though in range 0 ... 2
        /// </summary>
        public double AgentSpeed { set; get; }  


        /// <summary>
        /// If the agent is using the the ApproachAgent() method, this property defines
        /// at what point the agent will reduce the speed of approach to miminic a 
        /// more relistic approach behaviour
        /// </summary>
        public double ApproachRadius { set; get; }    
        

        public double AvoidDistance { set; get; }      


        /// <summary>
        /// Property defines how 'random' the agent movement is whilst 
        /// the agent is using the Wander() method
        /// Suggest range of WanderLimits is 0 ... 1
        /// </summary>
        public double WanderLimits { set; get; }


        /// <summary>
        /// Used in conjunction worldBounds to determine if
        /// the agents position will stay within the world bounds.
        /// </summary>
        public bool ShouldStayInWorldBounds { set; get; }


        /// <summary>
        /// Store and retrieve the index of the closest ant.
        /// </summary>
        public int ClosestAntIndex { set; get; }


        /// <summary>
        /// Store and retrieve the index of the closest food source.
        /// </summary>
        public int ClosestFoodIndex { set; get; }


        /// <summary>
        /// Store and retrieve the index of the closest colony nest.
        /// </summary>
        public int ClosestNestIndex { set; get; }


        /// <summary>
        /// Store the latest food location the ant agent has acquired.
        /// </summary>
        public SOFT152Vector FoodLocation { set; get; }


        /// <summary>
        /// Store the last nest location the ant agent has acquired. 
        /// </summary>
        public SOFT152Vector NestLocation { set; get; }


        // Set/get if a new closest ant has been assigned.
        public bool IsNewClosestAnt { set; get; }


        /// <summary>
        /// Store a Boolean to see if a food location is known to this ant.
        /// </summary>
        public bool IsFoodKnown { set; get; }


        /// <summary>
        /// Store a Boolean to see if a nest location is known to this ant.
        /// </summary>
        public bool IsNestKnown { set; get; }


        /// <summary>
        /// Store if the ant is carrying food currently.
        /// </summary>
        public bool IsCarryingFood { set; get; }


        /// <summary>
        /// Store if the ant is currently moving towards the food location.
        /// </summary>
        public bool IsMovingToFood { set; get; }


        /// <summary>
        /// Store if the ant is currently moving towards the nest location.
        /// </summary>
        public bool IsMovingToNest { set; get; }


        // --------------------------------------------
        // Private fields 

        /// <summary>
        /// Current postion of the agent, updated by the three
        /// movment methods
        /// </summary>
        private SOFT152Vector agentPosition;  

        /// <summary>
        /// used in conjunction with the Wander() method
        /// to detemin the next position an agent should be in 
        /// Should remain a private field and do not edit within this class
        /// </summary>
        private SOFT152Vector wanderPosition;

        /// <summary>
        /// The size of the world the agent lives on as a Rectangle object.
        /// Used in conjunction with ShouldStayInWorldBounds, which if true
        /// will mean the agents position will be kept within the world bounds 
        /// (i.e. the  world width or the world height).
        /// To keep track of the objects bounds i.e. ViewPort dimensions.
        /// </summary>
        private Rectangle worldBounds;

        /// <summary>
        /// The random object passed to the agent. 
        /// Used only in the Wander() method to generate a 
        /// random direction to move in.
        /// </summary>
        private Random randomNumberGenerator;              


        /// <summary>
        /// AntAgent constructor to initialise the AntAgent object given the 
        /// SOFT152Vector position and a Random object as a generator.
        /// </summary>
        /// <param name="position">The SOFT152Vector with X and Y coordinates of where to create the AntAgent.</param>
        /// <param name="random">The Random object generator for the AntAgent.</param>
        public AntAgent(SOFT152Vector position, Random random)
        {
            agentPosition = new SOFT152Vector(position.X, position.Y);

            randomNumberGenerator = random;

            InitialiseAgent();
        }


        /// <summary>
        /// AntAgent constructor to initialise the AntAgent object given the
        /// SOFT152Vector position, Random object as a generator and the bounds of 
        /// the world given in a Rectangle object.
        /// </summary>
        /// <param name="position">The SOFT152Vector with X and Y coordinates of where to create the AntAgent.</param>
        /// <param name="random">The Random object generator for the AntAgent.</param>
        /// <param name="bounds">The Rectangle object with the bounds of the simulation world.</param>
        public AntAgent(SOFT152Vector position, Random random, Rectangle bounds )
        {
            agentPosition = new SOFT152Vector(position.X, position.Y);

            worldBounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            randomNumberGenerator = random;

            InitialiseAgent();
        }


        /// <summary>
        /// Initialises the Agents various fields
        /// with default values.
        /// </summary>
        private void InitialiseAgent()
        {
            wanderPosition = new SOFT152Vector();

            ApproachRadius = 10;

            AvoidDistance = 25;

            AgentSpeed = 1.0;

            ShouldStayInWorldBounds = true;

            WanderLimits = 0.5;

            IsNewClosestAnt = false;

            IsFoodKnown = false;

            IsNestKnown = false;

            IsCarryingFood = false;
        }


        /// <summary>
        /// Causes the agent to make one step towards the object at objectPosition
        /// The speed of approach will reduce one this agent is within
        /// an ApproachRadius of the objectPosition.
        /// </summary>
        /// <param name="objectPosition">The SOFT152Vector with X and Y coordinates stating approach location.</param>
        public void Approach(SOFT152Vector objectPosition)
        {
            Steering.MoveTo(agentPosition, objectPosition, AgentSpeed, ApproachRadius);

            StayInWorld();
        }


        /// <summary>
        /// Causes the agent to make one step away from  the objectPosition
        /// The speed of avoid is goverened by this agents speed.
        /// </summary>
        /// <param name="objectPosition">The SOFT152Vector with X and Y coordinates location of object to flee from.</param>
        public void FleeFrom(SOFT152Vector objectPosition)
        {
            Steering.MoveFrom(agentPosition, objectPosition, AgentSpeed, AvoidDistance);

            StayInWorld();
        }


        /// <summary>
        /// Causes the agent to make one random step.
        /// The size of the step determined by the value of WanderLimits
        /// and the agents speed.
        /// </summary>
        public void Wander()
        {
            Steering.Wander(agentPosition, wanderPosition, WanderLimits, AgentSpeed, randomNumberGenerator);

            StayInWorld();
        }


        /// <summary>
        /// Make sure the ant will stay in the world if the Boolean is set to true.
        /// </summary>
        private void StayInWorld()
        {
            // if the agent should stay with in the world.
            if (ShouldStayInWorldBounds == true)
            {
                // and the world has a positive width and height.
                if (worldBounds.Width >= 0 && worldBounds.Height >= 0)
                {
                    // Now adjust the agents position if outside the limits of the world.
                    if (agentPosition.X < 0)
                        agentPosition.X = worldBounds.Width;

                    else if (agentPosition.X > worldBounds.Width)
                        agentPosition.X = 0;

                    if (agentPosition.Y < 0)
                        agentPosition.Y = worldBounds.Height;

                    else if (AgentPosition.Y > worldBounds.Height)
                        agentPosition.Y = 0;
                }
            }
        }


        /// <summary>
        /// Property (setter and getter) to set and get the SOFT152Vector of the AntAgent's position.
        /// </summary>
        public SOFT152Vector AgentPosition
        {
            set
            {
                agentPosition = value;
            }

            get
            {
                return agentPosition;
            }
        }

    }  // end class AntAgent
}
