using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;


namespace WebApi.Services
{
    public class AuditService : ICRUD<Audit>
    {
        private DataContext _context;

        public AuditService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Audit> GetAll()
        {
            return _context.Audits.Include(x => x.LoggedInUser).ToList();
        } 
        public async Task<IEnumerable<Audit>> GetAllAsync()
        {
            return await _context.Audits.Include(x => x.LoggedInUser)
                .ThenInclude(y=>y.Role)
                .ToListAsync();
        }

        public Audit GetById(int id)
        {
            return _context.Audits.Find(id);
        }

        public Audit Create(Audit audit)
        {
            audit.OnCreated();
            _context.Audits.Add(audit);
            _context.SaveChanges();

            return audit;
        }

        public Audit Update(Audit auditParam)
        {
            var audit = _context.Audits.Find(auditParam.Id);

            if (audit == null)
                throw new AppException("Audit not found");
            if (audit.LoggedInDateTime == null)
                throw new AppException("User not loggedIn");

            // update user properties
            audit.LoggedOutDateTime = DateTime.Now;

            _context.Audits.Update(audit);
            _context.SaveChanges();

            return audit;
        }

        public void Delete(int id)
        {
            var audit = _context.Audits.Find(id);
            if (audit != null)
            {
                _context.Audits.Remove(audit);
                _context.SaveChanges();
            }
        }
    }
}
