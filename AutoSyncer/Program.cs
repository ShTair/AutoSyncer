using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace AutoSyncer
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameter = Load(args[0]);

            //git reset --hard
            Execute(parameter.GitPath, $"reset --hard");

            //git clean -f
            Execute(parameter.GitPath, $"clean -f");

            //git checkout <branch>
            Execute(parameter.GitPath, $"checkout {parameter.BranchName}");

            //git fetch <repos>
            Execute(parameter.GitPath, $"fetch {parameter.RepositoryName}");

            //git reset --hard <remoteBranch>
            Execute(parameter.GitPath, $"reset --hard {parameter.RemoteBranchName}");

            //git clean -f
            Execute(parameter.GitPath, $"clean -f");

            //action

            //git add -A
            Execute(parameter.GitPath, $"add -A");

            //git commit -m \"<message>\"
            Execute(parameter.GitPath, $"commit -m \"sync [{DateTime.Now:yyyy/MM/dd HH:mm:ss}]\"");

            //git push -f
            Execute(parameter.GitPath, $"push -f");
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

        private static Parameter Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Parameter>(path);
        }
    }
}
