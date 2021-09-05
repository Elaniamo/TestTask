using System;
using System.Security;

namespace ProcessManagerConsoleClient
{
    class Program
    {
        static void Main()
        {
            GetProcess();
            Console.ReadKey();
        }

        static void GetProcess()
        {
            var login = GetLogin();
            var pass = GetPassword();

            Console.WriteLine();

            var client = new ProcessManager.ProcessManagerClient("WSHttpBinding_IProcessManager");
            var list = client.GetProcess(login, new System.Net.NetworkCredential(string.Empty, pass).Password);

            Console.WriteLine(String.Join("\n", list));

            client.Close();
        }
        static private string GetLogin()
        {
            Console.Write("Enter your Login: ");
            return Console.ReadLine();
        }
        static private SecureString GetPassword()
        {
            Console.Write("Enter your password: ");

            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}
