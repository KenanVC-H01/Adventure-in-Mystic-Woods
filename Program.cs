class MysticWoodsAdventure
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to The Adventure of the Mystic Woods");
        Console.WriteLine();
        Console.WriteLine("In the realm of the forgotten, shrouded in the veils of mist and legend, lies the enigmatic expanse known as the Mystic Woods. For centuries, tales of a legendarytreasure hidden deep within its heart have lured adventurers from far and wide, yet none have returned to tell the tale of its wonders or woes. It is here, at thevery threshold of these ancient woods, that your story begins.");

        Console.WriteLine();
        Console.WriteLine("Press ENTER to start!");
        Console.ReadLine();

        Console.WriteLine("As you stand at the edge of the Mystic Woods,");
        Console.WriteLine("rumors of an ancient treasure fill your mind.");
        Console.WriteLine("What is your name, brave adventurer?");

        Console.WriteLine();
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine()!;

        Console.WriteLine();
        Console.WriteLine($"Welcome, {playerName}, let your adventure begin!");
        Console.WriteLine();

        // Create a player character
        PlayerCharacter player = new PlayerCharacter(playerName, 100);

        // Now, let the player start exploring the woods
        ExploreWoods(player);
    }

    static void ExploreWoods(PlayerCharacter player)
    {
        Console.WriteLine("You stand at a crossroad within the Mystic Woods.");
        Console.WriteLine("Which path will you take?");
        Console.WriteLine();
        Console.WriteLine("1. Follow the winding path deeper into the woods.");
        Console.WriteLine("2. Venture off the beaten path into the shadowy underbrush.");

        string choice = Console.ReadLine()!;

    if (choice == "1")
    {
        // Follow the winding path
        Console.WriteLine();
        Console.WriteLine("You decide to follow the winding path deeper into the woods.");
        Path1(player);
    }
    else if (choice == "2")
    {
        // Venture off the beaten path
        Console.WriteLine();
        Console.WriteLine("You decide to venture off the beaten path into the shadowy underbrush.");
        Path2(player);
    }

    else
    {
        // Invalid choice
        Console.WriteLine();
        Console.WriteLine("Invalid choice. Please enter '1' or '2'.");
        ExploreWoods(player); // Restart the exploration
    }
}

    static void Path1(PlayerCharacter player)
{
    // Logic for path 1
    Console.WriteLine();
    Console.WriteLine("As you journey deeper into the woods, you stumble upon an old chest hidden beneath a pile of leaves.");
    Console.WriteLine("You open the chest and find a shining golden key inside.");
    Console.WriteLine("Congratulations! You've found a golden key!");

    // Add the golden key to the player's inventory
    player.AddToInventory("Golden Key");

    Console.WriteLine(); 
    Console.WriteLine("Press ENTER to continue.");
    Console.ReadLine();
    
    // Continue exploring
    Path3(player);
}

static void Path2(PlayerCharacter player)
{
    // Logic for path 2
    Console.WriteLine();
    Console.WriteLine("You venture into the shadowy underbrush, the dense foliage obscuring your vision.");
    Console.WriteLine("Suddenly, you hear a rustling noise behind you.");

    // Encounter a trap
    Console.WriteLine();
    Console.WriteLine("You've encountered a hidden trap! A giant net falls from above, trapping you.");
    Console.WriteLine("You get hurt and lose 20HP.");

    Console.WriteLine(); 
    Console.WriteLine("Press ENTER to continue.");
    Console.ReadLine();

    // Decrease player's health due to trap
    player.TakeDamage(20); // Example: Player loses 20 health due to trap

    // Check player's health after encountering the trap
    if (player.Health <= 0)
    {
        // Player's health reaches 0 or below
        Console.WriteLine("Oh no! Your health has depleted. You lose!");
        return;
    }

    // Continue exploring
    Path3(player);
}

