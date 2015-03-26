using StankinQuestionnaire.Data.Repository;
using StankinQuestionnaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StankinQuestionnaire.Service
{
    public interface IDocumentTypeService
    {
        DocumentType GetDocumentType(long documentTypeID);
        IEnumerable<DocumentType> GetDocumentTypes(Expression<Func<DocumentType, bool>> where = null);
    }

    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            this._documentTypeRepository = documentTypeRepository;
        }

        public DocumentType GetDocumentType(long documentTypeID)
        {
            return _documentTypeRepository.GetById(documentTypeID);
        }

        public IEnumerable<DocumentType> GetDocumentTypes(Expression<Func<DocumentType, bool>> where = null)
        {
            if (where == null)
            {
                return _documentTypeRepository.GetMany();
            }
            return _documentTypeRepository.GetMany(where);
        }
    }

}
