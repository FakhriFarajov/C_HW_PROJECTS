using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;



//The client plays with X and starts first
var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var address = IPAddress.Parse("127.0.0.1");
var serverEndPoint = new IPEndPoint(address, 3003);

try
{
    clientSocket.Connect(serverEndPoint);
    var buffer = new byte[1024];
    
    Console.WriteLine("The Game has Started!!!\nYou are playing with [X] you start first ");
    DisplayClass displayClass = new DisplayClass();

    while (true)
    {
        //Send
        displayClass.DrawBoard();
        Console.Write("Player2 choose the position([quit] to exit): ");
        
        string message = Console.ReadLine();
        if (message.ToLower() == "quit")
        {
            Console.WriteLine("Quitting...");
            break;
        }
        else if(!message.All(char.IsDigit))
        {
            Console.WriteLine("Incorrect input!");
            continue;
        }

        if (!displayClass.MakeMove(int.Parse(message), 'X'))
        {
            Console.WriteLine("Incorrect input!");
            continue;
        };
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(messageBytes);
        displayClass.DrawBoard();
        //First check the winner and then check for draw
        if (displayClass.CheckTheWinner())
        {
            Console.WriteLine("You Win!");
            break;
        }
        if (displayClass.IsDraw())
        {
            Console.WriteLine("Draw");
            break;
        };
        
        
        // Receive server response
        int bytesRead = clientSocket.Receive(buffer);
        string serverMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        
        displayClass.MakeMove(int.Parse(serverMessage), 'O');
        displayClass.DrawBoard();
        
        if (displayClass.CheckTheWinner())
        {
            Console.WriteLine("You Lost");
            break;
        }
        if (displayClass.IsDraw())
        {
            Console.WriteLine("Draw");
            break;
        };


        if (serverMessage.ToLower() == "quit")
        {
            break;
        }
    }
    clientSocket.Shutdown(SocketShutdown.Both);
    clientSocket.Close();
}
catch (Exception e)
{
    Console.WriteLine(e);
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