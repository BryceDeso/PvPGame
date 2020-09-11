using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        struct Player
        {
            public string playerName;
            public int playerHealth;
            public int playerDamage;
            public int playerDefense;
        }

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
            PlayerFight();
            PlayerShop();
        }

        public void End()
        {

        }

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

        void InitializeItems()
        {
            longsword.itemName = "Longsword";
            longsword.itemDamage = 15;
            broadsword.itemName = "Broadsword";
            broadsword.itemDamage = 10;
        }

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

        void EquipWeapon()
        {
            Console.Clear();
            char input;
            GetInput(out input, "Longsword", "Broadsword", "Welcome player1, pick a weapon!");
            if (input == '1')
            {
                player1.playerDamage = longsword.itemDamage;
            }
            else
            {
                player1.playerDamage = broadsword.itemDamage;
            }

            Console.Clear();
            GetInput(out input, "Longsword", "Broadsword", "Welcome player2, pick a weapon!");
            if (input == '1')
            {
                player2.playerDamage = longsword.itemDamage;
            }
            else
            {
                player2.playerDamage = broadsword.itemDamage;
            }

        }

        void PrintPlayerStats(string playerName, int playerHealth, int playerDamage, int playerDefense)
        {
            Console.WriteLine(playerName);
            Console.WriteLine(playerHealth);
            Console.WriteLine(playerDamage);
            Console.WriteLine(playerDefense);
        }

        void PlayerFight()
        {
            while (player1.playerHealth > 0 && player2.playerHealth > 0)
            {
                Console.Clear();
                PrintPlayerStats(player1.playerName, player1.playerHealth, player1.playerDamage, player1.playerDefense);
                PrintPlayerStats(player2.playerName, player2.playerHealth, player2.playerDamage, player2.playerDefense);

                char input = ' ';
                GetInput(out input, "Attack", "Defend", "What action woudl you like to do " + player1.playerName + "?");
                if (input == '1')
                {

                }
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