static void Path3(PlayerCharacter player)
{
    // Check if the player has the golden key
    if (player.Inventory.Contains("Golden Key"))
    {
        Console.WriteLine("You come across a sturdy wooden door with a golden lock.");
        Console.WriteLine("You use the golden key to unlock the door, You've unlocked the door and continue your journey!");
        Castle(player);
    }

    else
    {
        Console.WriteLine("You come across a sturdy wooden door with a golden lock. It seems to require a special key to unlock it.");
        Console.WriteLine("Unfortunately, you don't have the key to unlock the door.");
        Console.WriteLine("You'll need to find the golden key to proceed.");

        Console.WriteLine();
        Console.WriteLine("You hear something growling behind you.");
        Console.WriteLine("A furry creature lunges from the shadows and instantly kills you!");

    // Decrease player's health due to furry creature's attack
    player.TakeDamage(80); // Example: Player loses 80 health due to furry creature's attack

    // Check player's health after furry creature's attack
    if (player.Health <= 0)
      {
        // Player's health reaches 0 or below
        Console.WriteLine();
        Console.WriteLine("Game over!");
        Console.WriteLine();
        return;
      }
   } 
}

// Introductory stage of the castle hallway
static void Castle(PlayerCharacter player)
{
    Console.WriteLine();
    Console.WriteLine("You hear something growling behind you.");
    Console.WriteLine("A furry creature lunges from the shadows and tries to kill you!");

    Console.WriteLine("But you quickly shut the door behind you before the creature can get to you!");
    Console.WriteLine("You take a deep sigh and look around you.");

    Console.WriteLine(); 
    Console.WriteLine("Press ENTER to continue.");
    Console.ReadLine();

    Console.WriteLine("You have entered into what seems to be a rundown castle with three paths ahead of you.");
    Console.WriteLine("Where do you go?");
    Console.WriteLine("1. On your left is a gate with vines surrounding it.");
    Console.WriteLine("2. Straight ahead is a golden door");
    Console.WriteLine("3. On your right is a hatch on the floor.");

    string choice = Console.ReadLine()!;

    if (choice == "1")
    {
        // Go through the vine covered gate
        Console.WriteLine();
        Console.WriteLine("You decide to go through the gate covered with vines.");
        MazePath(player);
    }

    else if (choice == "2")
    {
        // Go through the golden door
        Console.WriteLine();
        Console.WriteLine("You decide to go through the golden door.");
        TreasureRoom(player);
    }

    else if (choice == "3")
    {
        // Go through the hatch on the floor
        Console.WriteLine();
        Console.WriteLine("You decide to go through the hatch on the floor.");
        DungeonPath(player);
    }

    else
    {
        // Invalid choice
        Console.WriteLine();
        Console.WriteLine("Invalid choice. Please enter '1', '2' or '3'.");
        CastleHallway(player); // Restart the scenario
    }
}

// Looping stage of the castle hallway
static void CastleHallway(PlayerCharacter player)
{
    Console.WriteLine("Where do you go?");
    Console.WriteLine("1. On your left is a gate with vines surrounding it.");
    Console.WriteLine("2. Straight ahead is a golden door");
    Console.WriteLine("3. On your right is a hatch on the floor.");

    string choice = Console.ReadLine()!;

    if (choice == "1")
    {
        // Check if the player knows the "KAZAAM" phrase
        if (player.Inventory.Contains("KAZAAM"))
        {
            Console.WriteLine();
            Console.WriteLine("The gate has been completely covered with vines, making it inaccessible. You can't go in there anymore.");
            // Return to the castle hallway
            CastleHallway(player);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You decide to go through the gate covered with vines.");
            // Proceed to the maze path
            MazePath(player);
        }
    }

    else if (choice == "2")
    {
        // Check if the player has beaten the guardian
        if (player.Inventory.Contains("Guardian Trophy"))
        {
           GameFinale(player);
        }
        else
        {
            // Go through the golden door
            Console.WriteLine();
            Console.WriteLine("You decide to go through the golden door.");
            TreasureRoom(player);
        }
    }

    else if (choice == "3")
    {
        // Check if the player has the sword in their inventory
        if (player.Inventory.Contains("Sword"))
        {
            Console.WriteLine();
            Console.WriteLine("You've already shut the hatch and it is now inaccessible. Also because skeletons are dangerous you know?");
            // Return to the castle hallway
            CastleHallway(player);
        }
        else
        {
            // Go through the hatch on the floor
            Console.WriteLine();
            Console.WriteLine("You decide to go through the hatch on the floor.");
            DungeonPath(player);
        }
    }

    else
    {
        // Invalid choice
        Console.WriteLine();
        Console.WriteLine("Invalid choice. Please enter '1', '2' or '3'.");
        CastleHallway(player); // Restart the scenario
    }
}

