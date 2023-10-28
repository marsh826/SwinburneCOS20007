namespace MazeGame.nUnitTests
{
    public class LookCommandTests
    {
        private Player _player { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item knife { get; set; } = null!;
        private Item gem { get; set; } = null!;
        private Bag _bag1 { get; set; } = null!;
        private LookCommand look { get; set; } = null!;
        private Location garden { get; set; } = null!;

        [SetUp]
        public void SetUp() 
        {
            _player = new Player("Hoang An", "the comtemplator of infinity");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
            knife = new Item(new string[] { "knife" }, "an obsidian knife", "A knife made of obsidian");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(shovel);
            _player.Inventory.Put(knife);
            look = new LookCommand(new string[] {"look"});
            garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
            _player.ChangeLocation(garden);
        }

        [Test]
        public void Test_LookAtMe()
        {

            string command = "look at me";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo(_player.FullDescription));
            });

            Console.WriteLine(sut.ToString());
        }

        [Test]
        public void Test_LookAtGem()
        {
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _player.Inventory.Put(gem);
            string command = "look at gem";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo(gem.FullDescription));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_LookAtUnk()
        {
            string command = "look at gem";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.That(sut, Is.EqualTo("I can't find the gem"));
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test] 
        public void Test_LookAtGemInMe()
        {
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _player.Inventory.Put(gem);

            string command = "look at gem in inventory";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo(gem.FullDescription));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_LookAtGemInBag()
        {
            _bag1 = new Bag(new string[] { "bag1" }, "brown bag", "a bag made and stiched with leather.");
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _bag1.Inventory.Put(gem);
            _player.Inventory.Put(_bag1);

            string command = "look at gem in bag1";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo(gem.FullDescription));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_LookAtGemInNoBag()
        {
            _bag1 = new Bag(new string[] { "bag1" }, "brown bag", "a bag made and stiched with leather.");
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _bag1.Inventory.Put(gem);
            _player.Inventory.Put(_bag1);

            string command = "look at gem in bag2";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo("I can't find the bag2"));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_LookAtNoGemInBag()
        {
            _bag1 = new Bag(new string[] { "bag1" }, "brown bag", "a bag made and stiched with leather.");
            _player.Inventory.Put(_bag1);

            string command = "look at gem in bag1";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo("I can't find the gem in brown bag"));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_InvalidLook()
        {
            string command = "hi there";
            string command2 = "look in";
            string command3 = "look in here";
            string command4 = "look at this at here";

            string[] array = command.Split(' ');
            string[] array2 = command2.Split(' ');
            string[] array3 = command3.Split(' ');
            string[] array4 = command4.Split(' ');

            var sut = look.Execute(_player, array);
            var sut2 = look.Execute(_player, array2);
            var sut3 = look.Execute(_player, array3);
            var sut4 = look.Execute(_player, array4);

            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.EqualTo("Error in look input"));
                Assert.That(sut2, Is.EqualTo("I don't know how to look like that"));
                Assert.That(sut3, Is.EqualTo("What do you want to look at?"));
                Assert.That(sut4, Is.EqualTo("What do you want to looking in?"));
            });

            Console.WriteLine();
            Console.WriteLine("Lists of possible errors with wrong input");
            Console.WriteLine(sut);
            Console.WriteLine(sut2);
            Console.WriteLine(sut3);
            Console.WriteLine(sut4);
        }
    }
}
