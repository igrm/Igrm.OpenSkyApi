using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Igrm.OpenSkyApi.Exceptions
{
    public class ModelValidationException :Exception
    {
        public ModelValidationException(IList<ValidationFailure> validationFailures) : base(String.Join(";", validationFailures.Select(x => x.ErrorMessage).ToList()))
        {
        }
    }
}
