using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    interface IHaveInventory
    {
        GameObject Locate(string id);
        public string Name
        {
            get { return Name; }
        }
    }
}
