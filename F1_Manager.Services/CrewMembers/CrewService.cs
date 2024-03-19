using F1_Manager.Data;
using F1_Manager.Models.CrewMembers;
using HAAS_F1_Manager_Sim.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Services.CrewMembers
{
    public class CrewService : ICrewService
    {
        private readonly ApplicationDbContext _context;
        public CrewService(ApplicationDbContext context) 
        {
            _context = context;

        }

        public async Task<bool> CrewCreateAsync(CrewCreate model)
        {
            CrewMember CrewMember = new CrewMember()
            {
                Name = model.Name,
                Age = model.Age,
                Role = model.Role,
                RoleDescription = model.RoleDescription,
                Salary = model.Salary,
                PhoneNumber = model.PhoneNumber,
            };
            if (CrewMember != null)
            {
                await _context.Crew.AddAsync(CrewMember);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CrewDeleteAsync(int id)
        {
            var toDelete = await _context.Crew.FindAsync(id);
            if (toDelete != null)
            {
                _context.Crew.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CrewListAll>> CrewDetailAllAsync()
        {
            return await _context.Crew
               .Select(n => new CrewListAll()
               {
                   Id = n.Id,
                   Name = n.Name,
                   Age = n.Age,
                   Role = n.Role,
                   RoleDescription = n.RoleDescription,
                   Salary= n.Salary,
                   PhoneNumber = n.PhoneNumber,
               }).ToListAsync();
        }

        public async Task<CrewDetail> CrewDetailAsync(int id)
        {
            var CrewToDetail = await _context.Crew.FindAsync(id);
            if (CrewToDetail != null)
            {
                CrewDetail crewDetailed = new CrewDetail()
                {
                    Id =CrewToDetail.Id,
                    Name = CrewToDetail.Name,
                    Age = CrewToDetail.Age,
                    Role = CrewToDetail.Role,
                    RoleDescription= CrewToDetail.RoleDescription,
                    PhoneNumber= CrewToDetail.PhoneNumber,
                    Salary = CrewToDetail.Salary,
                    
                };
                return crewDetailed;
            }
            return null!;
        }

        public async Task<bool> CrewUpdateAsync(int id, CrewEdit model)
        {
            var CrewToEdit = await _context.Crew.FindAsync(id);
            if (CrewToEdit != null)
            {
                CrewToEdit.Id = model.Id;
                CrewToEdit.Name = model.Name;
                CrewToEdit.Age = model.Age;
                CrewToEdit.Role = model.Role;
                CrewToEdit.RoleDescription = model.RoleDescription;
                CrewToEdit.Salary = model.Salary;
                CrewToEdit.PhoneNumber = model.PhoneNumber;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
