using Hahn.ApplicationProcess.February2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Services
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext appDbContext;

        public AssetRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            return await appDbContext.Assets.ToListAsync();
        }

        public async Task<Asset> GetAsset(int AssetId)
        {
            return await appDbContext.Assets
                .FirstOrDefaultAsync(e => e.Id == AssetId);
        }

        public Asset GetAssetByEmail(string email)
        {
            return appDbContext.Assets
                .FirstOrDefault(e => e.EMailAdressOfDepartment == email);
        }

        public async Task<Asset> AddAsset(Asset Asset)
        {
            var result = await appDbContext.Assets.AddAsync(Asset);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Asset> UpdateAsset(Asset Asset)
        {
            var result = await appDbContext.Assets
                .FirstOrDefaultAsync(e => e.Id == Asset.Id);

            if (result != null)
            {
                result.AssetName = Asset.AssetName;
                result.CountryOfDepartment = Asset.CountryOfDepartment;
                result.EMailAdressOfDepartment = Asset.EMailAdressOfDepartment;
                result.PurchaseDate = Asset.PurchaseDate;
                result.Broken = Asset.Broken;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Asset> DeleteAsset(int AssetId)
        {
            var result = await appDbContext.Assets
                .FirstOrDefaultAsync(e => e.Id == AssetId);
            if (result != null)
            {
                appDbContext.Assets.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Asset> GetAssetById(int assetId)
        {
            return await appDbContext.Assets
                           .FirstOrDefaultAsync(e => e.Id == assetId);
        }
    }
}