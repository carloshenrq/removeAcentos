using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace removeAcentos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstArgs = args.ToList();
            lstArgs.ForEach(arg =>
            {
                using (StreamReader srInput = new StreamReader(arg))
                using (StreamWriter swOutput = new StreamWriter(arg + ".output"))
                {
                    List<string> lstInputData = srInput.ReadToEnd().Split('\n').ToList();
                    srInput.Close();

                    lstInputData.ForEach(lineData =>
                    {
                        swOutput.WriteLine(StringParser.removeAcentos(lineData.Trim()));
                        swOutput.Flush();
                    });

                    swOutput.Close();
                }
            });
        }
    }
}
