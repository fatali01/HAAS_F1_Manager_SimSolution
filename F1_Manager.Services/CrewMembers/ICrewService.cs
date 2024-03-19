
using F1_Manager.Models.CrewMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Services.CrewMembers
{
    public interface ICrewService
    {
        Task<bool> CrewCreateAsync(CrewCreate model);
        Task<CrewDetail> CrewDetailAsync(int id);
        Task<List<CrewListAll>> CrewDetailAllAsync();
        Task<bool> CrewUpdateAsync(int id, CrewEdit model);
        Task<bool> CrewDeleteAsync(int id);
    }
}
