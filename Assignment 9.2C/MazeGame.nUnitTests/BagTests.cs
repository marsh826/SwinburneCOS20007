namespace MazeGame.nUnitTests
{
    public class BagTests
    {
        private Bag _bag1 { get; set; } = null!;
        private Item sword { get; set; } = null!;
        private Item shovel { get; set; } = null!;
        private Item pickaxe { get; set; } = null!;
        [SetUp] 
        public void SetUp() 
        {
            _bag1 = new Bag(new string[] { "b1" }, "brown bag", "a bag made and stiched with leather.");
            sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
            shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
            pickaxe = new Item(new string[] { "pickaxe" }, "an obsidian pickaxe", "A pickaxe made of obsidian");
            _bag1.Inventory.Put(sword);
            _bag1.Inventory.Put(shovel);
            _bag1.Inventory.Put(pickaxe);
        }

        [Test]
        public void Test_LocatesItems()
        {
            string sampleID = "sword";
            var sut = _bag1.Locate(sampleID);
            Assert.That(sut, Is.EqualTo(sword));
            Console.WriteLine(sut.ShortDescription);
        }

        [Test]
        public void Test_SelfLocates()
        {
            string sampleID = "b1";
            var sut = _bag1.Locate(sampleID);
            Assert.That(sut, Is.EqualTo(_bag1));
            Console.WriteLine(sut.ShortDescription);
        }

        [Test]
        public void Test_LocatesNothing()
        {
            string samepleID = "b123";
            var sut = _bag1.Locate(samepleID);
            Assert.IsNull(sut);
            if (sut == null)
            {
                Console.WriteLine("Bag returned null value");
            }
        }

        [Test]
        public void Test_FullDescription()
        {
            var sut = _bag1.FullDescription;
            Assert.IsNotNull(sut);
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_BagInBag()
        {
            Bag _bag2 = new Bag(new string[] { "b2" }, "backpack", "A bag with high durability and storage capacity");
            Item bat = new Item(new string[] { "bat" }, "a baseball bat", "A baseball bat made of wood");
            Item flashlight = new Item(new string[] { "flashlight" }, "a flashlight", "A UV flashlight that shines brightly at night");
            _bag2.Inventory.Put(bat);
            _bag2.Inventory.Put(flashlight);
            _bag1.Inventory.Put(_bag2);

            var sut1 = _bag1.Locate("b2");
            Assert.IsNotNull(sut1);
            Console.WriteLine("Located bag2 in bag1: {0}", sut1.ShortDescription);

            var sut2 = _bag1.Locate("shovel");
            Assert.That(sut2.Name, Is.EqualTo("a shovel"));
            Console.WriteLine("Locate existing item in bag1: {0}", sut2.ShortDescription );

            var sut3 = _bag1.Locate("flashlight");
            Assert.IsNull(sut3);
            if(sut3 == null)
            {
                Console.WriteLine("bag2's items can not be found in bag1");
            }
        }
    }
}
