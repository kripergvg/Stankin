using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StankinQuestionnaire.Model
{
    public class CalculationType
    {
        public long ID { get; set; }
        public string UnitName { get; set; }
        public int Point { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }

        public virtual Indicator Indicator { get; set; }
        public virtual IList<Сalculation> Calculations { get; set; }
    }
}
