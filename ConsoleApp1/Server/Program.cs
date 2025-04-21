using System.Net;
using System.Net.Sockets;
using System.Text;


//This is using Sockets

var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var address = IPAddress.Parse("127.0.0.1");
var endPoint = new IPEndPoint(address, 3003);
var buffer = new byte[1024];





try
{
    serverSocket.Bind(endPoint);//Like initialize 
    serverSocket.Listen();
    Console.WriteLine($"Listening on {endPoint.Address}:{endPoint.Port}");

    var clientSocket = serverSocket.Accept();
    Console.WriteLine($"Client connected: {clientSocket.RemoteEndPoint}");
    Console.WriteLine("The Game has Started!!!");
    
    DisplayClass displayClass = new DisplayClass();
    
    while (true)
    {
        // Receive message from client
        var bytesRead = clientSocket.Receive(buffer);
        var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        if (message == "")
        {
            Console.WriteLine("The Game has Ended!!!");
            break;
        }
        displayClass.MakeMove(int.Parse(message), 'X');
        
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
        
        if (message.ToLower() == "quit")
        {
            Console.WriteLine("Quitting...");
            break;
        }

        // Send message to client
        displayClass.DrawBoard();
        Console.Write("Player1 choose the position([quit] to exit): ");
        
        string messageToSend = Console.ReadLine();
        if (messageToSend.ToLower() == "quit")
        {
            Console.WriteLine("Quitting...");
            break;
        }
        else if(!messageToSend.All(char.IsDigit))
        {
            Console.WriteLine("Incorrect input!");
        }

        if (!displayClass.MakeMove(int.Parse(messageToSend), 'O'))
        {
            Console.WriteLine("Incorrect input!");
            continue;
        };
        
        byte[] responseBytes = Encoding.UTF8.GetBytes(messageToSend);
        clientSocket.Send(responseBytes);
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
        };

    }
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
