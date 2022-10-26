bool gameOver = false;
int playerChoice = 0;
bool humanToPlay = true; // human or computer to play

// initialize board
char[,] board = InitializeBoard();

DisplayBoard(board);

while(!gameOver)
{
  if(humanToPlay)
  {
    playerChoice = GetPlayerChoice();
    MakeHumanMove(playerChoice);
    humanToPlay = false;
  }
  else
  {
    MakeComputerMove();
    humanToPlay = true;
  }

  DisplayBoard(board);
  gameOver = CheckForWin();

  if(gameOver)
  {
    if(!humanToPlay)
    {
      Console.WriteLine("\nYou Won!\n");
    }
    else
    {
      Console.WriteLine(("\nBetter luck next time!\n"));
    }
  }
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
    case 1: if(board[2,0] == 'X' || board[2,0] == 'O') {return false;} break;
    case 2: if(board[2,1] == 'X' || board[2,1] == 'O') {return false;} break;
    case 3: if(board[2,2] == 'X' || board[2,2] == 'O') {return false;} break;
    case 4: if(board[1,0] == 'X' || board[1,0] == 'O') {return false;} break;
    case 5: if(board[1,1] == 'X' || board[1,1] == 'O') {return false;} break;
    case 6: if(board[1,2] == 'X' || board[1,2] == 'O') {return false;} break;
    case 7: if(board[0,0] == 'X' || board[0,0] == 'O') {return false;} break;
    case 8: if(board[0,1] == 'X' || board[0,1] == 'O') {return false;} break;
    case 9: if(board[0,2] == 'X' || board[0,2] == 'O') {return false;} break;
  }
  return true;
}

void MakeComputerMove()
{
  // pick random square and place 'X' if move is valid
  Random rnd = new Random();
  int computerChoice = 0;

  do
  {
    computerChoice = rnd.Next(1,10);
    Console.WriteLine("Waiting.. and the number is {0}", computerChoice);
    if(IsValidMove(computerChoice))
    {
      switch(computerChoice)
      {
        case 1: board[2,0] = 'X'; return;
        case 2: board[2,1] = 'X'; return;
        case 3: board[2,2] = 'X'; return;
        case 4: board[1,0] = 'X'; return;
        case 5: board[1,1] = 'X'; return;
        case 6: board[1,2] = 'X'; return;
        case 7: board[0,0] = 'X'; return;
        case 8: board[0,1] = 'X'; return;
        case 9: board[0,2] = 'X'; return;
      }
    }
  } while(!IsValidMove(computerChoice));
}

void MakeHumanMove(int choice)
{
  switch (playerChoice)
  {
    case 1: board[2,0] = 'O'; break;
    case 2: board[2,1] = 'O'; break;
    case 3: board[2,2] = 'O'; break;
    case 4: board[1,0] = 'O'; break;
    case 5: board[1,1] = 'O'; break;
    case 6: board[1,2] = 'O'; break;
    case 7: board[0,0] = 'O'; break;
    case 8: board[0,1] = 'O'; break;
    case 9: board[0,2] = 'O'; break;
  }
}

bool CheckForWin()
{
  for(int i = 0; i < 3; i++)
  {
    // check for horizontal or vertical wins
    if((board[i,0].Equals(board[i,1]) && board[i,1].Equals(board[i,2]))
      || (board[0,i].Equals(board[1,i]) && board[1,i].Equals(board[2,i])))
    {
      return true;
    }
    // check for diagon wins
    else if((board[0,0].Equals(board[1,1]) && board[1,1].Equals(board[2,2]))
      || (board[0,2].Equals(board[1,1]) && board[1,1].Equals(board[2,0])))
    {
      return true;
    }
  }
  return false;
}
