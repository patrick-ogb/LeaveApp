using LeaveApp.Core.Contexts;
using LeaveApp.Core.Entities;
using LeaveApp.Service.ILeaveServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp.Service.LeaveServices
{
    public class LevelService : ILevelService
    {
        private readonly AppDbContext context;

        public LevelService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Level> AddLevel(Level level)
        {
            context.Leveltbl.Add(level);
           await context.SaveChangesAsync();
            return level;
        }

        public async Task<Level> DeleteLevel(int Id)
        {
            var level = context.Leveltbl.FirstOrDefault(emp => emp.Id == Id);
            context.Leveltbl.Remove(level);
            await context.SaveChangesAsync();
            return level;
        }

        public async Task<List<Level>> GetAllLevels()
        {
            return await context.Leveltbl.ToListAsync();
        }

        public async Task<Level> GetLevelById(int Id)
        {
            return await context.Leveltbl.FirstOrDefaultAsync(lvl => lvl.Id == Id);
            
        }

        public async Task<Level> UpdateLevel(Level levelChange, int Id)
        {
            context.Leveltbl.Update(levelChange);
            await context.SaveChangesAsync();
            return levelChange;
        }
    }
}
