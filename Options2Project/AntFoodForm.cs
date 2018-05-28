using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

using SOFT152SteeringLibrary;

namespace SOFT152Steering
{
    /// <summary>
    /// The main form which simulates the ant colony.
    /// </summary>
    public partial class AntFoodForm : Form
    {
        /// <summary>
        /// Store the ant colony size.
        /// </summary>
        private int antColonySize;


        /// <summary>
        /// Store the robber ant colony size.
        /// </summary>
        private int robberAntColonySize;


        /// <summary>
        /// Store the number of food pieces found in each food source.
        /// </summary>
        private int foodPieces;


        /// <summary>
        /// Ant minimum detection distance of other ants in the world, e.g. other ants, nest. 
        /// </summary>
        private double antDetectionRadius;


        /// <summary>
        /// The minimum distance to detect another object such as food/nest in the world.
        /// </summary>
        private double objectDetectionRadius;


        /// <summary>
        /// Continue/Pause simulation.
        /// </summary>
        private bool isSimulationPaused;


        /// <summary>
        /// Declare a colony of normal AntAgents.
        /// </summary>
        private List<AntAgent> antColony;


        /// <summary>
        /// Declare a colony of robber ants under the same AntAgent object.
        /// </summary>
        private List<AntAgent> robberAntColony;


        /// <summary>
        ///  Hold the ant colony nest objects.
        /// </summary>
        private List<Nest> colonyNests;


        /// <summary>
        /// Hold the robber ant colony nest objects.
        /// </summary>
        private List<Nest> colonyRobberNests;

        
        /// <summary>
        /// Store all the food objects available in the colony.
        /// </summary>        
        private List<Food> colonyFoodSources;

        
        /// <summary>
        /// The random object given to each AntAgent object.
        /// </summary>
        private Random randomGenerator;


        /// <summary>
        /// A bitmap image used for double buffering.
        /// </summary>
        private Bitmap backgroundImage;


        /// <summary>
        /// Intialise the form in which world is displayed on.
        /// </summary>
        public AntFoodForm()
        {
            InitializeComponent();

            CreateBackgroundImage();

            CreateAnts();

            // Initialise the essential variables:
            antDetectionRadius = 15.0;

            objectDetectionRadius = 20.0;

            foodPieces = 200;

            colonyFoodSources = new List<Food>();

            colonyNests = new List<Nest>();

            colonyRobberNests = new List<Nest>();
        }