static void MazePath(PlayerCharacter player)
{
        Console.WriteLine();
        Console.WriteLine("As you walk past the gate, it suddenly slams itself shut! The gate can't be opened anymore.");
        Console.WriteLine("You look ahead and see a garden maze. You need to try and find your way out of this maze.");

        ExploreMaze(player);

        // After completing the maze, return to the castle hallway
        CastleHallway(player);

    static void ExploreMaze(PlayerCharacter player)
    {
        // Start exploring the maze
        bool foundExit = false;
        int moves = 0; // Keep track of the number of moves
        Random random = new Random(); // Initialize random number generator

        while (!foundExit)
        {
            Console.WriteLine("\nChoose your direction:");
            Console.WriteLine("1. Go North");
            Console.WriteLine("2. Go East");
            Console.WriteLine("3. Go South");
            Console.WriteLine("4. Go West");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You move North...");
                    // Simulate different outcomes for going North
                    int northOutcome = random.Next(3); // Generate a random number from 0 to 2
                    if (northOutcome == 0)
                    {
                        Console.WriteLine("You find a path and continue North.");
                    }
                    else
                    {
                        Console.WriteLine("You get attacked by thorns while proceeding North. You lose 10 HP!");
                        // Decrease player's health due to the thorns
                        player.TakeDamage(10); // Example: Player loses 10 health due to the thorns

                        // Check player's health after encountering the trap
                        if (player.Health <= 0)
                        {
                            // Player's health reaches 0 or below
                            Console.WriteLine("You got pierced to death by thorns. Game over!");
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("You move East...");
                    // Simulate different outcomes for going East
                    int eastOutcome = random.Next(3); // Generate a random number from 0 to 2
                    if (eastOutcome == 0)
                    {
                        Console.WriteLine("You find a path and continue East.");
                    }
                    else
                    {
                        Console.WriteLine("You get attacked by thorns while proceeding East. You lose 10 HP!");
                        // Decrease player's health due to the thorns
                        player.TakeDamage(10); // Example: Player loses 10 health due to the thorns

                        // Check player's health after encountering the trap
                        if (player.Health <= 0)
                        {
                            // Player's health reaches 0 or below
                            Console.WriteLine("You got pierced to death by thorns. Game over!");
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("You move South...");
                    // Simulate different outcomes for going South
                    int southOutcome = random.Next(3); // Generate a random number from 0 to 2
                    if (southOutcome == 0)
                    {
                        Console.WriteLine("You find a path and continue South.");
                    }
                    else
                    {
                        Console.WriteLine("You get attacked by thorns while proceeding South. You lose 10 HP!");
                        // Decrease player's health due to the thorns
                        player.TakeDamage(10); // Example: Player loses 10 health due to the thorns

                        // Check player's health after encountering the trap
                        if (player.Health <= 0)
                        {
                            // Player's health reaches 0 or below
                            Console.WriteLine("You got pierced to death by thorns. Game over!");
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("You move West...");
                    // Simulate different outcomes for going West
                    int westOutcome = random.Next(3); // Generate a random number from 0 to 2
                    if (westOutcome == 0)
                    {
                        Console.WriteLine("You find a path and continue West.");
                    }
                    else
                    {
                         Console.WriteLine("You get attacked by thorns while proceeding West. You lose 10 HP!");
                        // Decrease player's health due to the thorns
                        player.TakeDamage(10); // Example: Player loses 10 health due to the thorns

                        // Check player's health after encountering the trap
                        if (player.Health <= 0)
                        {
                            // Player's health reaches 0 or below
                            Console.WriteLine();
                            Console.WriteLine("You got pierced to death by thorns. Game over!");
                            Environment.Exit(0);
                        }
                    }
                    break;
            }

            // Increment the number of moves
            moves++;

            // Check if the player has found the exit
            // For demonstration purposes, let's assume the exit is found after 10 moves
            if (moves >= 6)
            {
                foundExit = true;

            // Make the player remember the "KAZAAM" phrase for later use
            player.AddToInventory("KAZAAM");
            
            Console.WriteLine(); 
            Console.WriteLine("You finally find something, it's a pedestal with what seems to be a glowing message on it!");
            Console.WriteLine("The message reads:");
            Console.WriteLine("You shall reap the rewards of the treasure by uttering the word: KAZAAM.");

            Console.WriteLine(); 
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.WriteLine("After reading the message, a glowing light envelops you and transports you back to the castle hallway.");
            Console.WriteLine(); 
            }
        } 
    }
}

static void TreasureRoom(PlayerCharacter player)
{
    // Check if the player has a sword in their inventory
    if (player.Inventory.Contains("Sword"))
    {
        Console.WriteLine("You enter the treasure room and you see a guardian standing in front of the treasure chest!");
        Console.WriteLine("The guardian must be defeated in order to get to the treasure, you ready your sword for this final battle!");
    
    // Initialize guardian variables
        int guardianHealth = 150; // Example: Guardian health
        int playerHealth = player.Health; // Player health from PlayerCharacter class

        // Start the combat loop
        while (guardianHealth > 0 && player.Health > 0)
        {
            // Prompt the player to choose an action
            Console.WriteLine();
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");

            string action = Console.ReadLine()!;

            // Simulate guardian's attack
            int guardianAttack = new Random().Next(15, 26); // Random number between 15 and 25
            int playerDefense = new Random().Next(5, 16); // Random number between 5 and 15
            int damageTaken = guardianAttack - playerDefense;

            // Process player's action
            switch (action)
            {
                case "1": // Player chooses to attack
                    // Simulate attack success rate
                    int attackOutcome = new Random().Next(1, 4); // Random number between 1 and 3
                    if (attackOutcome == 1 || attackOutcome == 2) // 2/3 chance of successful attack
                    {
                        Console.WriteLine("You successfully strike the guardian!");
                        guardianHealth -= 25; // Example: Guardian loses 25 health per successful attack
                    }
                    else
                    {
                        Console.WriteLine("Your attack misses!");
                    }
                    break;
                case "2": // Player chooses to defend
                    if (damageTaken > 0)
                    {
                        player.Health -= damageTaken;
                        Console.WriteLine($"The guardian strikes you, dealing {damageTaken} damage!");
                    }
                    else
                    {
                        Console.WriteLine("You successfully defend against the guardian's attack!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid action. Please choose '1' or '2'.");
                    continue;
            }

            // Check if either the player or the guardian is defeated
            if (guardianHealth <= 0)
            {
                // Give the player the guardian trophy as proof of defeating it
                player.AddToInventory("Guardian Trophy");

                Console.WriteLine("You have defeated the guardian victoriously!");
                Console.WriteLine();
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine("The guardian overwhelms you and you perish in the treasure room. Game over!");
                Environment.Exit(0);
            }
        }
          // Initialize the finale segment of the game.
          GameFinale(player);
    }

    else
    {
        Console.WriteLine();
        Console.WriteLine("You enter the treasure room and you see a guardian standing in front of the treasure chest!");
        Console.WriteLine("The guardian must be defeated in order to get to the treasure, but you do not have a weapon!");
        
        Console.WriteLine();
        Console.WriteLine("Are you sure you want to proceed? (yes/no)");
        string guardianWarning = Console.ReadLine()!.ToLower();

        if (guardianWarning == "yes")
        {
            Console.WriteLine();
            Console.WriteLine("You attempt to approach, but the guardian strikes you down with a swift blow.");
             // Decrease player's health due to guardian attack
             player.TakeDamage(100); // Example: Player loses 100 health due to guardian attack

            // Check player's health after guardian attack
            if (player.Health <= 0)
            {
            // Player's health reaches 0 or below
            Console.WriteLine();
            Console.WriteLine("Game over!");
            Console.WriteLine();
            return;
            }
        }
        else if (guardianWarning == "no")
        {
            Console.WriteLine();
            Console.WriteLine("You wisely step away and head back to the castle hallway.");
            Console.WriteLine();
            CastleHallway(player); // Return to the  castle hallway
            return;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid choice. Please enter 'yes' or 'no'.");
            // Restart the scenario
            TreasureRoom(player);
        }
    }
}

static void DungeonPath(PlayerCharacter player)
{
    Console.WriteLine();
    Console.WriteLine("You climb down the ladder and discover a dungeon.");
    Console.WriteLine("A lot of skeletons are laying around on the floor, with a sword next to one of them.");
    Console.WriteLine("You pick up the sword!");

    // Add the sword to the player's inventory
    player.AddToInventory("Sword");

    Console.WriteLine(); 
    Console.WriteLine("Press ENTER to continue.");
    Console.ReadLine();
    Console.WriteLine("Suddenly three of the skeletons come alive and block your way back to the castle hallway!");
    Console.WriteLine("Holding your sword, you get ready for a battle!");

        // Initialize skeleton variables
    int skeletonHealth = 100; // Example: Skeleton health
    int playerHealth = player.Health; // Player health from PlayerCharacter class

    // Start the combat loop
    while (skeletonHealth > 0 && player.Health > 0)
    {
        // Prompt the player to choose an action
        Console.WriteLine();
        Console.WriteLine("Choose your action:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Defend");

        string action = Console.ReadLine()!;

        // Simulate skeleton's attack
        int skeletonAttack = new Random().Next(10, 21); // Random number between 10 and 20
        int playerDefense = new Random().Next(5, 16); // Random number between 5 and 15
        int damageTaken = skeletonAttack - playerDefense;

        // Process player's action
        switch (action)
        {
            case "1": // Player chooses to attack
                // Simulate attack success rate
                int attackOutcome = new Random().Next(1, 4); // Random number between 1 and 3
                if (attackOutcome == 1 || attackOutcome == 2) // 2/3 chance of successful attack
                {
                    Console.WriteLine("You successfully strike the skeletons!");
                    skeletonHealth -= 20; // Example: Skeleton loses 20 health per successful attack
                }
                else
                {
                    Console.WriteLine("Your attack misses!");
                }
                break;
            case "2": // Player chooses to defend
                if (damageTaken > 0)
                {
                    player.Health -= damageTaken;
                    Console.WriteLine($"The skeletons strikes you, dealing {damageTaken} damage!");
                }
                else
                {
                    Console.WriteLine("You successfully defend against the skeleton's attack!");
                }
                break;
            default:
                Console.WriteLine("Invalid action. Please choose '1' or '2'.");
                continue;
        }

        // Check if either the player or the skeleton is defeated
        if (skeletonHealth <= 0)
        {
            Console.WriteLine("You defeated the skeletons and emerge victorious!");
            Console.WriteLine();
            Console.WriteLine("However the rest of the skeletons in the dungeon starts to come alive as well!");
            Console.WriteLine("You quickly climb up the ladder and close the hatch shut! You return to the castle hallway.");
        }
        else if (player.Health <= 0)
        {
            Console.WriteLine("The skeletons overwhelm you and you perish in the dungeon. Game over!");
            Environment.Exit(0);
        }
    }

    // Return to the castle hallway after combat
    CastleHallway(player);
}

static void GameFinale(PlayerCharacter player)
{
        // Check if the player knows the "KAZAAM" phrase
        if (player.Inventory.Contains("KAZAAM"))
    {
        Console.WriteLine();
        Console.WriteLine("As you finally approach the treasure chest, you remember the words you read on the pedestal.");
        Console.WriteLine("You shout 'KAZAAM', and the treasure chest slowly opens up revealing the treasure of the Mystic Woods!");

        Console.WriteLine();
        Console.WriteLine("Congratulations! You have completed The Adventure of the Mystic Woods! Thanks for playing!");
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("As you finally approach the treasure chest, you unfortunately realize that you can't open the chest.");
        Console.WriteLine("There is no keyhole, and the chest remains shut when you try to open it.");
        Console.WriteLine("You need to go back and find something that can open this chest.");
        
        // Return to the castle hallway
        CastleHallway(player);
    }
}

class PlayerCharacter
{
    public string Name { get; }
    public int Health { get; set; }
    public List<string> Inventory { get; } // List to store items

    public PlayerCharacter(string name, int health)
    {
        Name = name;
        Health = health;
        Inventory = new List<string>();
    }

     public void AddToInventory(string item)
    {
        Inventory.Add(item); // Add item to the inventory
    }

    public void ShowInventory()
    {
        Console.WriteLine($"Inventory of {Name}:");
        foreach (var item in Inventory)
        {
            Console.WriteLine(item);
        }
    }

    // Method to reduce player's health when they take damage
    public void TakeDamage(int damage)
    {
        Health -= damage;

        // Ensure health does not go below 0
        if (Health < 0)
        {
            Health = 0;
        }
    }
  }
}