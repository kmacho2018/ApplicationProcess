using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicationProcess.February2021.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Models
{

    public class AssetValidator : AbstractValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(asset => asset.AssetName).MinimumLength(5);
            RuleFor(asset => asset.PurchaseDate).GreaterThan(DateTime.Now.AddDays(-365));
            RuleFor(asset => asset.EMailAdressOfDepartment).EmailAddress(EmailValidationMode.Net4xRegex);
            RuleFor(asset => asset.Broken).NotNull();
            RuleFor(asset => asset.Department).IsInEnum();
            RuleFor(asset => asset.CountryOfDepartment).Must(IsValidCountry).WithMessage(" Select a valid 'country'");
        }
        public bool IsValidCountry(Asset asset, string me)
        {

            var url = $"http://restcountries.eu/rest/v2/name/" + asset.CountryOfDepartment + "?fullText=true";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            var content = string.Empty;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
