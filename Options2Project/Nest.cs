using SOFT152SteeringLibrary;

namespace SOFT152Steering
{
    class Nest
    {
        /// <summary>
        /// Hold the position of where the nest was created.
        /// </summary>
        public SOFT152Vector NestPosition { set; get; }
        

        /// <summary>
        /// Store the number of food pieces deposited.
        /// </summary>
        private int foodDeposited;


        /// <summary>
        /// Nest constructor to initialise the nest object,
        /// providing the SOFT152Vector position to create the object.
        /// </summary>
        /// <param name="nestPosition">The SOFT152Vector with X and Y coordinates of where to create the nest.</param>
        public Nest(SOFT152Vector nestPosition)
        {
            // Initialise the position of the nest as a vector.
            NestPosition = new SOFT152Vector(nestPosition.X, nestPosition.Y);
            
            // Keep track of the total food pieces deposited at the nest object.
            foodDeposited = 0;
        }


        /// <summary>
        /// Property (getter) to return the total food pieces deposited at the nest.
        /// </summary>
        public int FoodDeposited
        {
            get
            {
                return foodDeposited;
            }
        }
       

        /// <summary>
        /// Deposit a single food piece to the food object
        /// at any one given time.
        /// </summary>
        public void DepositFood()
        {
            foodDeposited += 1;
        }
    }
}
