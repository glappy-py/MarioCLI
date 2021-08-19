using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace backend
{
    class Program
    {
        // TODO: make a gitbook about mario 
        // TODO: make a command "mario about" which takes the user to marioCLI's gitbook
        // TODO: make a command "mario report" which the user can use to report a bug or suggest something
        // TODO: rebuild zoom bot with .net
        // TODO: make a command "mario update" which updates the user's marioCLI
        // TODO: Make a mario settings panel when the user can choose their default ide ( VScode or sublime ) and change mario start likewise
        
        // Arg conditions
        static void Main(string[] args)
        {
            List<string> TempArgs = new List<string>(args);
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path.Remove(19);
            string cwd = Directory.GetCurrentDirectory();
            cwd = cwd + @"\";
            if (TempArgs.Count > 0){
                string command = TempArgs[0];
                TempArgs.RemoveAt(0);
                string[] Args = TempArgs.ToArray();
                if (command == "todo"){
                    addTodo(Args,path);
                }
                if (command == "done"){
                    removeTodo(Args,path);
                }
                if (command == "list"){
                    listTodoTasks(Args,path);
                }
                if (command == "terminate"){
                    terminateSystem();
                }
                if (command == "start"){
                    marioStart(cwd);
                }
                if (command == "help"){
                    help(path);
                }
                if (command == "make"){
                    makeFile(cwd,Args);
                }
                if (command  == "install"){
                    installNPMPackage(cwd,Args);
                }
                if (command == "react"){
                    initializeReactJSProject(Args,cwd);
                }
                if (command == "node"){
                    initializeNodeJSProject(Args,cwd,path);
                }
            } else {
                Console.Write("use ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("mario help ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("to get a list of mario commands");
            }
            
        }
        // Function for adding todo tasks
        static void addTodo(string[] args,string path){
            StreamReader todoreader = new StreamReader(path + @"todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"todolist.txt",true,Encoding.ASCII);
            string todo = "";
            foreach (string item in args)
            {
                todo += " " + item;   
            }
            todo = todo.Replace(" addtodo todo ","");
            todo = todolist.Count + ". " + todo + "\n";
            todowriter.Write(todo);
            todowriter.Close();
            Console.WriteLine();
            foreach (string item in todolist)
            {
                if (item != ""){
                    Console.WriteLine(item);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(todo);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void removeTodo(string[] args,string path){
            StreamReader todoreader = new StreamReader(path + @"todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"todolist.txt",false,Encoding.ASCII);
            List<string> parsedArgs = new List<string>(args);
            parsedArgs.Remove("done");
            parsedArgs.Remove("removetodo");
            todolist.Remove("");
            foreach (string item in todolist.ToArray())
            {
                if (parsedArgs.Contains(item[0].ToString())){
                    todolist.Remove(item);
                }
            }
            int counter = 1;
            foreach (string item in todolist)
            {
                Console.WriteLine(item.Replace(item[0],Char.Parse(counter.ToString())));
                counter++;
            }
            counter = 1;
            foreach (string item in todolist)
            {
                todowriter.Write(item.Replace(item[0],Char.Parse(counter.ToString())));
                counter++;
            }
            todowriter.Close();
        }
        static void listTodoTasks(string[] args,string path){
            StreamReader todoreader = new StreamReader(path + @"todolist.txt");
            Console.Write(todoreader.ReadToEnd());
            todoreader.Close();
        }
        static void terminateSystem(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("terminating system");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Diagnostics.Process.Start("cmd.exe","/c shutdown /s /t 2");
        }
        static void marioStart(string cwd){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c cd /d \"" + cwd + "\" && code .";
            process.StartInfo = startInfo;
            process.Start();
        }
        static void help(string path){
            StreamReader helpReader = new StreamReader(path + @"help.txt");
            Console.Write(helpReader.ReadToEnd());
            helpReader.Close();
        }
        static void initializeNodeJSProject(string[] args,string cwd,string path){
            string directoryName;
            try{
                directoryName = args[0];
            }catch{
                Console.Write("please provide a name for your nodeJS project : ");
                directoryName = Console.ReadLine();
            }
            Directory.CreateDirectory(cwd + directoryName);
            File.Create(cwd + directoryName + @"\index.js");
            StreamWriter packageWriter = new StreamWriter(cwd + directoryName + @"\package.json",false,Encoding.ASCII);
            StreamReader packageReader = new StreamReader(path + @"package.txt");
            packageWriter.WriteLineAsync("{");
            packageWriter.WriteLineAsync("  \"name\": \"" + directoryName.ToLower() + "\",");
            packageWriter.WriteAsync(packageReader.ReadToEnd());
            packageReader.Close();
            packageWriter.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("nodejs");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" project, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(directoryName);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" initialized, happy coding");
        }
        static void initializeReactJSProject(string[] args,string cwd){
            string directoryName;
            try{
                directoryName = args[0];
            }catch{
                Console.Write("please provide a name for your nodeJS project : ");
                directoryName = Console.ReadLine();
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c cd /d \"" + cwd + "\" && npx create-react-app " + directoryName + " && cd " + directoryName;
            process.StartInfo = startInfo;
            process.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ReactJS");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" project initialized, happy coding");
        }
        static void installNPMPackage(string cwd,string[] args){
            foreach (string package in args)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c cd /d \"" + cwd + "\" && npm install " + package;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
        static void makeFile(string cwd,string[] args){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c cd /d \"" + cwd + "\" && echo. > " + args[0];
            process.StartInfo = startInfo;
            process.Start();
            Console.Write("created ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(args[0]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" at " + cwd);
        }
    }
}
