using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Helpers
{

    public static class ProcessHelpers
    {
        public static string RunCmd(string cmd, bool isRunAsAdmin = false)
        {
            Process process = new Process();
            process.StartInfo.Arguments = $"{cmd}";
            process.StartInfo.FileName = $"CMD.exe";

            if (isRunAsAdmin)
                process.StartInfo.Verb = "runas";

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            var result = process.Start();
            var runResutl = process.StandardOutput.ReadToEnd();

            return result ? runResutl : $"Error : Something went wrong. Please try again";

        }

        public static string RunExternalExe(string filename, string arguments = null, bool isRunAsAdmin = false, string username = "", string password = "")
        {
            var process = new Process();

            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            if (isRunAsAdmin)
            {
                // set admin user and password
                process.StartInfo.Verb = "runas";
            }


            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data); // Use AppendLine rather than Append since args.Data is one line of output, not including the newline character.

            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
            }

            if (process.ExitCode == 0)
            {
                return stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();

                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }

                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }

                throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
            }
        }

        private static string Format(string filename, string arguments)
        {
            return "'" + filename +
                ((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments) +
                "'";
        }
    }
}
