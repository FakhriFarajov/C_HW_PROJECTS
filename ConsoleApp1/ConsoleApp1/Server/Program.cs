using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new TcpListener(IPAddress.Loopback, 3003);
listener.Start();
Console.WriteLine("Waiting for client...");

using TcpClient client = listener.AcceptTcpClient();
Console.WriteLine("Client connected!");
Console.WriteLine("The Game has Started!!!");

using NetworkStream stream = client.GetStream();
using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

DisplayClass displayClass = new DisplayClass();

while (true)
{
    // Receive message from client
    string? message = await reader.ReadLineAsync();

    if (string.IsNullOrEmpty(message))
    {
        Console.WriteLine("The Game has Ended!!!");
        break;
    }

    if (message.ToLower() == "quit")
    {
        Console.WriteLine("Client quit the game.");
        break;
    }

    if (!int.TryParse(message, out int clientMove))
    {
        Console.WriteLine("Invalid move received.");
        break;
    }

    displayClass.MakeMove(clientMove, 'X');

    if (displayClass.CheckTheWinner())
    {
        displayClass.DrawBoard();
        Console.WriteLine("You Lost");
        break;
    }

    if (displayClass.IsDraw())
    {
        displayClass.DrawBoard();
        Console.WriteLine("Draw");
        break;
    }

    displayClass.DrawBoard();
    Console.Write("Player1 choose the position ([quit] to exit): ");
    string response = Console.ReadLine();

    if (response.ToLower() == "quit")
    {
        await writer.WriteLineAsync("quit");
        Console.WriteLine("You quit the game.");
        break;
    }

    if (!int.TryParse(response, out int move) || !displayClass.MakeMove(move, 'O'))
    {
        Console.WriteLine("Incorrect input!");
        continue;
    }

    await writer.WriteLineAsync(response);
    displayClass.DrawBoard();

    if (displayClass.CheckTheWinner())
    {
        Console.WriteLine("You Win!");
        break;
    }

    if (displayClass.IsDraw())
    {
        Console.WriteLine("Draw");
        break;
    }
}




public class DisplayClass
{
    public char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    // Method to draw the current game board
    public void DrawBoard()
    {
        Console.WriteLine();
        Console.WriteLine($" 1: {board[0]} | 2: {board[1]} | 3: {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" 4: {board[3]} | 5: {board[4]} | 6: {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" 7: {board[6]} | 8: {board[7]} | 9: {board[8]} ");
        Console.WriteLine();
    }

    // Method to check if there is a winner
    public bool CheckTheWinner()
    {
        // Check rows
        if ((board[0] == board[1] && board[1] == board[2] && board[0] != ' ') ||  // Row 1
            (board[3] == board[4] && board[4] == board[5] && board[3] != ' ') ||  // Row 2
            (board[6] == board[7] && board[7] == board[8] && board[6] != ' '))    // Row 3
        {
            return true;
        }

        // Check columns
        if ((board[0] == board[3] && board[3] == board[6] && board[0] != ' ') ||  // Column 1
            (board[1] == board[4] && board[4] == board[7] && board[1] != ' ') ||  // Column 2
            (board[2] == board[5] && board[5] == board[8] && board[2] != ' '))    // Column 3
        {
            return true;
        }

        // Check diagonals
        if ((board[0] == board[4] && board[4] == board[8] && board[0] != ' ') ||  // Diagonal 1
            (board[2] == board[4] && board[4] == board[6] && board[2] != ' '))    // Diagonal 2
        {
            return true;
        }

        return false; // No winner
    }
    
    public bool IsDraw()
    {
        return !board.Contains(' ');
    }
    
    public bool MakeMove(int position, char player)
    {
        if (position < 1 || position > 9 || board[position - 1] != ' ')
        {
            return false;
        }

        board[position - 1] = player;
        return true;
    }
}
