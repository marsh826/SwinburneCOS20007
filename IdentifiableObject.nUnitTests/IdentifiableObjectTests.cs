using NUnit.Framework;
using IdentifiableObject;

namespace IdentifiableObject.nUnitTests
{
    public class IdentifiableObject
    {
        //IdentifiableObject id = new IdentifiableObject(new string[] { "ID1", "iD2", "Id3", "id4", "id1" });
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AreYou_Test()
        {
            string testID = "id1";
            //var AreYou = id.AreYou(testID);
           // Assert.AreEqual(true, AreYou);
        }
    }
}