using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensSkabelon
{
    //static betyder at klassen ikke kan instantieres og kun kan indeholde static medlemmer
    public static class Secret
    {
        private static string _connectionString = "indsæt connectionstring";

        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
