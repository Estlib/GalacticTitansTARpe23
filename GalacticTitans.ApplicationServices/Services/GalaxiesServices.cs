﻿using GalacticTitans.Core.Domain;
using GalacticTitans.Core.Dto;
using GalacticTitans.Core.ServiceInterface;
using GalacticTitans.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.ApplicationServices.Services
{
    public class GalaxiesServices : IGalaxiesServices
    {
        private readonly GalacticTitansContext _context;
        private readonly IFileServices _fileServices;
        private readonly IAstralBodiesServices _astralBodiesServices;
        private readonly ISolarSystemsServices _solarSystemsServices;

        public GalaxiesServices(
            GalacticTitansContext context, 
            IFileServices fileServices, 
            IAstralBodiesServices astralBodiesServices, 
            ISolarSystemsServices solarSystemsServices)
        {
            _context = context;
            _fileServices = fileServices;
            _astralBodiesServices = astralBodiesServices;
            _solarSystemsServices = solarSystemsServices;
        }

        public async Task<Galaxy> DetailsAsync(Guid id)
        {
            var result = await _context.Galaxies
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Galaxy> Create(GalaxyDto dto, List<SolarSystem> systemsInGalaxy)
        {
            Galaxy newGalaxy = new();

            // set by service on first creation
            newGalaxy.ID = Guid.NewGuid();

            // set by admin
            newGalaxy.GalaxyName = dto.GalaxyName;
            newGalaxy.GalaxyLore = dto.GalaxyLore;
            newGalaxy.SolarSystemsInGalaxy = SystemToID(systemsInGalaxy);
            // set for db
            newGalaxy.CreatedAt = DateTime.Now;
            newGalaxy.UpdatedAt = DateTime.Now;
            /*opcheck: newsystem is not assigned any planetids*/
            await _context.Galaxies.AddAsync(newGalaxy);
            await _context.SaveChangesAsync();

            return newGalaxy;
        }


        private static List<Guid> SystemToID(List<SolarSystem> systems)
        {
            var result = new List<Guid>();
            foreach (var system in systems)
            {
                result.Add(system.ID);
            }
            return result;
        }
    }
}
