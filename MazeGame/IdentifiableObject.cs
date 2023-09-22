using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class IdentifiableObject
    {
        List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (var ident in idents)
            {
                if(!AreYou(ident))
                {
                    AddIdentifier(ident);
                } 
                else
                {
                    Console.WriteLine($"{ident} already exist in List");
                }
            }

        }

        private bool AreYou(string id)
        {
            foreach (var ident in _identifiers)
            {
                if (ident.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddIdentifier(string id)
        {
            string idLowerCase = id.ToLower();
            _identifiers.Add(idLowerCase);
            Console.WriteLine($"Successfully added {idLowerCase} into List");
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "No Identifier available";
                }
                else
                {
                    return _identifiers.ElementAt(0);
                }
            }    
        }
    }
}
