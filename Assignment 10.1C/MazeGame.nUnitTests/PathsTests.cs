
namespace MazeGame.nUnitTests
{
    public class PathsTests
    {
        private Player _player { get; set; } = null!;
        private Location garden { get; set; } = null!;
        private Item water { get; set; } = null!;
        private Item pearl { get; set; } = null!;
        private Location area51 { get; set; } = null!;
        private Location library { get; set; } = null!;
        private Item book { get; set; } = null!;
        private Paths gardenPath1 { get; set; } = null!;
        private Paths gardenPath2 { get; set; } = null!;
        private Paths area51Path1 { get; set; } = null!;
        private MoveCommand move { get; set; } = null!;
        private Paths libraryPath1 { get; set; } = null!;

        [SetUp]
        public void SetUp()
        {
            //Location 1
            garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
            water = new Item(new string[] { "water" }, "a bottled water", "A 1 Litres bottle of spring water to keep you hydrated");
            pearl = new Item(new string[] { "pearl" }, "a pearl", "A pearl picked from pearl tree. A fruit great for snack");
            garden.Inventory.Put(water);
            garden.Inventory.Put(pearl);

            //Location 2
            area51 = new Location(new string[] { "area51" }, "area 51", "Special labratory for aliens");

            //Location 3
            library = new Location(new string[] { "library" }, "archive library", "area that contains old history book");
            book = new Item(new string[] { "book" }, "a history book", "A book that captures the history of this city");
            library.Inventory.Put(book);

            //Paths in Garden
            gardenPath1 = new Paths(new string[] { "n" }, "north",
                "You got in your car and travelled through the road up North", area51);
            gardenPath2 = new Paths(new string[] { "e" }, "east",
                "You walked for a kilometer to a library in East", library);
            garden.PathList.Add(gardenPath1);
            garden.PathList.Add(gardenPath2);

            //Paths in Area51
            area51Path1 = new Paths(new string[] { "s" }, "south",
                "You got in your car and travelled through the road down South", garden);
            area51.PathList.Add(area51Path1);

            //Paths in Library
            libraryPath1 = new Paths(new string[] { "w" }, "west",
                "You walked for a kilometer to a garden in East.", garden);
            library.PathList.Add(libraryPath1);

            //Command
            move = new MoveCommand(new string[] { "move", "go", "head", "leave" });

            //Player
            _player = new Player("Hoang An", "the comtemplator of infinity");
            _player.ChangeLocation(garden);
        }

        [Test]
        public void Test_PathIdentifiable()
        {
            var sut1 = gardenPath1.AreYou("n");
            var sut2 = gardenPath2.AreYou("e");
            var sut3 = area51Path1.AreYou("s");
            var sut4 = libraryPath1.AreYou("w");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(sut1);
                Assert.IsTrue(sut2);
                Assert.IsTrue(sut3);
                Assert.IsTrue(sut4);
            });
        }


        [Test]
        public void Test_InsensitiveCase()
        {
            Console.WriteLine("Input: mOvE");
            Console.WriteLine($"Before moving north: {_player.CurrentLocation.Name}");
            var sut = move.Execute(_player, new string[] { "mOvE", "n" });
            string expectedPath = $"You travelled towards {gardenPath1.Name}\n" +
                            $"{gardenPath1.Description}\n" +
                            $"Items available in this area:\n{gardenPath1.LinkedArea.Inventory.ItemList}\n";

            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.EqualTo(expectedPath));
                Assert.That(_player.CurrentLocation, Is.EqualTo(area51));
            });
            Console.WriteLine($"After moving north: {_player.CurrentLocation.Name}");
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_MoveByPathID()
        {
            Console.WriteLine($"Before moving east: {_player.CurrentLocation.Name}");
            var sut = move.Execute(_player, new string[] { "move", "e" });
            string expectedPath = $"You travelled towards {gardenPath2.Name}\n" +
                            $"{gardenPath2.Description}\n" +
                            $"Items available in this area:\n{gardenPath2.LinkedArea.Inventory.ItemList}\n";

            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.EqualTo(expectedPath));
                Assert.That(_player.CurrentLocation, Is.EqualTo(library));
            });
            Console.WriteLine($"After moving east: {_player.CurrentLocation.Name}");
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_MoveByPathName()
        {
            Console.WriteLine($"Before moving east: {_player.CurrentLocation.Name}");
            var sut = move.Execute(_player, new string[] { "move", "east" });
            string expectedPath = $"You travelled towards {gardenPath2.Name}\n" +
                            $"{gardenPath2.Description}\n" +
                            $"Items available in this area:\n{gardenPath2.LinkedArea.Inventory.ItemList}\n";

            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.EqualTo(expectedPath));
                Assert.That(_player.CurrentLocation, Is.EqualTo(library));
            });
            Console.WriteLine($"After moving east: {_player.CurrentLocation.Name}");
            Console.WriteLine(sut);
        }

        [Test]
        public void Test_InvalidPath()
        {
            Console.WriteLine($"Before moving south: {_player.CurrentLocation.Name}");
            var sut = move.Execute(_player, new string[] { "move", "south" });
            string expectedPath = "I can't find path: south";
            Assert.That(sut, Is.EqualTo(expectedPath));
            Console.WriteLine(sut);
        }
    }
}
