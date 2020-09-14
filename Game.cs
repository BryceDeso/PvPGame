using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        //Used to set a playable characters stats
        struct Player
        {
            public string playerName;
            public int playerHealth;
            public int playerDamage;
            public int playerDefense;
        }

        //Used to set an items stats
        struct Item
        {
            public string itemName;
            public int itemDamage;
        }

        bool _gameOver = false;
        Player player1;
        Player player2;
        public int levelScaleMax;
        Item longsword;
        Item broadsword;

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        public void Start()
        {
            InitializeCharacters();
            InitializeItems();
            Console.WriteLine("Welcome warriors! Press Enter to begin!");
            Console.ReadKey();
        }

        public void Update()
        {
            EquipWeapon();
            for(int i = 0; i < 5; i++)
            {
                PlayerFight();
                PlayerShop();
            }
        }

        public void End()
        {
            if(player1.playerHealth <= 0)
            {
                Console.WriteLine("Congratulations Player2, you win!");
            }
            else
            {
                Console.WriteLine("Congratulations Player1, you win!");
            }
        }

        //Initializes two playable characters
        void InitializeCharacters()
        {
            player1.playerName = "Player1";
            player1.playerDefense = 10;
            player1.playerHealth = 100;
            player1.playerDamage = 0;
            player2.playerName = "Player2";
            player2.playerDefense = 10;
            player2.playerHealth = 100;
            player2.playerDamage = 0;
        }

        //Initializes any items.
        void InitializeItems()
        {
            longsword.itemName = "Longsword";
            longsword.itemDamage = 15;
            broadsword.itemName = "Broadsword";
            broadsword.itemDamage = 10;
        }

        //Gets input from the player
        void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }

        }

        //Allows the player to select and equip a weapon.
        void EquipWeapon()
        {
            Console.Clear();
            char input;
            GetInput(out input, "Longsword", "Broadsword", "Welcome Player1, pick a weapon!");
            if (input == '1')
            {
                player1.playerDamage = longsword.itemDamage;
            }
            else
            {
                player1.playerDamage = broadsword.itemDamage;
            }

            Console.Clear();
            GetInput(out input, "Longsword", "Broadsword", "Welcome Player2, pick a weapon!");
            if (input == '1')
            {
                player2.playerDamage = longsword.itemDamage;
            }
            else
            {
                player2.playerDamage = broadsword.itemDamage;
            }

        }

        //Prints out the players stats
        void PrintPlayerStats(string playerName, int playerHealth, int playerDamage, int playerDefense)
        {
            Console.WriteLine("\n" + playerName);
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Damage: " + playerDamage);
            Console.WriteLine("Defense: " + playerDefense);
        }

        //Decreases the attack value of an incoming attack
        void BlockAttack(ref int opponentHealth, int attackVal, int opponentDefense)
        {
            int damage = attackVal -= opponentDefense;
            if(damage < '0')
            {
                damage = 0;
            }

            opponentHealth -= damage;
        }

        //This is where the players fight
        void PlayerFight()
        {
            while (player1.playerHealth > 0 && player2.playerHealth > 0)
            {
                //Displays both of the players stats on the screen
                Console.Clear();
                PrintPlayerStats(player1.playerName, player1.playerHealth, player1.playerDamage, player1.playerDefense);
                PrintPlayerStats(player2.playerName, player2.playerHealth, player2.playerDamage, player2.playerDefense);

                //Both players are given the option to either attack or defend.
                char input = ' ';
                GetInput(out input, "Attack", "Defend", "\nWhat would you like to do " + player1.playerName + "?");
                if (input == '1')
                {
                    BlockAttack(ref player2.playerHealth, player1.playerDamage, player2.playerDefense);
                    Console.WriteLine("\n" + player1.playerName + " delt " + (player1.playerDamage - player2.playerDefense) + " damage to " + player2.playerName);
                    Console.WriteLine("\nPress Enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(input == '2')
                {
                    BlockAttack(ref player1.playerHealth, player2.playerDamage, player1.playerDefense);
                    Console.WriteLine("\n" + player1.playerName + " blocked " + (player2.playerDamage - player1.playerDefense) + " damage from " + player2.playerName);
                    Console.WriteLine("\nPress Enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                //These are called again to keep th eplayer stats updated as the fight goes on.
                PrintPlayerStats(player1.playerName, player1.playerHealth, player1.playerDamage, player1.playerDefense);
                PrintPlayerStats(player2.playerName, player2.playerHealth, player2.playerDamage, player2.playerDefense);

                GetInput(out input, "Attack", "Defend", "\nWhat would you like to do " + player2.playerName + "?");
                if(input == '1')
                {
                    BlockAttack(ref player1.playerHealth, player2.playerDamage, player1.playerDefense);
                    Console.WriteLine("\n" + player2.playerName + " delt " + (player2.playerDamage - player1.playerDefense) + " damage to " + player1.playerName);
                    Console.WriteLine("\nPress Enter to continue");
                    Console.ReadKey();
                }
                else if(input == '2')
                {
                    BlockAttack(ref player2.playerHealth, player1.playerDamage, player2.playerDefense);
                    Console.WriteLine("\n" + player2.playerName + " blocked " + (player1.playerDamage - player2.playerDefense) + " damage from " + player1.playerName);
                    Console.WriteLine("\nPress Enter to continue");
                    Console.ReadKey();
                }

                _gameOver = true;

            }
        }

        //This puts both players into an upgrade shop where they can choose what they want to upgrade.
        void PlayerShop()
        {
            Console.Clear();
            Console.WriteLine("Welcome players! Please pick an item of your choosing!");
            char input = ' ';
            GetInput(out input, "Whetstone", "Adamite Potion", "Player 1, choose and item.");
            if (input == '1')
            {
                player1.playerDamage += 20;
            }
            else
            {
                player1.playerDefense += 10;
                player1.playerHealth += 5;
            }
            Console.Clear();
            GetInput(out input, "Whetstone", "Adamite Potion", "Player 2, choose and item.");
            if (input == '1')
            {
                player2.playerDamage += 20;
            }
            else
            {
                player2.playerDefense += 10;
                player2.playerHealth += 5;
            }

        }
    }
}
