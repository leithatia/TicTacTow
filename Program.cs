﻿bool gameOver = false;
int playerChoice = 0;
bool humanToPlay = true; // human or computer to play

// initialize board
char[,] board = InitializeBoard();

DisplayBoard(board);

while(!gameOver)
{

  // 1. get valid input
  playerChoice = GetPlayerChoice();

  // 2. make the move
  MakeMove(playerChoice);

   // 3. refresh board
   DisplayBoard(board);

   // check if a player has won
   gameOver = CheckForWin();

  // 4. if game over end, else return to 1.
  gameOver = false;
}

char[,] InitializeBoard()
{
  char[,] board = {
    {'7','8','9'},
    {'4','5','6'},
    {'1','2','3'}
  };

  return board;
}

void DisplayBoard(char[,] board)
{
  Console.Clear();
  Console.WriteLine(" {0} | {1} | {2}",board[0,0], board[0,1], board[0,2]);
  Console.WriteLine("-----------");
  Console.WriteLine(" {0} | {1} | {2}",board[1,0], board[1,1], board[1,2]);
  Console.WriteLine("-----------");
  Console.WriteLine(" {0} | {1} | {2}",board[2,0], board[2,1], board[2,2]);
}

int GetPlayerChoice()
{
  // get user input
  Console.Write("\nMake your move: ");
  string? playerInput = "";

  while(true)
  {
    playerInput = Console.ReadLine();

    // check that input is valid
    if(playerInput != null && IsValidInput(playerInput) && IsValidMove(int.Parse(playerInput)))
    {
      return int.Parse(playerInput);
    }
    else
    {
      DisplayBoard(board);
      Console.WriteLine("\nThat's not a valid input.");
      Console.Write("Please enter a number from 1 - 9: ");
    }
  }
}

bool IsValidInput(string input)
{
  // check that input is valid (one digit)
  string[] validInputs = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

  if(validInputs.Any(s => input.Contains(s)) && input.Length == 1)
  {
    return true;
  }

  return false;
}

bool IsValidMove(int playerInput)
{
  switch (playerInput)
  {
    case 1:
      if(board[2,0] == 'X' || board[2,0] == 'O') {return false;}
      break;
    case 2:
      if(board[2,1] == 'X' || board[2,1] == 'O') {return false;}
      break;
    case 3:
      if(board[2,2] == 'X' || board[2,2] == 'O') {return false;}
      break;
    case 4:
      if(board[1,0] == 'X' || board[1,0] == 'O') {return false;}
      break;
    case 5:
      if(board[1,1] == 'X' || board[1,1] == 'O') {return false;}
      break;
    case 6:
      if(board[1,2] == 'X' || board[1,2] == 'O') {return false;}
      break;
    case 7:
      if(board[0,0] == 'X' || board[0,0] == 'O') {return false;}
      break;
    case 8:
      if(board[0,1] == 'X' || board[0,1] == 'O') {return false;}
      break;
    case 9:
      if(board[0,2] == 'X' || board[0,2] == 'O') {return false;}
      break;
    default:
    return true;
  }
  return true;
}

void MakeMove(int choice)
{
  switch (playerChoice)
  {
    case 1:
      board[2,0] = 'X';
      break;
    case 2:
      board[2,1] = 'X';
      break;
    case 3:
      board[2,2] = 'X';
      break;
    case 4:
      board[1,0] = 'X';
      break;
    case 5:
      board[1,1] = 'X';
      break;
    case 6:
      board[1,2] = 'X';
      break;
    case 7:
      board[0,0] = 'X';
      break;
    case 8:
      board[0,1] = 'X';
      break;
    case 9:
      board[0,2] = 'X';
      break;
  }
}

bool CheckForWin()
{
  // check for horizontal or vertical wins
 return false;
}
