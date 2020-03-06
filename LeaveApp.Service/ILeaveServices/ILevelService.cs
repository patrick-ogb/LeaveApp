using LeaveApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.ILeaveServices
{
    public interface ILevelService
    {
        Task<List<Level>> GetAllLevels();
        Task<Level> GetLevelById(int Id);
        Task<Level> AddLevel(Level level);
        Task<Level> DeleteLevel(int Id);
        Task<Level> UpdateLevel(Level levelChange, int Id);
    }
}
