namespace MazeGame.nUnitTests
{
    public class LookCommandTests
    {
        private Player _player { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item knife { get; set; } = null!;
        private Item gem { get; set; } = null!;
        private LookCommand look { get; set; } = null!;
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
        }

        [Test]
        public void Test_LookAtMe()
        {
            var sut = look.LookAtIn("me", _player);
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
            var sut = look.LookAtIn("gem", _player);
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
            var sut = look.LookAtIn("gem", _player);
            Assert.That(sut, Is.EqualTo("I can't find the gem"));
            Console.WriteLine();
            Console.WriteLine(sut);
        }

        [Test] 
        public void Test_LookAtGemInMe()
        {
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _player.Inventory.Put(gem);

            ///Look at gem in inventory
            var sut = look.FetchContainer(_player, "gem");
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(sut);
                Assert.That(sut, Is.EqualTo(gem));
            });
            Console.WriteLine();
            Console.WriteLine(sut);
        }
    }
}