        /// <summary>
        /// Create ants (normal ants and robber ants) based on the 
        /// colony sizes that is specified in the form.
        /// </summary>
        private void CreateAnts()
        {
            Rectangle worldLimits;
            AntAgent nextAntAgent;

            int vectorX;
            int vectorY;

            bool inputSizeValid;

            // Define some world size for the ants to move around on assume the 
            // size of the world is the same size as the panel on which they are displayed.
            worldLimits = new Rectangle(0, 0, drawingPanel.Width, drawingPanel.Height);

            antColony = new List<AntAgent>();

            robberAntColony = new List<AntAgent>();

            // Create a random object to pass to created ants.
            randomGenerator = new Random();

            // Ensure the colony sizes entered are converted from text
            // to integer sucessfully.
            inputSizeValid = false;

            try
            {
                // Get the ant/robber ant colony size.
                antColonySize = Convert.ToInt32(colonySizeTextBox.Text);
                robberAntColonySize = Convert.ToInt32(robberColonySizeTextBox.Text);

                inputSizeValid = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter an integer as the number of normal/robber ants you want to create.", "Ant Colony Simulation - Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (inputSizeValid)
            {
                Debug.WriteLine("Creating {0} ants for the colony.", antColonySize);

                // Loop through the number of ants we need to create.
                for (int antIndex = 0; antIndex < antColonySize; antIndex++)
                {
                    // Set the vector X and vector Y to be randomly generated.
                    // Use next to get a new random number.
                    vectorX = randomGenerator.Next(0, drawingPanel.Width);
                    vectorY = randomGenerator.Next(0, drawingPanel.Height);

                    // Create the AntAgent object for this vector.
                    nextAntAgent = new AntAgent(new SOFT152Vector(vectorX, vectorY), randomGenerator, worldLimits);

                    // Set the properties for the new ant.
                    nextAntAgent.AgentSpeed = 1.5;
                    nextAntAgent.ApproachRadius = 10;

                    antColony.Add(nextAntAgent);
                    Debug.WriteLine("Created new AntAgent (index {0}) at Vector({1}, {2})", antIndex, nextAntAgent.AgentPosition.X, nextAntAgent.AgentPosition.Y);
                }

                Debug.WriteLine("Creating {0} robber ants for the colony.", robberAntColonySize);

                // Loop through the size we want to create and create each ant.
                for (int robberAntIndex = 0; robberAntIndex < robberAntColonySize; robberAntIndex++)
                {
                    vectorX = randomGenerator.Next(0, drawingPanel.Width);
                    vectorY = randomGenerator.Next(0, drawingPanel.Height);

                    // Create the robber ant using the co-ordinates, random object and the bounds of the world.
                    nextAntAgent = new AntAgent(new SOFT152Vector(vectorX, vectorY), randomGenerator, worldLimits);

                    // The speed and approach radius of the robber ant differ from normal ants;
                    // they are to appear more quicker than that of normal ants.
                    nextAntAgent.AgentSpeed = 1.75;
                    nextAntAgent.ApproachRadius = 5;

                    robberAntColony.Add(nextAntAgent);
                    Debug.WriteLine("Created new Robber AntAgent (index {0} at Vector({1}, {2})", robberAntIndex, nextAntAgent.AgentPosition.X, nextAntAgent.AgentPosition.Y);
                }
            }
        }


        /// <summary>
        /// Create the food object given x and y coordinates of the user's mouse click.
        /// </summary>
        /// <param name="positionX">The X co-ordinate of the mouse press and where to create the food source object in x-axis.</param>
        /// <param name="positionY">The Y co-ordinate of the mouse press and where to create the food source object in y-axis.</param>
        private void CreateFoodSource(int positionX, int positionY)
        {
            Food foodSource;

            // Create the new food object with the vector positions.
            foodSource = new Food(new SOFT152Vector(positionX, positionY), foodPieces);

            colonyFoodSources.Add(foodSource);
            Debug.WriteLine("Added new food source at x={0} y={1} to the world.", positionX, positionY);
        }


        /// <summary>
        /// Create the nest object given the x and y coordinates of the user's mouse click.
        /// </summary>
        /// <param name="positionX">The X co-ordinate of the mouse press and where to create the nest object in x-axis.</param>
        /// <param name="positionY">The Y co-ordinate of the mouse press and where to create the nest object in y-axis.</param>
        private void CreateNest(int positionX, int positionY)
        {
            Nest nest;

            // Get the vector object for the new nest and create the nest.
            nest = new Nest(new SOFT152Vector(positionX, positionY));

            colonyNests.Add(nest);
            Debug.WriteLine("Added new nest at x={0} y={1} to the world.", positionX, positionY);
        }


        /// <summary>
        /// Create the robber ant nest object providing the x and y coordinates of the user's mouse click.
        /// </summary>
        /// <param name="positionX">The X co-ordinate of the mouse press and where to create the robber nest object in x-axis.</param>
        /// <param name="positionY">The Y co-ordinate of the mouse press and where to create the robber nest object in y-axis.</param>
        private void CreateRobberNest(int positionX, int positionY)
        {
            Nest robberNest;

            robberNest = new Nest(new SOFT152Vector(positionX, positionY));

            colonyRobberNests.Add(robberNest);
            Debug.WriteLine("Added new robber nest at x={0} y={1} to the world.", positionX, positionY);
        }


        /// <summary>
        ///  Creates the background panel which is used in double buffering 
        ///  all the world objects to the form.
        /// </summary>
        private void CreateBackgroundImage()
        {
            int imageWidth;
            int imageHeight;

            // The background image can be any size assume it is the same size as
            // the panel on which the ants are drawn.
            imageWidth = drawingPanel.Width;
            imageHeight = drawingPanel.Height;

            backgroundImage = new Bitmap(drawingPanel.Width, drawingPanel.Height);
        }


        /// <summary>
        /// The world timer conducts the events of world objects.
        /// This includes ants/robber ants, nests/robber nests and food sources.
        /// </summary>
        private void worldTimer_Tick(object sender, EventArgs e)
        {
            AntAgent currentAnt;

            // Activities for normal AntAgents.
            for (int currentAntIndex = 0; currentAntIndex < antColonySize; currentAntIndex++)
            {
                // Get the current ant.
                currentAnt = antColony.ElementAt(currentAntIndex);

                // Detect food within distance.
                DetectNearestFoodSource(currentAnt);

                // Detect nests within distance.
                DetectNearestNest(currentAnt);

                // Detect the closest ant within the proximity of the current ant.
                DetectClosestAnt(currentAnt, currentAntIndex);
                
                // Allow the current ant to share information.
                ShareInformation(currentAnt);

                // Finally, allow the current ant to make the right action
                // e.g. move randomly or go to nest/food to pickup/deposit food.
                AntAction(currentAnt);
            }


            // Activites for robber AntAgents:
            for (int currentRobberAntIndex = 0; currentRobberAntIndex < robberAntColonySize; currentRobberAntIndex++)
            {
                currentAnt = robberAntColony.ElementAt(currentRobberAntIndex);

                // Detect the nearest robber ant colony nest, helping it deposit food it steals.
                DetectNearestRobberNest(currentAnt);

                // Detect the closest normal ant within the proximity of the robber ant.
                // This will help the robber ant decide who to steal food from.
                DetectClosestAnt(currentAnt, currentRobberAntIndex);

                // Recognise the food location for the robber ant.
                RecogniseClosestAnt(currentAnt);                

                // The ant should now make the correct action based on the updated information.
                RobberAntAction(currentAnt);
            }

            // Draw all the objects onto the world.
            DrawWorldObjects();
        }


        /// <summary>
        /// An ant will be able to detect the closest food source to it.
        /// This is used by normal ants.
        /// </summary>
        /// <param name="ant">The AntAgent object to detect the food source from.</param>
        private void DetectNearestFoodSource(AntAgent ant)
        {
            Food foodSource;

            double distanceToFood;
            double shortestFoodDistance;


            shortestFoodDistance = 0.0;

            for (int foodIndex = 0; foodIndex < colonyFoodSources.Count(); foodIndex++)
            {
                foodSource = colonyFoodSources.ElementAt(foodIndex);

                // Since we are not removing the food source completely, 
                // only check those sources which still have food.
                if (!foodSource.isFoodDepleted)
                {
                    // Get distance from the ant to the food source:
                    distanceToFood = ant.AgentPosition.Distance(foodSource.FoodPosition);

                    if (shortestFoodDistance == 0)
                    {
                        shortestFoodDistance = distanceToFood;
                    }

                    // Assign the new shortest distance if it is in range and if it is smaller than 
                    // or equal to the previous distance:
                    if (distanceToFood <= objectDetectionRadius && distanceToFood <= shortestFoodDistance)
                    {
                        shortestFoodDistance = distanceToFood;

                        // Set the closest food index and location.
                        ant.ClosestFoodIndex = foodIndex;
                        ant.FoodLocation = foodSource.FoodPosition;

                        // The food source is now known to the ant.
                        ant.IsFoodKnown = true;
                    }
                }
            }
        }


        /// <summary>
        /// An ant will be able to detect the closest nest to it; dedicated for normal ants.
        /// </summary>
        /// <param name="ant">The AntAgent object to find the closest normal nest within it's proximity.</param>
        private void DetectNearestNest(AntAgent ant)
        {
            Nest nest;

            double distanceToNest;
            double shortestNestDistance;


            shortestNestDistance = 0.0;

            for (int nestIndex = 0; nestIndex < colonyNests.Count(); nestIndex++)
            {
                nest = colonyNests.ElementAt(nestIndex);

                // Get the distance from the ant to the next.
                distanceToNest = ant.AgentPosition.Distance(nest.NestPosition);

                if (shortestNestDistance == 0)
                {
                    shortestNestDistance = distanceToNest;
                }

                // Assign the new shortest distance if it is within detection distance and
                // it is shorter than any previous distances.
                if (distanceToNest <= objectDetectionRadius && distanceToNest <= shortestNestDistance)
                {
                    shortestNestDistance = distanceToNest;

                    // Assign this nest as the closest and record it's position.
                    ant.ClosestNestIndex = nestIndex;
                    ant.NestLocation = nest.NestPosition;

                    // Make sure the nest is now known to the ant.
                    ant.IsNestKnown = true;
                }
            }
        }


        /// <summary>
        /// Detect the nearest robber ant nest given a robber AntAgent object stored in the robber ant colony.
        /// </summary>
        /// <param name="ant">The AntAgent object to find the closest robber ant nest object within it's proximity.</param>
        private void DetectNearestRobberNest(AntAgent ant)
        {
            Nest robberNest;

            double distanceToNest;
            double shortestNestDance;


            shortestNestDance = 0.0;

            // Loop through the robber ant nest to get the closest robber AntAgent to the given object.
            for (int robberNestIndex = 0; robberNestIndex < colonyRobberNests.Count(); robberNestIndex++)
            {
                robberNest = colonyRobberNests.ElementAt(robberNestIndex);

                distanceToNest = ant.AgentPosition.Distance(robberNest.NestPosition);

                if (shortestNestDance == 0)
                {
                    shortestNestDance = distanceToNest;
                }

                if (distanceToNest <= objectDetectionRadius && distanceToNest <= shortestNestDance)
                {
                    shortestNestDance = distanceToNest;

                    ant.ClosestNestIndex = robberNestIndex;
                    ant.NestLocation = robberNest.NestPosition;

                    ant.IsNestKnown = true;
                }
            }
        }

        
        /// <summary>
        /// Detect the closest AntAgent object to another given AntAgent object.
        /// This method is for the use of both normal ants and robber ants, 
        /// however, the search will always be from the normal ant colony.
        /// </summary>
        /// <param name="ant">The AntAgent object to detect the closest AntAgent within it's detection radius.</param>
        /// <param name="antIndex">The index of the AntAgent within it's own colony (List AntAgent object).</param>
        private void DetectClosestAnt(AntAgent ant, int antIndex)
        {
            AntAgent otherAnt;

            double otherAntDistance;
            double shortestAntDistance;


            shortestAntDistance = 0.0;

            // Allow ants to be detected if they come in close distance of other ants.
            for (int otherAntIndex = 0; otherAntIndex < antColonySize; otherAntIndex++)
            {
                otherAnt = antColony.ElementAt(otherAntIndex);

                // NOTE: Issue when robber ant compared to normal ant colony - avoid choosing the current ant.
                if (antIndex != otherAntIndex)
                {
                    // Debug.WriteLine("Found other ant {0}.", otherAntIndex);

                    // Get the distance from the current ant to the other ant.
                    otherAntDistance = ant.AgentPosition.Distance(otherAnt.AgentPosition);

                    // Set initial distance to work with.
                    if (shortestAntDistance == 0.0)
                    {
                        shortestAntDistance = otherAntDistance;
                    }

                    // Debug.WriteLine("Other ants distance: {0}", otherAntDistance);

                    // Make sure the other ant is within our radius. Allow ant which equals the shortest distance to enter, 
                    // this means the last ant in the radius can communicate.
                    if (otherAntDistance <= antDetectionRadius && otherAntDistance <= shortestAntDistance)
                    {
                        // The current shortest distance will change if the other ant's distance
                        // is smaller than the current shortest distance.
                        shortestAntDistance = otherAntDistance;

                        // Set the closest ant index for the current ant to the index of the other ant.
                        // This allows us to identify which ants should communicate together.

                        // Do not assign the same ant which was approached before.
                        if (ant.ClosestAntIndex != otherAntIndex)
                        {
                            ant.ClosestAntIndex = otherAntIndex;
                            ant.IsNewClosestAnt = true;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Recognise the closest normal ant to a robber AntAgent object
        /// as being a potential food source; robber ant recognises 
        /// normal ant's position as it's food location.
        /// 
        /// The robber ant will only recognise a new food location if it
        /// is not already carrying a piece of food it has not yet deposited.
        /// </summary>
        /// <param name="robberAnt">The robber AntAgent object for which to set its next food location.</param>
        private void RecogniseClosestAnt(AntAgent robberAnt)
        {
            if (robberAnt.IsNewClosestAnt && !robberAnt.IsCarryingFood)
            {
                AntAgent foodAnt;

                foodAnt = antColony.ElementAt(robberAnt.ClosestAntIndex);

                robberAnt.FoodLocation = foodAnt.AgentPosition;
                
                // Set food is known, to allow the robber ant to move to the food ants location.
                robberAnt.IsFoodKnown = true;

                // Allow for the ant to not keep on approaching the same ant.
                robberAnt.IsNewClosestAnt = false;
            }
        }


        /// <summary>
        /// Simulate a conversation between AntAgent object, using their ClosestAntIndex,
        /// to share information of the location of food and/or nest if either has it.
        /// </summary>
        /// <param name="sharingAnt">The AntAgent object which is to communicate with the closest ant to it.</param>
        private void ShareInformation(AntAgent sharingAnt)
        {
            Food sharingAntFoodSource;
            Food receivingAntFoodSource;


            // If there is a new closest ant assigned.
            if (sharingAnt.IsNewClosestAnt)
            {
                AntAgent receivingAnt;
                
                receivingAnt = antColony.ElementAt(sharingAnt.ClosestAntIndex);

                // Share nest location information:
                if (sharingAnt.IsNestKnown && !receivingAnt.IsNestKnown)
                {
                    receivingAnt.NestLocation = sharingAnt.NestLocation;

                    receivingAnt.IsNestKnown = true;
                }
                else if (!sharingAnt.IsNestKnown && receivingAnt.IsNestKnown)
                {
                    sharingAnt.NestLocation = receivingAnt.NestLocation;

                    sharingAnt.IsNestKnown = true;
                }


                // Share food location information if the food source an ant knows is not yet depleted.
                if (sharingAnt.IsFoodKnown && !receivingAnt.IsFoodKnown)
                {
                    sharingAntFoodSource = colonyFoodSources.ElementAt(sharingAnt.ClosestFoodIndex);

                    // Check to see if the food source is depleted before sharing the information.
                    if (!sharingAntFoodSource.isFoodDepleted)
                    {
                        receivingAnt.FoodLocation = sharingAnt.FoodLocation;

                        receivingAnt.IsFoodKnown = true;
                    }
                }
                else if (!sharingAnt.IsFoodKnown && receivingAnt.IsFoodKnown)
                {
                    receivingAntFoodSource = colonyFoodSources.ElementAt(receivingAnt.ClosestFoodIndex);

                    if (!receivingAntFoodSource.isFoodDepleted)
                    {
                        sharingAnt.FoodLocation = receivingAnt.FoodLocation;

                        sharingAnt.IsFoodKnown = true;
                    }
                }


                // Set the new closest ant boolean value to false.
                sharingAnt.IsNewClosestAnt = false;
            }
        }


        /// <summary>
        /// Simulate actions when a normal ant arrives at a food source.
        /// </summary>
        /// <param name="ant">The AntAgent to simulate events at the food source.</param>
        private void FoodAntAction(AntAgent ant)
        {
            Food foodAtLocation;

            foodAtLocation = colonyFoodSources.ElementAt(ant.ClosestFoodIndex);

            ant.IsMovingToFood = false;

            // Make sure food is available at the source before attempting to get food.
            if (!foodAtLocation.isFoodDepleted)
            {
                // Allow the ant to pick up one piece of the food.
                foodAtLocation.TakeFood();

                // Allow the ant to now carry the food to the nest.
                ant.IsCarryingFood = true;
                Debug.WriteLine("An ant took a piece from the food source, remaining pieces = {0}.", foodAtLocation.FoodAvailable);
            }
            else
            {
                // As the food source has been depleted, make sure the ant forgets about this location.
                ant.IsFoodKnown = false;
            }
        }


        /// <summary>
        /// Simulate actions when a robber ant arrives at a food source.
        /// </summary>
        /// <param name="robberAnt">The robber AntAgent to simulate events when it arrives at the food source.</param>
        private void RobberFoodAntAction(AntAgent robberAnt)
        {
            AntAgent foodAnt;

            foodAnt = antColony.ElementAt(robberAnt.ClosestAntIndex);

            robberAnt.IsMovingToFood = false;

            // Allow us to interrogate the ant to determine if it has food to steal.
            if (foodAnt.IsCarryingFood)
            {
                // The robber ant steals the food off the normal ant.
                foodAnt.IsCarryingFood = false;

                robberAnt.IsCarryingFood = true;
                Debug.WriteLine("Robber ant stole a piece of food from a normal ant.");
            }
            else
            {
                // If not, we have not found a possible food source.
                robberAnt.IsFoodKnown = false;
            }
        }


        /// <summary>
        /// Simulate actions when a normal ant arrives at it's nest.
        /// </summary>
        /// <param name="ant">The AntAgent to simulate events when it arrives at it's nest.</param>
        private void NestAntAction(AntAgent ant)
        {
            Nest nestAtLocation;

            nestAtLocation = colonyNests.ElementAt(ant.ClosestNestIndex);

            ant.IsMovingToNest = false;

            // Allow the ant to deposit the food.
            nestAtLocation.DepositFood();
            Debug.WriteLine("An ant deposited a piece of food in the nest. Total food deposited at nest = {0}", nestAtLocation.FoodDeposited);

            // The ant is no longer carrying the food.
            ant.IsCarryingFood = false;
        }


        /// <summary>
        /// Simulate actions when a robber ant arrives at it's nest.
        /// </summary>
        /// <param name="robberAnt">The robber AntAgent to simulate events when it arrives at it's nest.</param>
        private void RobberNestAntAction(AntAgent robberAnt)
        {
            Nest robberNestAtLocation;

            robberNestAtLocation = colonyRobberNests.ElementAt(robberAnt.ClosestNestIndex);

            robberAnt.IsMovingToNest = false;

            // Allow the ant to deposit the food it stole.
            robberNestAtLocation.DepositFood();
            Debug.WriteLine("A robber ant deposited a piece of food in the nest. Total food deposited at robber nest = {0}", robberNestAtLocation.FoodDeposited);

            // The ant is no longer carrying the food.
            robberAnt.IsCarryingFood = false;
        }
        

        /// <summary>
        /// Simulate the generic actions that both normal and robber ants undertake when
        /// they are either wandering around or about to move to food source or nest.
        /// </summary>
        /// <param name="ant">The AntAgent to simulate it's generic actions.</param>
        private void GenericAntAction(AntAgent ant)
        {
            // Based on if the ant is currently carrying food or not.
            if (!ant.IsCarryingFood)
            {
                // If the ant knows where the location of the food is, then go there.
                if (ant.IsFoodKnown)
                    ant.IsMovingToFood = true;
                else
                    ant.Wander();
            }
            // If it is carrying food..
            else
            {
                // ..and if the location of the nest is known, then go there.
                if (ant.IsNestKnown)
                    ant.IsMovingToNest = true;
                else
                    ant.Wander();
            }
        }


        /// <summary>
        /// Conduct the events a normal ant AntAgent object.
        /// The action will be determined based on it's current status (e.g. if it is moving to a food source,
        /// if it is depositing food at a nest).
        /// </summary>
        /// <param name="ant">The AntAgent for which to conduct the appropriate action for (based on it's current status).</param> 
        private void AntAction(AntAgent ant)
        {
            // Based on if the ant is at or moving to food or nest.
            // The ant can be forgetful, so we need to make sure it knows where food is as it moves.
            if (ant.IsMovingToFood && ant.IsFoodKnown)
            {
                ant.Approach(ant.FoodLocation);

                // See if the ant is at the nest or food source currently.
                if (ant.AgentPosition.Distance(ant.FoodLocation) < 1)
                {
                    FoodAntAction(ant);
                }
            }
            else if (ant.IsMovingToNest && ant.IsNestKnown)
            {
                ant.Approach(ant.NestLocation);

                // If the ant is currently at the nest.
                if (ant.AgentPosition.Distance(ant.NestLocation) < 1)
                {
                    NestAntAction(ant);
                }
            }
            else
            {
                GenericAntAction(ant);
            }
        }


        /// <summary>
        /// Conduct the events that a robber AntAgent object undertakes in the ant world.
        /// </summary>
        /// <param name="robberAnt">The robber AntAgent object to undertake the appropriate action in the current condition.</param>
        private void RobberAntAction(AntAgent robberAnt)
        {
            if (robberAnt.IsMovingToFood)
            {
                // Approach location of the target ant with possible food.
                robberAnt.Approach(robberAnt.FoodLocation);

                if (robberAnt.AgentPosition.Distance(robberAnt.FoodLocation) < 5)
                {
                    RobberFoodAntAction(robberAnt);
                }
            }
            else if (robberAnt.IsMovingToNest)
            {
                robberAnt.Approach(robberAnt.NestLocation);

                // If the robber ant is currently at the nest.
                if (robberAnt.AgentPosition.Distance(robberAnt.NestLocation) < 1)
                {
                    RobberNestAntAction(robberAnt);
                }
            }
            else
            {
                GenericAntAction(robberAnt);
            }
        }


        /// <summary>
        /// This timer occurs every 10 seconds and only occurs if the ant is wandering.
        /// </summary>
        private void antMemoryTimer_Tick(object sender, EventArgs e)
        {
            AntAgent currentAnt;

            if (!isSimulationPaused)
            {
                for (int i = 0; i < antColonySize; i++)
                {
                    currentAnt = antColony.ElementAt(i);

                    // The ant may be wandering, have food it is carrying to the nest,
                    // or be on its way to the food source to take food.
                    AntMemoryLoss(currentAnt);
                }
            }
        }


        /// <summary>
        /// Simulate memory loss within ants. The loss of memory for 
        /// the ant can also occur at any random time it is wandering 
        /// (if it has knowledge of food or the nest).
        /// </summary>
        /// <param name="antWithMemory">The AntAgent for which to simulate memory loss.</param>
        private void AntMemoryLoss(AntAgent antWithMemory)
        {
            int randomNum;

            if (antWithMemory.IsNestKnown)
            {
                randomNum = randomGenerator.Next(0, 11);

                // 20% chance of forgetting nest.
                if (randomNum >= 8)
                    antWithMemory.IsNestKnown = false;

                if (antWithMemory.IsFoodKnown)
                {
                    randomNum = randomGenerator.Next(0, 11);

                    // 40% chance of forgetting food.
                    if (randomNum <= 4)
                        antWithMemory.IsFoodKnown = false;
                }
            }

            // Vice versa:
            if (antWithMemory.IsFoodKnown)
            {
                randomNum = randomGenerator.Next(0, 11);

                // 20% chance of forgetting food source.
                if (randomNum >= 8)
                    antWithMemory.IsFoodKnown = false;

                if (antWithMemory.IsNestKnown)
                {
                    randomNum = randomGenerator.Next(0, 11);

                    // 40% chance of forgetting nest.
                    if (randomNum <= 4)
                        antWithMemory.IsNestKnown = false;
                }
            }
        }


        /// <summary>
        /// Draw AntAgent objects and stationary objects (food sources & nests) using double buffering.
        /// </summary>
        private void DrawWorldObjects()
        {
            Brush solidBrush;
            Brush informationBrush;

            AntAgent currentAnt;
            Nest nestToDraw;
            Food foodToDraw;
            Font objectFont;

            int objectWidth;
            int objectHeight;

            float agentXPosition;
            float agentYPosition;
            float antSize;

            antSize = 5.0f;

            objectWidth = 35;
            objectHeight = 35;

            objectFont = new Font("Arial", 10, FontStyle.Bold);

            // Get the graphics context of the background image.
            using (Graphics backgroundGraphics =  Graphics.FromImage(backgroundImage))
            {
                // Initialise the brush to use when drawing 
                // information regarding a specific object.
                informationBrush = new SolidBrush(Color.Black);

                // Clear the background and draw respective objects to the background image.
                backgroundGraphics.Clear(Color.White);

                // Draw the ant colony onto the background:
                for (int antIndex = 0; antIndex < antColonySize; antIndex++)
                {
                    currentAnt = antColony.ElementAt(antIndex);

                    // Get the current ant agent position.
                    agentXPosition = (float)currentAnt.AgentPosition.X;
                    agentYPosition = (float)currentAnt.AgentPosition.Y;

                    // Default brush for a normal ant with no information of the world so far.
                    solidBrush = new SolidBrush(Color.Black);

                    // Create a brush. The color of the ant represents what information the ant knows.
                    if (!currentAnt.IsCarryingFood)
                    {
                        if (currentAnt.IsNestKnown && !currentAnt.IsFoodKnown)
                        {
                            // Ants which are blue know only where the nest is.
                            solidBrush = new SolidBrush(Color.Blue);
                        }
                        else if (!currentAnt.IsNestKnown && currentAnt.IsFoodKnown)
                        {
                            // Ants which are indigo only know where the food is.
                            solidBrush = new SolidBrush(Color.Indigo);
                        }
                        else if (currentAnt.IsNestKnown && currentAnt.IsFoodKnown)
                        {
                            // Ants which are green know locations of the nest and food.
                            solidBrush = new SolidBrush(Color.Green);
                        }
                    }
                    else
                    {
                        // Yellow signifies an Ant which is carring a piece of food, otherwise they are black.
                        solidBrush = new SolidBrush(Color.Yellow);
                    }

                    // draw the agent on the backgroundImage as a square.
                    backgroundGraphics.FillRectangle(solidBrush, agentXPosition, agentYPosition, antSize, antSize);
                }


                // Draw each robber AntAgent object in the robber ant colony.
                for (int antIndex = 0; antIndex < robberAntColonySize; antIndex++)
                {
                    currentAnt = robberAntColony.ElementAt(antIndex);

                    agentXPosition = (float)currentAnt.AgentPosition.X;
                    agentYPosition = (float)currentAnt.AgentPosition.Y;

                    if (!currentAnt.IsCarryingFood)
                    {
                        solidBrush = new SolidBrush(Color.Red);
                    }
                    else
                    {
                        // Stolen food has the colour magenta.
                        solidBrush = new SolidBrush(Color.Magenta);
                    }

                    // Draw the robber ant agent.
                    backgroundGraphics.FillRectangle(solidBrush, agentXPosition, agentYPosition, antSize, antSize);
                }


                // Create the new brush to draw ant nests:
                solidBrush = new SolidBrush(Color.Brown);

                for (int i = 0; i < colonyNests.Count(); i++)
                {
                    nestToDraw = colonyNests.ElementAt(i);

                    // Draw the nest.
                    backgroundGraphics.FillRectangle(solidBrush, (float)nestToDraw.NestPosition.X, (float)nestToDraw.NestPosition.Y, objectWidth, objectHeight);
                    
                    // Draw food deposited at nest.
                    backgroundGraphics.DrawString(nestToDraw.FoodDeposited.ToString(), objectFont, informationBrush, 
                        (float)nestToDraw.NestPosition.X, (float)nestToDraw.NestPosition.Y);
                }


                // Draw the robber ant nests in the world.
                solidBrush = new SolidBrush(Color.DarkGray);

                for (int i = 0; i < colonyRobberNests.Count(); i++)
                {
                    nestToDraw = colonyRobberNests.ElementAt(i);

                    backgroundGraphics.FillRectangle(solidBrush, (float)nestToDraw.NestPosition.X, (float)nestToDraw.NestPosition.Y, objectWidth, objectHeight);

                    // Draw food deposited at robber nest.
                    backgroundGraphics.DrawString(nestToDraw.FoodDeposited.ToString(), objectFont, informationBrush,
                        (float)nestToDraw.NestPosition.X, (float)nestToDraw.NestPosition.Y);
                }


                // Create the new brush to draw food sources:
                solidBrush = new SolidBrush(Color.Yellow);

                for (int i = 0; i < colonyFoodSources.Count(); i++)
                {
                    foodToDraw = colonyFoodSources.ElementAt(i);

                    // Draw the food source if it is not yet depleted.
                    if (!foodToDraw.isFoodDepleted)
                    {
                        backgroundGraphics.FillRectangle(solidBrush, (float)foodToDraw.FoodPosition.X, (float)foodToDraw.FoodPosition.Y, objectWidth, objectHeight);

                        // Draw available food pieces.
                        backgroundGraphics.DrawString(foodToDraw.FoodAvailable.ToString(), objectFont, informationBrush,
                        (float)foodToDraw.FoodPosition.X, (float)foodToDraw.FoodPosition.Y);
                    }
                }
            }


            // Now draw the background image on to the panel.
            using (Graphics g = drawingPanel.CreateGraphics())
            {
                g.DrawImage(backgroundImage, 0, 0, drawingPanel.Width, drawingPanel.Height);
            }
        }


        /// <summary>
        /// Set the amount of pieces of food to be in each food source in the world.
        /// </summary>
        private void setFoodPiecesButton_Click(object sender, EventArgs e)
        {
            try
            {
                foodPieces = Convert.ToInt32(foodPiecesTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter an integer as the amound of pieces of food to be in each food source.",
                    "Set Food Source Quantity - Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Make sure we can create a world objects based on the type of object
        /// that has been selected in the form and the location of the mouse click.
        /// </summary>
        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // The location of where the mouse was clicked will allow us 
            // to create the object in that position.
            Point mouseLocation;

            mouseLocation = e.Location;

            // Proceed based on the type of object that was checked on the form:
            if (foodSourceRadioButton.Checked)
            {
                CreateFoodSource(mouseLocation.X, mouseLocation.Y);
                Debug.WriteLine("Created food source object at x={0} y={1}.", mouseLocation.X, mouseLocation.Y);
            }
            else if (antNestRadioButton.Checked)
            {
                CreateNest(mouseLocation.X, mouseLocation.Y);
                Debug.WriteLine("Created ant nest object at x={0} y={1}.", mouseLocation.X, mouseLocation.Y);
            }
            else if (robberNestRadioButton.Checked)
            {
                CreateRobberNest(mouseLocation.X, mouseLocation.Y);
                Debug.WriteLine("Created robber ant nest object at x={0} y={1}.", mouseLocation.X, mouseLocation.Y);
            }
        }


        /// <summary>
        /// Event handler to handle the click of the start button.
        /// Allow to reset the world and start the simulation again.
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            isSimulationPaused = false;

            // Clear the set of ants.
            antColony.Clear();

            robberAntColony.Clear();

            // Re-draw the objects.
            CreateAnts();

            // Clear the set of nests & food sources.
            colonyNests.Clear();

            colonyRobberNests.Clear();

            colonyFoodSources.Clear();

            // Start the timer again.
            worldTimer.Start();

            // Start the ant memory timer.
            antMemoryTimer.Start();
        }


        /// <summary>
        /// Event handler to handle the pause/resume button click.
        /// Results in either a pause or resume of the world simulation.
        /// </summary>
        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            if (!isSimulationPaused)
            {
                // Stop ant memory timer.
                antMemoryTimer.Stop();

                // Stop the timer, freezing all objects.
                worldTimer.Stop();
            }
            else
            {
                // Start the timer again.
                worldTimer.Start();

                // Start ant memory timer again:
                antMemoryTimer.Start();
            }

            // NOT the boolean event to handle another click of the pause button;
            // results in a pause or resume action. 
            isSimulationPaused = !isSimulationPaused;
        }
    }
}
