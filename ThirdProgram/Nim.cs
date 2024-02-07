using System;

public class Nim
{
	// Vars
	int matchsticks { get; set; } = 100;
	bool playerFirst { get; set; } // Player 1 vs AI/Player 2 plays first
	bool aiPlayer { get; set; } // AI player vs two human players

	// Constructor
	public Nim(bool playerFirst, bool aiPlayer)
	{
		this.playerFirst = playerFirst;
		this.aiPlayer = aiPlayer;
	}

	public void Start()
	{
		Console.WriteLine("There are {0} matchstick{1}.", this.matchsticks, (this.matchsticks == 1 ? "" : "s"));

		if (this.playerFirst) // If player decides to go first, play move
		{
			playerMove(1);
		}

		bool playerWinner = false; // True for player 1, false for AI/player 2

		while (true) // Run until break (when win condition met)
		{
			if (this.aiPlayer) // If AI is playing
			{
				aiMove();
			} else // If 2 humans are playing
			{
				playerMove(2);
			}

			if (this.matchsticks <= 0) { // Check for win
				playerWinner = true;
				break;
			}

			playerMove(1); // Player 1's move

			if (this.matchsticks <= 0) // Check for win
			{
				playerWinner = false;
				break;
			}
		}

		// Build win message based on ai/human player, player 1/2 winner
		string winnerMessage = "\n";
		if (this.aiPlayer)
		{
			if (playerWinner)
			{
				winnerMessage += "The AI";
			} else
			{
				winnerMessage += "You";
			}
		} else
		{
			if (playerWinner)
			{
				winnerMessage += "Player 2";
			} else
			{
				winnerMessage += "Player 1";
			}
		}
		winnerMessage += " removed the last matchstick. ";
		if (this.aiPlayer)
		{
			if (playerWinner)
			{
				winnerMessage += "You win!";
			} else
			{
				winnerMessage += "The AI wins!";
			}
		} else
		{
			if (playerWinner)
			{
				winnerMessage += "Player 1 wins!";
			} else
			{
				winnerMessage += "Player 2 wins!";
			}
		}

		Console.WriteLine(winnerMessage);
	}

	void playerMove(int playerNumber)
	{
		Console.WriteLine("\nPlayer {0}\n=====", (this.aiPlayer ? "" : playerNumber));

		int userPlay = getIntInput("Please enter the number of matchsticks to remove: "); // Get number of matchsticks to remove

		this.matchsticks -= userPlay;

		Console.WriteLine("You remove {0} matchstick{1}. There {4} {2} matchstick{3} remaining.", userPlay, (userPlay == 1 ? "" : "s"), this.matchsticks, (this.matchsticks == 1 ? "" : "s"), (this.matchsticks == 1 ? "is" : "are"));
	}

	void aiMove()
	{
        Console.WriteLine("\nAI Player\n=====");

        int target = (this.matchsticks - 1) % 11; // Calculate optimal number to remove
		target = (target < 1) ? 1 : target; // Can not remove 0, must remove at least 1

		if (this.matchsticks > 50) // If more than 50 matchsticks remaining, pick random number to remove to give player a chance
		{
			Random rnd = new Random();
			target = rnd.Next(1, 11); // Lower bound is inclusive, upper bound is exclusive
		}

		this.matchsticks -= target;

		Console.WriteLine("The AI removes {0} matchstick{1}. There {4} {2} matchstick{3} remaining.", target, (target == 1 ? "" : "s"), this.matchsticks, (this.matchsticks == 1 ? "" : "s"), (this.matchsticks == 1 ? "is" : "are"));
	}

	int getIntInput(string prompt)
	{
		bool readyToBreak = false;
		int userInputInt;

		do
		{
			Console.Write(prompt);
			string userInputString = Console.ReadLine().Trim();

			readyToBreak = int.TryParse(userInputString, out userInputInt);

			if (userInputInt < 1 || userInputInt > 10) // Can only remove 1..10 matchsticks
			{
				Console.Write("You can only remove between (and including) 1 and 10 matchsticks! ");
				readyToBreak = false;
			}

			if (userInputInt > this.matchsticks) // Check if enough matchsticks left
			{
				Console.Write("You can not remove more matchsticks than there are left! ");
				readyToBreak = false;
			}

			if (!readyToBreak)
				Console.WriteLine("Please give a valid integer.");
		} while (!readyToBreak);

		return userInputInt;
	}
}
