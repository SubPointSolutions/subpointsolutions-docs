using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubPointSolutions.Docs.Code.Metadata
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class SampleParentDefinitionTagAttribute : Attribute
    {
        public Type DefinitionType { get; set; }
    }
}
