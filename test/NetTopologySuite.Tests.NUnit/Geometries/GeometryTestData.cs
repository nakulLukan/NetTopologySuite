﻿namespace NetTopologySuite.Tests.NUnit.Geometries
{
    public class GeometryTestData
    {

        public const string WKT_POINT = "POINT (10 10)";
        public const string WKT_POINT_EMPTY = "POINT EMPTY";

        public const string WKT_LINESTRING = "LINESTRING (10 10, 20 20, 30 40)";
        public const string WKT_LINESTRING_EMPTY = "LINESTRING EMPTY";

        public const string WKT_LINEARRING = "LINEARRING (10 10, 20 20, 30 40, 10 10)";
        public const string WKT_LINEARRING_EMPTY = "LINEARRING EMPTY";

        public const string WKT_POLY = "POLYGON ((50 50, 50 150, 150 150, 150 50, 50 50))";

        public const string WKT_POLY_HOLE =
            "POLYGON ((50 50, 50 150, 150 150, 150 50, 50 50), (70 130, 130 130, 130 70, 70 70, 70 130))";

        public const string WKT_POLY_HOLE2 =
            "POLYGON ((50 50, 50 150, 150 150, 150 50, 50 50), (60 140, 90 140, 90 110, 60 110, 60 140), (110 90, 140 90, 140 60, 110 60, 110 90))";

        public const string WKT_POLY_EMPTY = "POLYGON EMPTY";

        public const string WKT_MULTIPOINT = "MULTIPOINT ((10 10), (20 20))";
        public const string WKT_MULTIPOINT_SINGLE = "MULTIPOINT ((10 10))";
        public const string WKT_MULTIPOINT_EMPTY = "MULTIPOINT EMPTY";

        public const string WKT_MULTILINESTRING = "MULTILINESTRING ((10 10, 20 20), (15 15, 30 15))";
        public const string WKT_MULTILINESTRING_SINGLE = "MULTILINESTRING ((10 10, 20 20))";
        public const string WKT_MULTILINESTRING_EMPTY = "MULTILINESTRING EMPTY";

        public const string WKT_MULTIPOLYGON =
            "MULTIPOLYGON (((10 10, 10 20, 20 20, 20 15, 10 10)), ((60 60, 70 70, 80 60, 60 60)))";

        public const string WKT_MULTIPOLYGON_SINGLE = "MULTIPOLYGON (((10 10, 10 20, 20 20, 20 15, 10 10)))";
        public const string WKT_MULTIPOLYGON_EMPTY = "MULTIPOLYGON EMPTY";

        public const string WKT_GC =
            "GEOMETRYCOLLECTION (POLYGON ((100 200, 200 200, 200 100, 100 100, 100 200)), LINESTRING (150 250, 250 250))";

        public const string WKT_GC_ALP =
            "GEOMETRYCOLLECTION (POLYGON ((100 200, 200 200, 200 100, 100 100, 100 200)), LINESTRING (150 250, 250 250), POINT (1 1))";

        public const string WKT_GC_NESTED =
            "GEOMETRYCOLLECTION (LINESTRING (1 1, 2 2), GEOMETRYCOLLECTION (POLYGON ((100 200, 200 200, 200 100, 100 100, 100 200)), LINESTRING (150 250, 250 250), POINT (1 1)))";

        public const string WKT_GC_EMPTY = "GEOMETRYCOLLECTION EMPTY";

        public static readonly string[] WKT_ALL =
        {
            WKT_POINT, WKT_POINT_EMPTY,
            WKT_LINESTRING, WKT_LINESTRING_EMPTY,
            WKT_LINEARRING, WKT_LINEARRING_EMPTY,
            WKT_POLY, WKT_POLY_HOLE, WKT_POLY_HOLE2, WKT_POLY_EMPTY,
            WKT_MULTIPOINT, WKT_MULTIPOINT_SINGLE, WKT_MULTIPOINT_EMPTY,
            WKT_MULTILINESTRING, WKT_MULTILINESTRING_SINGLE, WKT_MULTILINESTRING_EMPTY,
            WKT_MULTIPOLYGON, WKT_MULTIPOLYGON_SINGLE, WKT_MULTIPOLYGON_EMPTY,
            WKT_GC, WKT_GC_ALP, WKT_GC_NESTED, WKT_GC_EMPTY
        };
    }
}
