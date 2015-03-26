using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Model
{
    public class Сalculation
    {
        public long ID { get; set; }

        public virtual CalculationType CalculationType { get; set; }
        public virtual ApplicationUser Creator { get; set; }
    }
}
