using FluentValidation;
using FluentValidation.Results;
using Igrm.OpenSkyApi.Exceptions;
using Igrm.OpenSkyApi.Interfaces;

namespace Igrm.OpenSkyApi.Builders
{
    public abstract class RequestBuilderBase<T, U> : IRequestBuilder<T>
                                                     where U : AbstractValidator<T>, new()
                                                     where T : IRequestModel, new()
    {
        protected T requestModel;

        public RequestBuilderBase()
        {
            requestModel = new T();
        }

        public T Build()
        {
            var validationResult = Validate(requestModel);
            if (!validationResult.IsValid)
            {
                requestModel = new T();
                throw new ModelValidationException(validationResult.Errors);
            }
            var copy = requestModel.Clone();
            requestModel = new T();
            return (T)copy;
        }

        private ValidationResult Validate(T requestModel)
        {
            var validator = new U();
            return validator.Validate(requestModel);
        }
    }
}
