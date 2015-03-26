using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Model
{
    public class Indicator
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int MaxPoint { get; set; }
        public string Comment { get; set; }
        public DateTime DateChanged { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual IList<CalculationType> CalculationTypes { get; set; }
        public virtual IList<TestEntity> TestEntitys { get; set; }
        public virtual IndicatorGroup IndicatorGroup { get; set; }
    }
}
