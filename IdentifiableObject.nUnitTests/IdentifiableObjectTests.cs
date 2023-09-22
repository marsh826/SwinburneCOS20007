using NUnit.Framework;
using IdentifiableObject;

namespace IdentifiableObject.nUnitTests
{
    public class IdentifiableObject
    {
        List<string> ids = new List<string>();
        IdentifiableObject idList = new IdentifiableObject();
        [SetUp]
        public void Setup()
        {
            string[] idArray = new string[] { "ID1", "iD2", "Id3", "id4", "id1" };
            ids = new List<string>(idArray);
        }

        [Test]
        public void AreYou_Test()
        {
            string testID = "id1";
            var sut = ids;
            var result = 
           // Assert.AreEqual(true, AreYou);
        }
    }
}