namespace MazeGame.nUnitTests
{
    public class ItemTests
    {
        private Item _item { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
        }

        [Test]
        public void Test_Identifiable()
        {
            var sut = _item.AreYou(_item.FirstId);
            Assert.That(sut, Is.EqualTo(true));
        }

        [Test]
        public void Test_ShortDescription()
        {
            string sample = "a bronze sword (sword)";
            var sut = _item.ShortDescription;
            Assert.That(sut, Is.EqualTo(sample));
            Console.WriteLine(sut);
        }

        [Test] 
        public void Test_FullDescription()
        {
            string sample = "A short sword cast from bronze";
            var sut = _item.FullDescription;
            Assert.That(sut, Is.EqualTo(sample));
            Console.WriteLine(sut);
        }

    }
}
