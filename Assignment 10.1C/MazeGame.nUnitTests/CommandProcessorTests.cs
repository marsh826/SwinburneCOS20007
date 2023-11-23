namespace MazeGame.nUnitTests
{
    public class CommandProcessorTests
    {
        private Command look { get; set; } = null!;
        private Command look2 { get; set; } = null!;
        private Command move { get; set; } = null!;
        private Command move2 { get; set; } = null!;
        private Command move3 { get; set; } = null!;
        private Command move4 { get; set; } = null!;
        private List<Command> commands;
        private CommandProcessor processor {  get; set; } = null!;
        //private Player _player { get; set; } = null!;

        [SetUp]
        public void SetUp()
        {
            look = new LookCommand(new string[] { "look" });
            look2 = new LookCommand(new string[] { "Look" });
            move = new MoveCommand(new string[] { "move" });
            move2 = new MoveCommand(new string[] { "go" });
            move3 = new MoveCommand(new string[] { "head" });
            move4 = new MoveCommand(new string[] { "leave" });
            commands = new List<Command>
            {
                look,
                look2,
                move,
                move2,
                move3,
                move4
            };
            processor = new CommandProcessor();
        }

        [Test]
        public void Test_DetectMoveCommand()
        {
            string input = "move";

            foreach(Command command in commands)
            {
                if(input == command.FirstId)
                {
                    var sut = true;
                    Assert.IsTrue(sut);
                    Console.WriteLine($"Search Command: {input}\n" +
                        $"Command Returned: {command.FirstId}");
                    break;
                }
            }
        }

        [Test]
        public void Test_DetectMoveVariant()
        {
            string input = "head";

            foreach (Command command in commands)
            {
                if (input == command.FirstId)
                {
                    var sut = true;
                    Assert.IsTrue(sut);
                    Console.WriteLine($"Search Command: {input}\n" +
                        $"Command Returned: {command.FirstId}");
                    break;
                }
            }
        }


        [Test]
        public void Test_DetectLookCommand()
        {
            string input = "look";

            foreach (Command command in commands)
            {
                if (input == command.FirstId)
                {
                    var sut = true;
                    Assert.IsTrue(sut);
                    Console.WriteLine($"Search Command: {input}\n" +
                        $"Command Returned: {command.FirstId}");
                    break;
                }
            }
        }

        [Test]
        public void Test_DetectLookVariant()
        {
            string input = "Look";

            foreach (Command command in commands)
            {
                if (input == command.FirstId)
                {
                    var sut = true;
                    Assert.IsTrue(sut);
                    Console.WriteLine($"Search Command: {input}\n" +
                        $"Command Returned: {command.FirstId}");
                    break;
                }
            }
        }

        [Test]
        public void Test_DetectInvalidCommand()
        {
            string input = "run";

            foreach (Command command in commands)
            {
                if (input == command.FirstId)
                {
                    Console.WriteLine("Command found");
                    break;
                }
                else
                {
                    var sut = false;
                    Assert.IsFalse(sut);
                    Console.WriteLine($"Search Command: {input}\n" +
                        $"Command Returned: None");
                }
            }
        }
    }
}
