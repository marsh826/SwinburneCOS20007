using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace MazeGame.nUnitTests
{
    public class LocationTests
    {
        private Location garden { get; set; } = null!;
        private Item water { get; set; } = null!;
        private Item pearl { get; set; } = null!;
        private Player _player { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item pickaxe { get; set; } = null!;
        private LookCommand look { get; set; } = null!;
        private Bag _bag1 { get; set; } = null!;
        private Item gem { get; set; } = null!;

        [SetUp]
        public void SetUp()
        {
            garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
            water = new Item(new string[] { "water" }, "a bottled water", "A 1 Litres bottle of spring water to keep you hydrated");
            pearl = new Item(new string[] { "pearl" }, "a pearl", "A pearl picked from pearl tree. A fruit great for snack");
            garden.Inventory.Put(water);
            garden.Inventory.Put(pearl);
            _player = new Player("Hoang An", "the comtemplator of infinity");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
            pickaxe = new Item(new string[] { "pickaxe" }, "an obsidian pickaxe", "A pickaxe made of obsidian");
            _player.ChangeLocation(garden);
            _player.Inventory.Put(sword);
            _player.Inventory.Put(shovel);
            _player.Inventory.Put(pickaxe);
            look = new LookCommand(new string[] { "look", "Look" });
        }

        [Test]
        public void Test_LocationIsIdentifiable()
        {
            var sut = garden.AreYou("garden");
            Assert.That(sut, Is.True);
            Console.WriteLine(sut);
        }

        [Test] 
        public void Test_LocationSelfLocate()
        {
            string command = "Look";
            string[] array = command.Split(' ');
            var sut = look.Execute(_player, array);
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut, Is.EqualTo(garden.FullDescription));
            });
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_LocationLocatesItem()
        {
            var sut1 = garden.Locate("water");
            var sut2 = garden.Locate("pearl");
            Assert.Multiple(() =>
            {
                Assert.That(sut1.Description, Is.EqualTo(water.Description));
                Assert.That(sut1.Description, Is.Not.Null);
                Assert.That(sut2.Description, Is.EqualTo(pearl.Description));
                Assert.That(sut2.Description, Is.Not.Null);
            });
            Console.WriteLine($"Water: {sut1.Description}");
            Console.WriteLine($"Pearl: {sut2.Description}");
        }

        [Test]
        public void Test_LocationLocatesUnkItem()
        {
            var sut = garden.Locate("chair");
            Assert.That(sut, Is.Null);
            if(sut == null)
            {
                Console.WriteLine("Item was not found");
            }
        }

        [Test]
        public void Test_PlayerLocatesItemInArea()
        {
            string command1 = "look at water";
            string command2 = "look at pearl";
            string[] array1 = command1.Split(' ');
            string[] array2 = command2.Split(' ');
            var sut1 = look.Execute(_player, array1);
            var sut2 = look.Execute(_player, array2);
            Assert.Multiple(() =>
            {
                Assert.That(sut1, Is.EqualTo(water.Description));
                Assert.That(sut1, Is.Not.Null);
                Assert.That(sut2, Is.EqualTo(pearl.Description));
                Assert.That(sut2, Is.Not.Null);
            });
            Console.WriteLine($"Water: {sut1}");
            Console.WriteLine($"Pearl: {sut2}");
        }

        [Test]
        public void Test_LocationLocatesPlayerItem()
        {
            var sut1 = garden.Locate("sword");
            var sut2 = garden.Locate("shovel");
            var sut3 = garden.Locate("pickaxe");

            Assert.Multiple(() =>
            {
                Assert.That(sut1, Is.Null);
                Assert.That(sut2, Is.Null);
                Assert.That(sut3, Is.Null);
            });
            if(sut1 == null && sut2 == null &&  sut3 == null)
            {
                Console.WriteLine("Sword, shovel, and pickaxe is not found");
            }
        }

        [Test]
        public void Test_LocatesLocationItemInBag()
        {
            _bag1 = new Bag(new string[] { "bag1" }, "brown bag", "a bag made and stiched with leather.");
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _bag1.Inventory.Put(gem);
            _player.Inventory.Put(_bag1);

            string command1 = "look at water in bag1";
            string command2 = "look at pearl in bag1";
            string[] array1 = command1.Split(' ');
            string[] array2 = command2.Split(' ');

            var sut1 = look.Execute(_player, array1);
            var sut2 = look.Execute(_player, array2);

            Assert.Multiple(() =>
            {
                Assert.That(sut1, Is.EqualTo($"I can't find the {water.FirstId} in {_bag1.Name}"));
                Assert.That(sut2, Is.EqualTo($"I can't find the {pearl.FirstId} in {_bag1.Name}"));
            });

            Console.WriteLine(sut1);
            Console.WriteLine(sut2);
        }

        [Test]
        public void Test_LocatesBagItemInLocation()
        {
            _bag1 = new Bag(new string[] { "bag1" }, "brown bag", "a bag made and stiched with leather.");
            gem = new Item(new string[] { "gem" }, "a green gem", "A rare type of gem that can only be obtained through trade");
            _bag1.Inventory.Put(gem);
            _player.Inventory.Put(_bag1);

            var sut = garden.Locate("gem");
            Assert.That(sut, Is.Null);
            if (sut == null)
            {
                Console.WriteLine("Item was not found");
            }
        }
    }
}
