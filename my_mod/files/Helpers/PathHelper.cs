using UnityEngine;
using System.Linq;
using System.IO;

namespace welp
{
    public class PathHelp
    {
        public static string GetMedallionFile(string medallion)
        {
            return Path.Combine("sprites", "colletables", medallion);
        }
    }
}