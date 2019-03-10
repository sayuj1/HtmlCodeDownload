using System;
using System.Net;
using System.IO;


namespace HtmlCodeDownload
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome here, This program will download the source code of any website");
            bool getSrc = true;
            do
            {
                WebClient client = new WebClient();
                string protocol = HttpSelect.HttpMode();
                Console.Write($"\nEnter Site URL of which you want to download html source code: {protocol}://www.");
                string url = Console.ReadLine();
                while (url == "")
                {
                    Console.WriteLine("The URL should not be blank :(");
                    Console.Write($"\nEnter Site URL of which you want to download html source code: {protocol}://www.");
                    url = Console.ReadLine();
                }
                Console.WriteLine("Downloading Content...");
                string reply = client.DownloadString($"{protocol}://www.{url}");
                Console.WriteLine("Content Downloaded Successfully...\n");
                Console.WriteLine("Do you want to view the downloaded content?");
                
                bool view = true;
                do
                {
                    Console.WriteLine("Press 1 to view and save");
                    Console.WriteLine("Press 2 to save");
                    string s = Console.ReadLine();
                    if (s == "1")
                    {
                        Console.WriteLine($"\n{reply}");
                        view = false;
                    }
                        
                    else if(s == "2")
                    {
                        view = false;
                    }
                    else
                    {
                        Console.WriteLine("Please Select a valid choice");
                        view = true;
                    }
                        
                } while (view);
                string tl = TypeLoc.Location();
                Console.WriteLine("\nThe file will save in .txt format");
                Console.Write("Enter filename: ");
                string fn = Console.ReadLine();
                bool fne = true;
                do
                {
                    if(fn == "")
                    {
                        Console.WriteLine("\nThe Filename Should not be empty :( ");
                        Console.WriteLine("Enter filename: ");
                        fn = Console.ReadLine();
                        fne = true;
                    }
                    else
                    {
                        fne = false;
                    }
                } while (fne);
                File.WriteAllText($@"{tl}\{fn}.txt", reply);

                Console.WriteLine("\nDo you want to download html source code of another website?");
                Console.WriteLine("Type yes or 1 to continue");
                Console.WriteLine("Type no or 2 to exit");
                string choice = Console.ReadLine();
                if (choice == "yes" || choice == "1")
                    getSrc = true;
                else if (choice == "no" || choice == "2")
                    getSrc = false;
                else
                    Console.WriteLine("Enter a valid choice");

            } while (getSrc);
            Console.WriteLine("\nHave a Good Day :)");
            Console.ReadKey();

        }

    }

    class HttpSelect
    {
        public static string HttpMode()
        {
            string httpProtocol = "";
            bool choice = true;
            do
            {
                Console.WriteLine("\nSelect protocol");
                Console.WriteLine("Press 1 for HTTP");
                Console.WriteLine("Press 2 for HTTPS");
                string x = Console.ReadLine();
                if (x == "1")
                {
                    httpProtocol = "http";
                    choice = false;
                }
                   
                else if (x == "2")
                {
                    httpProtocol = "https";
                    choice = false;
                }
                    
                else
                {
                    Console.WriteLine("Please enter a valid choice :(");
                }
            } while (choice);
           
            return httpProtocol;

        }
    }

    class TypeLoc
    {
        public static string Location()
        {
            bool validChoice = true;
            string path = "";
            string user = "";
            do
            {
                Console.WriteLine("\nSelect Location to save the downloaded content");
                Console.WriteLine(@"Press 1 for full path e.g C:\Users\sayuj\Desktop\");
                Console.WriteLine(@"Press 2 for system generated path e.g C:\Users\{username}\Desktop\");
                string x = Console.ReadLine();
                if (x == "1")
                {
                    bool pathT = true;
                    do
                    {
                        Console.WriteLine("\nEnter full path where you want to save your file");
                        path = Console.ReadLine();
                        if(path == "")
                        {
                            Console.WriteLine("Path cannot be empty");
                        }
                        else
                        {
                            pathT = false;
                        }
                    } while (pathT);
                    validChoice = false;
                }
                else if (x == "2")
                {
                    bool userT = true;
                    do
                    {
                        Console.WriteLine("\nEnter your username, your file will save to Desktop automatically");
                        user = Console.ReadLine();
                        if (user =="")
                        {
                            Console.WriteLine("Username cannot be empty");

                        }
                        else
                        {
                            userT = false;
                        }
                    } while (userT);
                    path = @"C:\Users\" + user + @"\Desktop";
                    validChoice = false;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid choice :(");
                    validChoice = true;
                }
                    
            } while (validChoice);
            return path;
        }
    }

}
