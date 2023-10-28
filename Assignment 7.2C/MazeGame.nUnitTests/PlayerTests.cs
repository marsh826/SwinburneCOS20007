namespace MazeGame.nUnitTests
{
    public class PlayerTests
    {
        private Player _player { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item pickaxe { get; set; } = null!;
        private Location garden { get; set; } = null!;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Hoang An", "the comtemplator of infinity");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
            pickaxe = new Item(new string[] { "pickaxe" }, "an obsidian pickaxe", "A pickaxe made of obsidian");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(shovel);
            _player.Inventory.Put(pickaxe);
            garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
            _player.ChangeLocation(garden);
        }

        [Test]
        public void Test_Identifiable()
        {
            string id_ME = "me";
            var sut1 = _player.AreYou(id_ME);
            string id_INV = "inventory";
            var sut2 = _player.AreYou(id_INV);
            Assert.That(sut1, Is.EqualTo(true));
            Assert.That(sut2, Is.EqualTo(true));
        }

        [Test]
        public void Test_LocateItems()
        {
            string sampleID = "sword";
            var sut = _player.Locate(sampleID);
            Assert.That(sut.FirstId, Is.EqualTo(sampleID));
            Console.WriteLine(sut.FullDescription);
        }

        [Test]
        public void Test_LocateItself()
        {
            string id_ME = "me";
            var sut1 = _player.Locate(id_ME);
            string id_INV = "inventory";
            var sut2 = _player.Locate(id_INV);
            Assert.IsNotNull(sut1);
            Assert.IsNotNull(sut2);
            Console.WriteLine($"Player (me): {sut1.ShortDescription}");
            Console.WriteLine();
            Console.WriteLine("Inventory (inventory): \n" + sut2.FullDescription);
        }

        [Test]
        public void Test_LocateNothing() 
        {
            string sampleID = "shoe";
            var sut = _player.Locate(sampleID);
            Assert.IsNull(sut);
        }

        [Test]
        public void Test_FullDescription()
        {
            string sample = "You are Hoang An the comtemplator of infinity\n" +
                "You are carrying: \n" +
                "a bronze sword (sword)\n" +
                "a shovel (shovel)\n" +
                "an obsidian pickaxe (pickaxe)";
            var sut = _player.FullDescription;
            Assert.IsNotNull(sut);
            Assert.That(sut, Is.EqualTo(sample));
            Console.WriteLine($"Sample return: \n" +
                $"{sample}");
            Console.WriteLine();
            Console.WriteLine($"Test return: \n" +
                $"{sut}");
        }
    }
}
