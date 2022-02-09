using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInfo
{
    //[DataContract]
    class SaveSPInfotoSQL
    {
        //[DataMember]
        public string Chop { get; set; }
        //[DataMember]
        public int Age { get; set; }

    }
}
