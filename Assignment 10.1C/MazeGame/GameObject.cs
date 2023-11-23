using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MazeGame
{
    public abstract class GameObject : IdentifiableObject
    {
        string _description;
        string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;   
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string ShortDescription
        {
            get { return $"{Name} ({FirstId})"; }
        }

        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
