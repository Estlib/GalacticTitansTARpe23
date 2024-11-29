﻿using GalacticTitans.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Data
{
    public class GalacticTitansContext : IdentityDbContext<ApplicationUser>
    {
        public GalacticTitansContext(DbContextOptions<GalacticTitansContext> options) : base(options) {}
        public DbSet<Titan> Titans { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
