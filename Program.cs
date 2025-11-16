// file: program.cs
// author: smg
// description: main entry point for the mechwar back end in csharp. plenty of effort left to make this all work.
// 

// See https://aka.ms/new-console-template for more information

namespace MechWarBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var m = new Game();
            m.Go(false);
        }
    }
}