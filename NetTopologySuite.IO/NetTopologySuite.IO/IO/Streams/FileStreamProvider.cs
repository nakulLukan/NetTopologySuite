﻿using System;
using System.IO;
using NetTopologySuite.Utilities;

namespace NetTopologySuite.IO.Streams
{
    public class FileStreamProvider : IStreamProvider
    {
        public FileStreamProvider(string kind, string path, bool validatePath = false)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (path.IsNullOrWhitespaceNTS())
                throw new ArgumentException("Invalid Path", "path");

            if (validatePath && !File.Exists(path))
                throw new FileNotFoundException(path);

            Kind = kind;
            Path = path;
        }

        public string Path { get; private set; }

        public bool UnderlyingStreamIsReadonly
        {
            get { return false; }
        }

        public Stream OpenRead()
        {
            return File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public Stream OpenWrite(bool truncate)
        {
            if (truncate)
            {
                return File.Open(Path, FileMode.Create, FileAccess.Write, FileShare.None);
            }
            return File.Open(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite); //jd: I would like to use FileShare.None however the GeoTools shapefilewriter writes a dummy file while holding an existing handle
        }

        public string Kind { get; private set; }
    }
}