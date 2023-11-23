using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class CommandProcessor
    {
        private List<Command> commands;
        private Command? _currentTypes;

        public CommandProcessor()
        {
            _currentTypes = null;

            Command look = new LookCommand(new string[] { "look" });
            Command look2 = new LookCommand(new string[] { "Look" });
            Command move = new MoveCommand(new string[] { "move" });
            Command move2 = new MoveCommand(new string[] {"go" });
            Command move3 = new MoveCommand(new string[] { "head" });
            Command move4 = new MoveCommand(new string[] { "leave" });

            commands = new List<Command>
            {
                look,
                look2,
                move,
                move2,
                move3,
                move4
            };
        }

        public string Execute(Player p, string[] text)
        {
            foreach (var command in commands)
            {
                if(string.Equals(text[0], command.FirstId, StringComparison.OrdinalIgnoreCase))
                {
                    _currentTypes = command;
                }
            }

            if (_currentTypes == null)
            {
               return "Please input a valid command type (move or look)\n";
            }
            else
            {
                return _currentTypes.Execute(p, text);
            }
        }
    }
}
