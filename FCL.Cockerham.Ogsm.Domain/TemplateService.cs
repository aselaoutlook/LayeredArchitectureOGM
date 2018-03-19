using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(ITemplateService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TemplateService
    {
        public TemplateDto CreateTemplate(TemplateDto _template, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            TemplateDto _createdTemplate = Mapper.Map<TemplateDto>(TemplateService.Add(Mapper.Map<Template>(_template)));

            return _createdTemplate;
        }

        public TemplateDto UpdateTemplate(TemplateDto _template, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            TemplateDto _updatedTemplate = Mapper.Map<TemplateDto>(TemplateService.Update(Mapper.Map<Template>(_template)));

            return _updatedTemplate;
        }

        public TemplateDto UpdateTemplate(TemplateDto _template, long _templateId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            TemplateDto _updatedTemplate = Mapper.Map<TemplateDto>(TemplateService.Update(Mapper.Map<Template>(_template), _templateId));

            return _updatedTemplate;
        }

        public TemplateDto GetTemplateByTemplateId(long _templateId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            TemplateDto _template = Mapper.Map<TemplateDto>(TemplateService.GetSingle(_templateId));

            return _template;
        }

        public ICollection<TemplateDto> GetAllTemplates(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            ICollection<TemplateDto> _allTemplates = Mapper.Map<ICollection<TemplateDto>>(TemplateService.GetAll());

            return _allTemplates;
        }

        public IEnumerable<TemplateDto> GetTemplateList(int pageNo, int pageSize, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            IEnumerable<TemplateDto> _allTemplates = Mapper.Map<IEnumerable<TemplateDto>>(TemplateService.GetPagedList(pageNo, pageSize, null, q => q.OrderBy(s => s.Name), null));

            return _allTemplates;
        }

        public long GetTemplateCount(IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<Template> TemplateService = _dataRepositoryFactory.GetRepository<Template>();
            return TemplateService.Count();
        }
    }
}