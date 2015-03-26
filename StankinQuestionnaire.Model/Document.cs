using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Model
{
    public class Document
    {
        public long ID { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ApplicationUser Creator { get; set; }
    }
}
