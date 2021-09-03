using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
namespace backend
{
    class Program
    {
        // TODO: If I face some copyright issues then I'll change this project's name to spideyCLI
        // TODO: make a gitbook about mario 
        // TODO: make a command "mario about" which takes the user to marioCLI's gitbook
        // TODO: make a command "mario report" which the user can use to report a bug or suggest something
        // TODO: rebuild zoom bot with .net
        // TODO: make a command "mario update" which updates the user's marioCLI
        // Arg conditions
        static void Main(string[] args)
        {
            
            System.Diagnostics.Debug.WriteLine("ok");
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
                if (command == "join"){
                    meetingMiddleware(Args,path);
                }
                if (command == "configure"){
                    configure(Args,path);
                }
                if (command == "doctor"){
                    doctor(path);
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
            StreamReader todoreader = new StreamReader(path + @"\backend\txts\todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"\backend\txts\todolist.txt",true,Encoding.ASCII);
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
            StreamReader todoreader = new StreamReader(path + @"\backend\txts\todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"\backend\txts\todolist.txt",false,Encoding.ASCII);
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
            StreamReader todoreader = new StreamReader(path + @"\backend\txts\todolist.txt");
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
            StreamReader helpReader = new StreamReader(path + @"\backend\txts\help.txt");
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
            StreamReader packageReader = new StreamReader(path + @"\backend\txts\package.txt");
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
            Console.WriteLine();
            Console.Write("initializing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ReactJS");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" project");
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
        // Experimental code
        static void executeZoomBot(string[] args,string path){
            // Executing zoom bot
            Console.Write("executing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("zoom bot");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c cd /d \"" + path + @"\backend" + "\" && python zoombot.py " + args[0];
            process.StartInfo = startInfo;
            process.Start();
        }
        static void executeMeetBot(string meetingID){
            Console.Write("executing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("meet bot");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Diagnostics.Process.Start(new ProcessStartInfo("cmd", $"/c start {"https://meet.google.com/" + meetingID}") { CreateNoWindow = true });
        }
        static void meetingMiddleware(string[] args,string path){
            StreamReader infoReader = new StreamReader(path + @"\backend\txts\info.txt");
            List<string> info = new List<string>(infoReader.ReadToEnd().Split("\n"));
            infoReader.Close();
            bool meetingFound = false;
            foreach (string item in info.ToArray())
            {
                string[] items = item.Split(":");
                if (items[0] == args[0]){
                    meetingFound = true;
                    if (items[2] == "gmeet"){
                        executeMeetBot(items[1]);
                    } else {
                        executeZoomBot(args,path);
                    }
                }
            }
            if (!meetingFound){
                Console.WriteLine("no meeting entry found for \'" + args[0] + "\'");
            }
        }
        static void configure(string[] args,string path){
            if (args[0] == "zoom"){
                configureZoomPath(path);
            } else if(args[0] == "gmeet"){
                StreamReader helpreader = new StreamReader(path + @"\backend\txts\gmeetConfigurationHelp.txt");
                Console.Write(helpreader.ReadToEnd());
                helpreader.Close();
                gmeetConfigurationPanel(path);
            }
        }
        static void configureZoomPath(string path){
            string zoomPath;
            StreamReader pathReader = new StreamReader(path + @"\backend\txts\path.txt");
            zoomPath = pathReader.ReadLine();
            pathReader.Close();
            FileInfo zoomInfo = new FileInfo(zoomPath + @"\Zoom.exe");
            if (zoomInfo.Exists){
                Console.Write("zoom directory ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" is configured");
                Console.ForegroundColor = ConsoleColor.Gray;
                
            } else {
                Console.Write("zoom directory ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" is not configured");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter the absolute path of the zoom executable file : ");
                zoomPath = Console.ReadLine();
                StreamWriter pathWriter = new StreamWriter(path + @"\backend\txts\path.txt");
                pathWriter.Write(zoomPath);
                pathWriter.Close();
                configureZoomPath(path);
            }
            StreamReader helpreader = new StreamReader(path + @"\backend\txts\zoomConfigurationHelp.txt");
            Console.Write(helpreader.ReadToEnd());
            helpreader.Close();
            zoomConfigurationPanel(path);
        }
        static void gmeetConfigurationPanel(string path){
            Console.Write("command : ");
            string[] commands = Console.ReadLine().Split(" ");
            if(commands[0] == "exit"){
            } else if (commands[0] == "add"){
                addNewMeetingEntry(commands,path,"gmeet");
                gmeetConfigurationPanel(path);
            } else if(commands[0] == "remove"){
                removeMeetingEntry(commands[1],path);
                gmeetConfigurationPanel(path);
            } else if(commands[0] == "list"){
                listMeetingEntries(path,commands);
                gmeetConfigurationPanel(path);
            }
            else {
                Console.WriteLine("invalid command");
                gmeetConfigurationPanel(path);
            }
        }
        static void zoomConfigurationPanel (string path){
            Console.Write("command : ");
            string[] commands = Console.ReadLine().Split(" ");
            if(commands[0] == "exit"){
            } else if (commands[0] == "add"){
                addNewMeetingEntry(commands,path,"zoom");
                zoomConfigurationPanel(path);
            } else if(commands[0] == "remove"){
                removeMeetingEntry(commands[1],path);
                zoomConfigurationPanel(path);
            } else if(commands[0] == "list"){
                listMeetingEntries(path,commands);
                zoomConfigurationPanel(path);
            }
            else {
                Console.WriteLine("invalid command");
                zoomConfigurationPanel(path);
            }
        }
        static void addNewMeetingEntry(string[] commands,string path,string platform){
            StreamReader infoReader = new StreamReader(path + @"\backend\txts\info.txt");
            List<string> info = new List<string>(infoReader.ReadToEnd().Split("\n"));
            infoReader.Close();
            if (info.Contains(commands[1])){
                Console.WriteLine("a meeting entry with name \'" + commands[1] + "\' already exists");
            } else {
                StreamWriter infoWriter = new StreamWriter(path + @"\backend\txts\info.txt",true);
                if (platform == "zoom"){
                    infoWriter.Write("\n" + commands[1] + ":" + commands[2] + ":" + commands[3] + ":zoom");
                    infoWriter.Close();
                    Console.Write("added ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(commands[1]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" to zoom bot");
                } else if(platform == "gmeet"){
                    infoWriter.Write("\n" + commands[1] + ":" + commands[2] + ":gmeet");
                    infoWriter.Close();
                    Console.Write("added ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(commands[1]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" to meet bot");
                }

            }
        }
        static void removeMeetingEntry(string meetingName,string path){
            StreamReader infoReader = new StreamReader(path + @"\backend\txts\info.txt");
            List<string> info = new List<string>(infoReader.ReadToEnd().Split("\n"));
            infoReader.Close();
            foreach (string item in info.ToArray())
            {
                if (item.Split(":")[0] == meetingName){
                    info.Remove(item);
                }
            }
            foreach (string item in info.ToArray())
            {
                if(info.IndexOf(item) != info.Count - 1){
                    info[info.IndexOf(item)] = item + "\n";
                }
            }
            StreamWriter infoWriter = new StreamWriter(path + @"\backend\txts\info.txt",false);
            List<string> writableInfo = new List<string>();
            foreach (string item in info)
            {
                if (item != ""){
                    writableInfo.Add(item);
                }
            }
            foreach (string item in writableInfo.ToArray()){
                infoWriter.Write(item);
            }
            infoWriter.Close();
            Console.Write("removed ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(meetingName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void doctor(string path){
            string zoomPath;
            StreamReader pathReader = new StreamReader(path + @"\backend\txts\path.txt");
            zoomPath = pathReader.ReadLine();
            pathReader.Close();
            FileInfo zoomInfo = new FileInfo(zoomPath + @"\Zoom.exe");
            if (zoomInfo.Exists){
                Console.Write("zoom bot is ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("configured");
                Console.ForegroundColor = ConsoleColor.Gray;
            } else {
                Console.Write("zoom bot is ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not configured");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        static void listMeetingEntries(string path,string[] commands){
            StreamReader infoReader = new StreamReader(path + @"\backend\txts\info.txt");
            int counter;
            Console.WriteLine("meeting name - meeting id - meeting pass");
            Console.WriteLine();
            counter = 1;
            foreach (string item in infoReader.ReadToEnd().Split("\n"))
            {
                string[] items = item.Split(":");
                Console.Write(counter + ". ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(items[0] + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (items[2] == "gmeet"){
                    Console.WriteLine(items[1] + "\n");
                } else {
                    Console.WriteLine(items[1] + " " + items[2] + "\n");
                }
                counter++;
            }
            infoReader.Close();
            
        } 
    }
}
