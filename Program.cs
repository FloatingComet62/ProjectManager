namespace Program {
    class Program {
        static void Main(string[] args) {
            List<User> AllUsers = new List<User>();
            // reads all the users from usr.txt
            string raw = File.ReadAllText("usr.txt");
            string[] lines = raw.Split('\n');
            foreach (string data in lines) {
                string[] props = data.Split('=');
                AllUsers.Add(new User(props[0], props[1]));
            }
            bool loggedIn = false;
            string user = "";
            string password = "";

            while (!loggedIn) {
                Login login = new Login();
                user = login.takeUser();
                password = login.takePassword();
                foreach (User u in AllUsers) {
                    if (u.name == user) {
                        loggedIn = true;
                        if (u.password == password) {
                            Console.WriteLine("Welcome " + user);
                            continue;
                        } else {
                            Console.WriteLine("Wrong password");
                            continue;
                        }
                    } else {
                        Console.WriteLine("Wrong user");
                    }
                }
            }
            while(true) {
                Console.Write(user+"@"+Environment.MachineName+"$ ");
                string cmd = Console.ReadLine() ?? "";
                if (cmd == "exit") break;
                Console.WriteLine(cmd);
            }
        }
    }
    class User {
        public string name;
        public string password;
        public User(string name, string password) {
            this.name = name;
            this.password = password;
        }
        public void createFolder() {
            // creates a folder for the user in /usr/
            string workingDirectory = System.IO.Directory.GetCurrentDirectory();
            string usersDirectory = System.IO.Path.Combine(workingDirectory, "usr");
            string userDirectory = System.IO.Path.Combine(usersDirectory, this.name);
            System.IO.Directory.CreateDirectory(userDirectory);
            void createLangFolder(string dir) {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(userDirectory, dir));
            }

            createLangFolder("JavaScript");
            createLangFolder("TypeScript");
            createLangFolder("Python");
            createLangFolder("Nextjs");
            createLangFolder("C");
            createLangFolder("C++");
            createLangFolder("C#");
            createLangFolder("Rust");
            createLangFolder("Flutter");
            createLangFolder("React Native");
            createLangFolder("Java");
            createLangFolder("Cloned Repositories");
            createLangFolder("Custom");
        }
    }
    class Login {
        public string takeUser() {
            // takes user input for name
            Console.Write("cometos@login: ");
            string? user = Console.ReadLine();

            return user ?? "";
        }
        public string takePassword() {
            // takes user input for password, with the hidden stuff
            Console.Write("password: ");
            string password = "";
            bool inputing = true;
            while (inputing) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) {
                    inputing = false;
                    Console.WriteLine();
                } else if (key.Key == ConsoleKey.Backspace) {
                    if (password.Length > 0) {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                } else {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            return password;
        }
    }
}