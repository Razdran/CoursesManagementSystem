using Function.Services.Services.Anouncement.Dto;
using System.Collections.Generic;

namespace Function.Services.Services
{
    public interface IAnouncementService
    {
        void Create(AnouncementDto anouncement);
        List<AnouncementDto> GetAnouncementsByProfessors(List<string> profsnames);
    }
}
