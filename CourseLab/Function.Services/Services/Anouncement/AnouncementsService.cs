using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Function.Data.Infrastructure;
using Function.Services.Services.Anouncement.Dto;
using Omu.ValueInjecter;

namespace Function.Services.Services.Anouncement
{
    public class AnouncementsService : IAnouncementService
    {
        private readonly IRepository<Data.Entities.Anouncement> anouncementRepository;
        private readonly IUnitOfWork unitOfWork;

        public AnouncementsService(IRepository<Data.Entities.Anouncement> anouncementRepository, IUnitOfWork unitOfWork)
        {
            this.anouncementRepository = anouncementRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Create(AnouncementDto anouncement)
        {
            anouncementRepository.Add((Data.Entities.Anouncement)new Data.Entities.Anouncement().InjectFrom(anouncement));
            unitOfWork.Commit();
        }

        public List<AnouncementDto> GetAnouncementsByFullName(string prof)
        {
            var list = anouncementRepository.Query(x => x.Professor == prof && x.IsDeleted == false).ToList();
            var dtolist = new List<AnouncementDto>();
            foreach(var item in list)
            {
                var ann = (AnouncementDto)new AnouncementDto().InjectFrom(item);
                dtolist.Add(ann);
            }
            return dtolist;
        }

        public List<AnouncementDto> GetAnouncementsByProfessors(List<string> profsnames)
        {
            var list = new List<AnouncementDto>();
            foreach(var prof in profsnames)
            {
                var anouncements = anouncementRepository.Query(x => x.Professor == prof).ToList();
                foreach(var anouncement in anouncements)
                {
                    var anouncementdto = (AnouncementDto)new AnouncementDto().InjectFrom(anouncement);
                    list.Add(anouncementdto);
                }
            }
            return list;

        }
    }
}
