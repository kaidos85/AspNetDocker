using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreDocker.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Konstruktiv { get; set; }
        public string AssemblyCode { get; set; }
        public string ResourceCode { get; set; }
    }
}
