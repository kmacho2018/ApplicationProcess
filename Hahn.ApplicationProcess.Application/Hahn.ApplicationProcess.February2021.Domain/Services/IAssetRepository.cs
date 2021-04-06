using Hahn.ApplicationProcess.February2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Services
{
    public interface IAssetRepository
    {

        Task<IEnumerable<Asset>> GetAssets();
        Task<Asset> GetAssetById(int assetId);
        Asset GetAssetByEmail(string email);
        Task<Asset> AddAsset(Asset asset);
        Task<Asset> UpdateAsset(Asset asset);
        Task<Asset> DeleteAsset(int assetId);
    }
}
