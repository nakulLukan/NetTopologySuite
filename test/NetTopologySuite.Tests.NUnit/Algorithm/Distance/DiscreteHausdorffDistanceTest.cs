using NetTopologySuite.Algorithm.Distance;
using NetTopologySuite.Tests.NUnit.Utilities;
using NUnit.Framework;

namespace NetTopologySuite.Tests.NUnit.Algorithm.Distance
{
    public class DiscreteHausdorffDistanceTest
    {
        [Test]
        public void TestLineSegments()
        {
            RunTest("LINESTRING (0 0, 2 1)", "LINESTRING (0 0, 2 0)", 1.0);
        }

        [Test]
        public void TestLineSegments2()
        {
            RunTest("LINESTRING (0 0, 2 0)", "LINESTRING (0 1, 1 2, 2 1)", 2.0);
        }

        [Test]
        public void TestLinePoints()
        {
            RunTest("LINESTRING (0 0, 2 0)", "MULTIPOINT (0 1, 1 0, 2 1)", 1.0);
        }

        /*
        * Shows effects of limiting HD to vertices
        * Answer is not true Hausdorff distance.
        *
        * @
        */
        [Test]
        public void TestLinesShowingDiscretenessEffect()
        {
            RunTest("LINESTRING (130 0, 0 0, 0 150)", "LINESTRING (10 10, 10 150, 130 10)", 14.142135623730951);
            // densifying provides accurate HD
            RunTest("LINESTRING (130 0, 0 0, 0 150)", "LINESTRING (10 10, 10 150, 130 10)", 0.5, 70.0);
        }

        private static double TOLERANCE = 0.00001;

        private void RunTest(string wkt1, string wkt2, double expectedDistance)
        {
            var g1 = IOUtil.ReadWKT(wkt1);
            var g2 = IOUtil.ReadWKT(wkt2);

            double distance = DiscreteHausdorffDistance.Distance(g1, g2);
            Assert.AreEqual(distance, expectedDistance, TOLERANCE);
        }

        private void RunTest(string wkt1, string wkt2, double densifyFrac, double expectedDistance)
        {
            var g1 = IOUtil.ReadWKT(wkt1);
            var g2 = IOUtil.ReadWKT(wkt2);

            double distance = DiscreteHausdorffDistance.Distance(g1, g2, densifyFrac);
            Assert.AreEqual(distance, expectedDistance, TOLERANCE);
        }
    }
}
