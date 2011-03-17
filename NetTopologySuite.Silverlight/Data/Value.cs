﻿using System;

namespace GisSharpBlog.NetTopologySuite.Data
{
    internal class Value<T> : IValue<T>
    {
        private readonly T _value;
        internal Value(T value)
        {
            _value = value;
        }

        T IValue<T>.Value
        {
            get { return _value; }
        }

        object IValue.Value
        {
            get { return ((IValue<T>)this).Value; }
        }

        public Type Type
        {
            get { return typeof (T); }
        }
    }
}