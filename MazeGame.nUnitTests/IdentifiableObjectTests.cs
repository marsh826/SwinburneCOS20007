namespace MazeGame.nUnitTests
{
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _idList { get; set; } = null!;
        private IdentifiableObject _idList2 { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            _idList = new IdentifiableObject(new string[] { "ID1", "iD2", "Id3", "id4", "id1" });
        }

        [Test]
        public void TestEqual_AreYou()
        {
            //Assign
            string testID = "id1";

            //Act
            //SUT = System Under Test
            var sut = _idList.AreYou(testID);

            //Assert
            Assert.That(sut, Is.EqualTo(true));
        }

        [Test]
        public void TestNotEqual_AreYou()
        {
            string testID = "id5";
            var sut = _idList.AreYou(testID);
            Assert.That(sut, Is.EqualTo(false));
        }

        [Test]
        public void TestCaseSensitive_AreYou()
        {
            string testID = "iD3";
            var sut = _idList.AreYou(testID);
            Assert.That(sut, Is.EqualTo(false));
        }

        [Test]
        public void TestReturn_FirstID()
        {
            string expectedID = "id1";
            var sut = _idList.FirstId;
            Assert.That(sut, Is.EqualTo(expectedID));
        }

        [Test]
        public void TestReturnNoIDs_FirstID()
        {
            _idList2 = new IdentifiableObject(new string[0] { });
            var sut = _idList2.FirstId;
            Assert.That(sut, Is.EqualTo(""));
        }


        [Test]
        public void Test_AddID()
        {
            string newID = "id6";
            _idList.AddIdentifier(newID);
            var sut = _idList.AreYou(newID);
            Assert.That(sut, Is.EqualTo(true));
        }
    }
}