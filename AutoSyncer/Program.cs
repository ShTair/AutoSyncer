using System;
using System.Diagnostics;

namespace AutoSyncer
{
    class Program
    {
        static void Main(string[] args)
        {
            var git = "";

            //git reset --hard
            Execute(git, $"reset --hard");

            //git clean -f
            Execute(git, $"clean -f");

            //git checkout <branch>
            Execute(git, $"checkout {"branch"}");

            //git fetch
            Execute(git, $"fetch {"repos"}");

            //git reset --hard origin/<branch>
            Execute(git, $"reset --hard {"repos"}/{"branch"}");

            //git clean -f
            Execute(git, $"clean -f");

            //action

            //git add -A
            Execute(git, $"add -A");

            //git commit -m \"<message>\"
            Execute(git, $"commit -m \"sync [{DateTime.Now:yyyy/MM/dd HH:mm:ss}]\"");

            //git push -f
            Execute(git, $"push -f");
        }

        private static void Execute(string path, string command)
        {
            var pi = new ProcessStartInfo
            {
                FileName = path,
                Arguments = command,
            };

            using (var p = Process.Start(pi))
            {
                p.WaitForExit(300000);
            }
        }
    }
}
