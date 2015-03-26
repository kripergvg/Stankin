using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Model
{
    public class DocumentType
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int MaxPoint { get; set; }
        public virtual IList<IndicatorGroup> IndicatorsGroups { get; set; }
        public virtual IList<Document> Documents { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
