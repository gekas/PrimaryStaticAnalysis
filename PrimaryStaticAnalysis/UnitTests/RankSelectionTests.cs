using NUnit.Framework;
using PrimaryStaticAnalysis.BL;
using System.Linq;

namespace PrimaryStaticAnalysis.UnitTests
{
    [TestFixture]
    public class RankSelectionTests
    {
        [Test]
        public void TestMethod()
        {
            var arr1 = new double[]{ 10,3,18,-1,20,10,3}.ToList();
            var arr2 = new double[] { 15,7,0,10,25,9 }.ToList();

            RankSelection rs = new RankSelection();
            var fstSelectionNumber = rs.AddSelection(arr1);
            var scndSelectionNumber = rs.AddSelection(arr2);
        }
    }
}
