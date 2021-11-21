using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Core.Cqrs
{
    public abstract class AutomateRequestHandler<TRequest, TResponseDto>: IRequestHandler<TRequest, ExecutionResult<TResponseDto>> where TRequest: IRequest<ExecutionResult<TResponseDto>>
    {
        protected abstract Task<TResponseDto> ExecuteRequestDelegate(TRequest request);

        protected virtual TResponseDto CreateResponseDtoFromResponse(dynamic response) => response;

        protected virtual ValidationResult PreRequestValidation(TRequest input) => ValidationResult.Valid;

        protected virtual Task<ValidationResult> PreRequestValidationAsync(TRequest input) => Task.FromResult(ValidationResult.Valid);

        public async Task<ExecutionResult<TResponseDto>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            (await PreRequestValidationAsync(request))
                .Chain(PreRequestValidation(request))
                .ThrowIfInvalid();

            var response = await ExecuteRequestDelegate(request);

            return ExecutionResult.CreateSuccessful(CreateResponseDtoFromResponse(response));
        }
    }

    public abstract class AutomateRequestHandler<TRequest> : IRequestHandler<TRequest, ExecutionResult> where TRequest : IRequest<ExecutionResult>
    {
        protected abstract Task ExecuteRequestDelegate(TRequest request);

        protected virtual ValidationResult PreRequestValidation(TRequest input) => ValidationResult.Valid;

        protected virtual Task<ValidationResult> PreRequestValidationAsync(TRequest input) => Task.FromResult(ValidationResult.Valid);

        public async Task<ExecutionResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            (await PreRequestValidationAsync(request))
                .Chain(PreRequestValidation(request))
                .ThrowIfInvalid();

            await ExecuteRequestDelegate(request);

            return ExecutionResult.CreateSuccessful();


        }
    }
}
