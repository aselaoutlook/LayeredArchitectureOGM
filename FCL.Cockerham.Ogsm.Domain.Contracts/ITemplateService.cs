using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface ITemplateService
    {
        TemplateDto CreateTemplate(TemplateDto _template, IUnitOfWork _dataRepositoryFactory);
        TemplateDto UpdateTemplate(TemplateDto _template, IUnitOfWork _dataRepositoryFactory);
        TemplateDto UpdateTemplate(TemplateDto _template, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        TemplateDto GetTemplateByTemplateId(long _templateId, IUnitOfWork _dataRepositoryFactory);
        ICollection<TemplateDto> GetAllTemplates(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<TemplateDto> GetTemplateList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetTemplateCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}