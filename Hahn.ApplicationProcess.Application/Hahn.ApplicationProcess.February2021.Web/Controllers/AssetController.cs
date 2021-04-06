using Hahn.ApplicationProcess.February2021.Data.Models;
using Hahn.ApplicationProcess.February2021.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepository AssetRepository;

        public AssetsController(IAssetRepository assetRepository)
        {
            this.AssetRepository = assetRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAssets()
        {
            try
            {
                return Ok(await AssetRepository.GetAssets());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            try
            {
                var result = await AssetRepository.GetAssetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> CreateAsset(Asset Asset)
        {
            try
            {
                if (Asset == null)
                {
                    return BadRequest();
                }

                var emp = AssetRepository.GetAssetByEmail(Asset.EMailAdressOfDepartment);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "Asset email already in use");
                    return BadRequest(ModelState);
                }

                var createdAsset = await AssetRepository.AddAsset(Asset);

                return CreatedAtAction(nameof(GetAsset), new { id = createdAsset.Id },
                    createdAsset);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Asset>> UpdateAsset(int id, Asset Asset)
        {
            try
            {
                if (id != Asset.Id)
                {
                    return BadRequest("Asset ID mismatch");
                }

                var AssetToUpdate = await AssetRepository.GetAssetById(id);

                if (AssetToUpdate == null)
                {
                    return NotFound($"Asset with Id = {id} not found");
                }

                return await AssetRepository.UpdateAsset(Asset);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Asset>> DeleteAsset(int id)
        {
            try
            {
                var AssetToDelete = await AssetRepository.GetAssetById(id);

                if (AssetToDelete == null)
                {
                    return NotFound($"Asset with Id = {id} not found");
                }

                return await AssetRepository.DeleteAsset(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}