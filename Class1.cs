using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //[DataContract]
    class WriteInMongoDb
    {
        //[DataMember]
        public string MyName { get; set; }

        //[DataMember]
        public int Course { get; set; }
    }
}
