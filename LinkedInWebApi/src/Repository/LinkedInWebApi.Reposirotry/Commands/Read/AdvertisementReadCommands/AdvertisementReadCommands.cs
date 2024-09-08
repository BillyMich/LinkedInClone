﻿using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class AdvertisementReadCommands : IAdvertisemenReadCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public AdvertisementReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<AdvertisementDto?> GetAdvertisment(int id)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDto();
        }

        public async Task<List<AdvertisementDto>> GetAdvertisments()
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches).ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>> GetAdvertismentsByCreator(int creatorId)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Where(x => x.CreatorId == creatorId)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Where(x => professionalBranches.HaveCommonElements<int>(x.AdvertismentProfessionalBranches.Select(x => x.ProfessionalBranchId).ToList()))
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>> GetAdvertismentsByStatus(byte status)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Where(x => x.Status == status)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }
    }
}
