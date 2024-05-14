using AutoMapper;
using MyAssessment.MapperProfiles;
using MyAssessment.Services;
using MyData.Services;
using MySharedLib.Interfaces;
using System.Runtime.CompilerServices;

namespace MyAssessment.Domain
{
    /// <summary>
    /// Base Domain model with Id, Save, Delete and Find implementations
    /// </summary>
    public class DomainModel : IDomainModel
    {
        public int? Id { get; set; }

        private IFileService _fileService;
        private IMapper _mapper;
        public DomainModel()
        {
            _fileService = new XMLFileService();
            _mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
        }
        public void Delete()
        {
            if (_fileService.Delete(this.Id, this))
            {
                this.Id = null;
            }                
        }

        public T? Find<T>(int? id, T domain)
        {
            if (domain != null)
            {
                var data = MapperService.Map(_mapper, domain);
                var result = _fileService.Find(id, data);
                if (result == null)
                {
                    return default;
                }
                else
                {
                    var mappedResult = MapperService.Map(_mapper, result);
                    return (T)mappedResult;
                }
            }
            else return default;
        }

        public void Save()
        {
            this.Id = _fileService.GetNextId(this);

            var data = MapperService.Map(_mapper, this);
            if (!_fileService.Save(this.Id, data))
            {
                this.Id = null;
            }
        }
    }
}
