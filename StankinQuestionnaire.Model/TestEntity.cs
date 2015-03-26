using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Model
{
   public class TestEntity
    {
        public long ID { get; set; }
        public virtual Indicator Indicator { get; set; }
    }
}
