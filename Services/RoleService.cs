using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Data;

namespace WebApi.Services
{
    public class RoleService: ICRUD<Role>
    {
        private DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public Role Create(Role role)
        {
            if (_context.Roles.Any(x => x.InternalIdentifier == role.InternalIdentifier))
                throw new AppException("Role \"" + role.DisplayName + "\" is already taken");

            role.OnCreated();
            _context.Roles.Add(role);
            _context.SaveChanges();

            return role;
        }

        public Role Update(Role roleParam)
        {
            var role = _context.Roles.Find(roleParam.Id);

            if (role == null)
                throw new AppException("Role not found");

            if (roleParam.InternalIdentifier != role.InternalIdentifier)
            {
                // username has changed so check if the new username is already taken
                if (_context.Roles.Any(x => x.InternalIdentifier == roleParam.InternalIdentifier))
                    throw new AppException("Role " + roleParam.DisplayName + " is already taken");
            }

            // update user properties
           role.DisplayName = roleParam.DisplayName;
           role.InternalIdentifier = roleParam.InternalIdentifier;
           role.LandingPageUrl = roleParam.LandingPageUrl;

            _context.Roles.Update(role);
            _context.SaveChanges();

            return role;
        }

        public void Delete(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync() {
            return await _context.Roles.ToListAsync();
        }
    }
}
