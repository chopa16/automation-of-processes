using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProcessInfo
{

    public enum Color { Red, Blue, Yellow }

    public class TypeConstructor
    {
        static TypeConstructor()
        {
            Composition = new TypeConstructor { id = 1 };
            Parallel = new TypeConstructor { id = 2 };
        }

        public static TypeConstructor Composition { get; }
        public static TypeConstructor Parallel { get; }

        private int id;
    }


    class ComplexProcessInfo : ProcessInfo
    {
        
        public List<SimpleProcessInfo> S;
        public TypeConstructor Constructor;
        public ComplexProcessInfo(List<ArgInfo> args, Type resultType, List<SimpleProcessInfo> s, string nameOfSimpleProcess, TypeConstructor constructor) :base(args, nameOfSimpleProcess, resultType)
            {
            S = s;
            Constructor = constructor;
            }
    }
    
}
    
  