using SOFT152SteeringLibrary;

namespace SOFT152Steering
{
    class Food
    {
        /// <summary>
        /// Allow for the food source to be either available or not.
        /// </summary>
        public bool isFoodDepleted;


        /// <summary>
        /// Store the x and y co-ordinate of the food source in the world.
        /// </summary>
        public SOFT152Vector FoodPosition { set; get; }


        /// <summary>
        /// Store number of food pieces available in the food source.
        /// </summary>
        private int foodAvailable;


        /// <summary>
        /// Food constructor to initialise the food source object,
        /// providing the SOFT152Vector position to create the object.
        /// </summary>
        /// <param name="foodPosition">The SOFT152Vector with X and Y coordinates of where to create the food source.</param>
        public Food(SOFT152Vector foodPosition)
        {
            FoodPosition = new SOFT152Vector(foodPosition.X, foodPosition.Y);

            // An initial size of a 200 pieces in each food source.
            foodAvailable = 200;

            // A Boolean value as a state which can change when
            // the food source is empty.
            isFoodDepleted = false;
        }


        /// <summary>
        /// Food constructor to initialise the food source object
        /// with a given SOFT152Vector position and the food pieces 
        /// available at the food source.
        /// </summary>
        /// <param name="foodPosition">The SOFT152Vector with X and Y coordinates of where to create the food source.</param>
        /// <param name="foodPieces">The number of pieces of food to create.</param>
        public Food(SOFT152Vector foodPosition, int foodPieces)
        {
            FoodPosition = new SOFT152Vector(foodPosition.X, foodPosition.Y);

            foodAvailable = foodPieces;

            isFoodDepleted = false;
        }


        /// <summary>
        /// Property (getter) for the food available variable to return 
        /// the pieces of food available at the food source.
        /// </summary>
        public int FoodAvailable
        {
            get
            {
                return foodAvailable;
            }
        }


        /// <summary>
        /// Property (getter) to return if the food source
        /// has been depleted at the present moment.
        /// </summary>
        public bool IsFoodDepleted
        {
            get
            {
                return isFoodDepleted;
            }
        }


        /// <summary>
        /// A single piece of food can be taken from the Food object at 
        /// one time. Food can only be taken as long as the source is not yet been depleted.
        /// </summary>
        public void TakeFood()
        {
            if (foodAvailable > 0)
            {
                foodAvailable -= 1;

                if (foodAvailable == 0)
                {
                    isFoodDepleted = true;
                }
            }
        }
    }
}
