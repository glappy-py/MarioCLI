using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
namespace backend
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "addtodo"){
                StreamReader todoreader = new StreamReader("G:\\codes - 2\\Mario\\todolist.txt");
                List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
                todoreader.Close();
                StreamWriter todowriter = new StreamWriter("G:\\codes - 2\\Mario\\todolist.txt",true,Encoding.ASCII);
                string todo = "";
                foreach (string item in args)
                {
                    todo += " " + item;   
                }
                todo = todo.Replace(" addtodo todo ","");
                todo = todolist.Count + ". " + todo + "\n";
                todowriter.Write(todo);
                todowriter.Close();
            }
            if (args[0] == "removetodo"){
                StreamReader todoreader = new StreamReader("G:\\codes - 2\\Mario\\todolist.txt");
                List<string> todolist = new List<string>(todoreader.ReadToEnd().Split("\n"));
                todoreader.Close();
                StreamWriter todowriter = new StreamWriter("G:\\codes - 2\\Mario\\todolist.txt",false,Encoding.ASCII);
                List<string> parsedArgs = new List<string>(args);
                parsedArgs.Remove("removetodo");
                foreach (string item in parsedArgs)
                {
                    Console.WriteLine(item);
                }
                foreach (string item in todolist.ToArray())
                {
                    Console.WriteLine(item);
                    if (parsedArgs.Contains(item[0].ToString())){
                        todolist.Remove(item);
                    }
                }
                foreach (string item in todolist.ToArray())
                {
                    todowriter.WriteLine(item);
                }
                todowriter.Close();
            }
            
        }
    }
}
