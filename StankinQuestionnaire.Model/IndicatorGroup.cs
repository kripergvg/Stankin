using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace StankinQuestionnaire.Model
{
    public class IndicatorGroup
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public virtual IList<Indicator> Indicators { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public DateTime DateChanged { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
