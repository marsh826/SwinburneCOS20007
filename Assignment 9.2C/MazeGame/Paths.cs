using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Paths : GameObject 
    {
        private Location _location;
        public Paths(string[] ids, string name, string desc, Location location) : base(ids, name, desc)
        {
            _location = location;
        }

        public Location LinkedArea
        {
            get { return _location; }
        }

    }
}
