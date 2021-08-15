using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
namespace backend
{
    class Program
    {
        // Arg conditions
        static void Main(string[] args)
        {
            List<string> TempArgs = new List<string>(args);
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(18);
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
            
        }
        // Function for adding todo tasks
        static void addTodo(string[] args,string path){
            StreamReader todoreader = new StreamReader(path + @"\todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"\todolist.txt",true,Encoding.ASCII);
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
            StreamReader todoreader = new StreamReader(path + @"\todolist.txt");
            List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
            todoreader.Close();
            StreamWriter todowriter = new StreamWriter(path + @"\todolist.txt",false,Encoding.ASCII);
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
            StreamReader todoreader = new StreamReader(path + @"\todolist.txt");
            Console.Write(todoreader.ReadToEnd());
            todoreader.Close();
        }
    }
}
