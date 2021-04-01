﻿using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class AssetValidator : AbstractValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(customer => customer.AssetName).MinimumLength(5);
            RuleFor(customer => customer.PurchaseDate).GreaterThan(DateTime.Now.AddDays(-365));
            RuleFor(customer => customer.EMailAdressOfDepartment).EmailAddress(EmailValidationMode.Net4xRegex);
            RuleFor(customer => customer.Broken).NotNull();
        }

    }
}
