namespace MazeGame.nUnitTests
{
    public class InventoryTests
    {
        private Inventory _inventory { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item pickaxe { get; set; } = null!;

        [SetUp]
        public void SetUp()
        {
            _inventory = new Inventory();
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
            pickaxe = new Item(new string[] { "pickaxe" }, "an obsidian pickaxe", "A pickaxe made of obsidian");
            _inventory.Put(sword);
            _inventory.Put(shovel);
            _inventory.Put(pickaxe);
        }

        [Test]
        public void Test_FindItem()
        {
            string sampleID = "shovel";
            var sut = _inventory.HasItem(sampleID);
            Assert.That(sut, Is.EqualTo(true));
            Console.WriteLine("Item is in the inventory: " + sut);
        }

        [Test]
        public void Test_NoItemFind()
        {
            string sampleID = "hat";
            var sut = _inventory.HasItem(sampleID);
            Assert.That(sut, Is.EqualTo(false));
            Console.WriteLine("Item is in the inventory: " + sut);
        }

        [Test]
        public void Test_FetchItem()
        {
            string sampleID = "shovel";
            var sut = _inventory.Fetch(sampleID);
            Assert.That(sut, Is.EqualTo(shovel));
            Console.WriteLine("Item fetched from inventory: " + sut.ShortDescription);
        }

        [Test]
        public void Test_TakeItem()
        {
            string sampleID = "pickaxe";
            var sut = _inventory.Take(sampleID);
            Assert.That(sut, Is.EqualTo(pickaxe));
            Console.WriteLine(sut.ShortDescription);
            var itemExist = _inventory.HasItem(sampleID);
            Assert.That(itemExist, Is.EqualTo(false));
            Console.WriteLine("Item still in inventory after Test_TakeItem: " + itemExist);
        }

        [Test] 
        public void Test_ItemList()
        {
            string sampleReturn = 
                $"{sword.Name} ({sword.FirstId})\n" +
                $"{shovel.Name} ({shovel.FirstId})\n" +
                $"{pickaxe.Name} ({pickaxe.FirstId})";
            var sut = _inventory.ItemList;
            Console.WriteLine("Test return: \n" + sut);
            Console.WriteLine();
            Console.WriteLine("Sample return: \n" + sampleReturn);
            Assert.That(sut, Is.EqualTo(sampleReturn));
        }
    }
}
