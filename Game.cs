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
            public string _playerName;
            public int _playerHealth;
            public int _playerDamage;
            public int _playerDefense;
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
                //PlayerShop();
            }
        }

        public void End()
        {
            if(player1._playerHealth <= 0)
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
            player1._playerName = "Player1";
            player1._playerDefense = 10;
            player1._playerHealth = 100;
            player1._playerDamage = 0;
            player2._playerName = "Player2";
            player2._playerDefense = 10;
            player2._playerHealth = 100;
            player2._playerDamage = 0;
        }

        //Initializes any items.
        void InitializeItems()
        {
            longsword.itemName = "Longsword";
            longsword.itemDamage = 25;
            broadsword.itemName = "Broadsword";
            broadsword.itemDamage = 15;
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
                player1._playerDamage = longsword.itemDamage;
            }
            else
            {
                player1._playerDamage = broadsword.itemDamage;
            }

            Console.Clear();
            GetInput(out input, "Longsword", "Broadsword", "Welcome Player2, pick a weapon!");
            if (input == '1')
            {
                player2._playerDamage = longsword.itemDamage;
            }
            else
            {
                player2._playerDamage = broadsword.itemDamage;
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
            while (player1._playerHealth > 0 && player2._playerHealth > 0)
            {
                //Displays both of the players stats on the screen
                Console.Clear();
                PrintPlayerStats(player1._playerName, player1._playerHealth, player1._playerDamage, player1._playerDefense);
                PrintPlayerStats(player2._playerName, player2._playerHealth, player2._playerDamage, player2._playerDefense);

                //Both players are given the option to either attack or defend.
                char input = ' ';
                GetInput(out input, "Attack", "Defend", "\nWhat would you like to do " + player1._playerName + "?");
                if (input == '1')
                {
                    BlockAttack(ref player2._playerHealth, player1._playerDamage, player2._playerDefense);
                    Console.WriteLine("\n" + player1._playerName + " delt " + (player1._playerDamage - player2._playerDefense) + " damage to " + player2._playerName);
                    Console.WriteLine("\nPress Enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(input == '2')
                {
                    BlockAttack(ref player1._playerHealth, player2._playerDamage, player1._playerDefense);
                    Console.WriteLine("\n" + player1._playerName + " blocked " + (player2._playerDamage - player1._playerDefense) + " damage from " + player2._playerName);
                    Console.WriteLine("\nPress Enter to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                //These are called again to keep th eplayer stats updated as the fight goes on.
                PrintPlayerStats(player1._playerName, player1._playerHealth, player1._playerDamage, player1._playerDefense);
                PrintPlayerStats(player2._playerName, player2._playerHealth, player2._playerDamage, player2._playerDefense);

                GetInput(out input, "Attack", "Defend", "\nWhat would you like to do " + player2._playerName + "?");
                if(input == '1')
                {
                    BlockAttack(ref player1._playerHealth, player2._playerDamage, player1._playerDefense);
                    Console.WriteLine("\n" + player2._playerName + " delt " + (player2._playerDamage - player1._playerDefense) + " damage to " + player1._playerName);
                    Console.WriteLine("\nPress Enter to continue");
                    Console.ReadKey();
                }
                else if(input == '2')
                {
                    BlockAttack(ref player2._playerHealth, player1._playerDamage, player2._playerDefense);
                    Console.WriteLine("\n" + player2._playerName + " blocked " + (player1._playerDamage - player2._playerDefense) + " damage from " + player1._playerName);
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
                player1._playerDamage += 20;
            }
            else
            {
                player1._playerDefense += 10;
                player1._playerName += 5;
            }
            Console.Clear();
            GetInput(out input, "Whetstone", "Adamite Potion", "Player 2, choose and item.");
            if (input == '1')
            {
                player2._playerDamage += 20;
            }
            else
            {
                player2._playerDefense += 10;
                player2._playerName += 5;
            }

        }
    }
}
