﻿using BlogApp.Models.Models;

namespace BlogApp.DataAccess.Repository.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
    }
}
