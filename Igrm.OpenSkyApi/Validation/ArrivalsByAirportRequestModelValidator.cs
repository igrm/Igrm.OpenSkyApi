using FluentValidation;
using Igrm.OpenSkyApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Validation
{
    public class ArrivalsByAirportRequestModelValidator : AbstractValidator<ArrivalsByAirportRequestModel>
    {
        public ArrivalsByAirportRequestModelValidator()
        {
            RuleFor(model => model.Airport).NotEmpty();
            RuleFor(model => model.Begin).GreaterThan(0);
            RuleFor(model => model.End).GreaterThan(0);
            RuleFor(model => model.Begin).Must((model, value) => value < model.End);
        }
    }
}
