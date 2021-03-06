﻿using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.OverlayNG;
using NUnit.Framework;

namespace NetTopologySuite.Tests.NUnit.Operation.OverlayNG
{
    public class PrecisionReducerTest : GeometryTestCase
    {
        [Test]
        public void TestPolygonBoxEmpty()
        {
            CheckReduce("POLYGON ((1 1.4, 7.3 1.4, 7.3 1.2, 1 1.2, 1 1.4))",
                1, "POLYGON EMPTY");
        }

        [Test]
        public void TestPolygonThinEmpty()
        {
            CheckReduce("POLYGON ((1 1.4, 3.05 1.4, 3 4.1, 6 5, 3.2 4, 3.2 1.4, 7.3 1.4, 7.3 1.2, 1 1.2, 1 1.4))",
                1, "POLYGON EMPTY");
        }


        [Test]
        public void TestPolygonGore()
        {
            CheckReduce("POLYGON ((2 1, 9 1, 9 5, 3 5, 9 5.3, 9 9, 2 9, 2 1))",
                1, "POLYGON ((9 1, 2 1, 2 9, 9 9, 9 5, 9 1))");
        }

        [Test]
        public void TestPolygonGore2()
        {
            CheckReduce("POLYGON ((9 1, 1 1, 1 9, 9 9, 9 5, 5 5.1, 5 4.9, 9 4.9, 9 1))",
                1, "POLYGON ((9 1, 1 1, 1 9, 9 9, 9 5, 9 1))");
        }

        [Test]
        public void TestPolygonGoreToHole()
        {
            CheckReduce("POLYGON ((9 1, 1 1, 1 9, 9 9, 9 5, 5 5.9, 5 4.9, 9 4.9, 9 1))",
                1, "POLYGON ((9 1, 1 1, 1 9, 9 9, 9 5, 9 1), (9 5, 5 6, 5 5, 9 5))");
        }

        [Test]
        public void TestPolygonSpike()
        {
            CheckReduce("POLYGON ((1 1, 9 1, 5 1.4, 5 5, 1 5, 1 1))",
                1, "POLYGON ((5 5, 5 1, 1 1, 1 5, 5 5))");
        }

        [Test]
        public void TestPolygonNarrowHole()
        {
            CheckReduce("POLYGON ((1 9, 9 9, 9 1, 1 1, 1 9), (2 5, 8 5, 8 5.3, 2 5))",
                1, "POLYGON ((9 1, 1 1, 1 9, 9 9, 9 1))");
        }

        [Test]
        public void TestPolygonWideHole()
        {
            CheckReduce("POLYGON ((1 9, 9 9, 9 1, 1 1, 1 9), (2 5, 8 5, 8 5.8, 2 5))",
                1, "POLYGON ((9 1, 1 1, 1 9, 9 9, 9 1), (8 5, 8 6, 2 5, 8 5))");
        }

        [Test]
        public void TestMultiPolygonGap()
        {
            CheckReduce("MULTIPOLYGON (((1 9, 9.1 9.1, 9 9, 9 4, 1 4.3, 1 9)), ((1 1, 1 4, 9 3.6, 9 1, 1 1)))",
                1, "POLYGON ((9 1, 1 1, 1 4, 1 9, 9 9, 9 4, 9 1))");
        }

        [Test]
        public void TestMultiPolygonGapToHole()
        {
            CheckReduce("MULTIPOLYGON (((1 9, 9 9, 9.05 4.35, 6 4.35, 4 6, 2.6 4.25, 1 4, 1 9)), ((1 1, 1 4, 9 4, 9 1, 1 1)))",
                1, "POLYGON ((9 1, 1 1, 1 4, 1 9, 9 9, 9 4, 9 1), (6 4, 4 6, 3 4, 6 4))");
        }

        [Test]
        public void TestLine()
        {
            CheckReduce("LINESTRING(-3 6, 9 1)",
                0.5, "LINESTRING (-2 6, 10 2)");
        }

        [Test]
        public void TestCollapsedLine()
        {
            CheckReduce("LINESTRING(1 1, 1 9, 1.1 1)",
                1, "LINESTRING (1 1, 1 9)");
        }

        [Test]
        public void TestCollapsedNodedLine()
        {
            CheckReduce("LINESTRING(1 1, 3 3, 9 9, 5.1 5, 2.1 2)",
                1, "MULTILINESTRING ((1 1, 2 2), (2 2, 3 3), (3 3, 5 5), (5 5, 9 9))");
        }

        private void CheckReduce(string wkt, double scaleFactor, string wktExpected)
        {
            var geom = Read(wkt);
            var expected = Read(wktExpected);
            var pm = new PrecisionModel(scaleFactor);
            var result = PrecisionReducer.ReducePrecision(geom, pm);
            CheckEqual(expected, result);
        }
    }
}
