using StankinQuestionnaire.Data.Infrastructure;
using StankinQuestionnaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Data.Repository
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
    }
    public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
