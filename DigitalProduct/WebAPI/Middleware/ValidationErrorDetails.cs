using FluentValidation.Results;

namespace WebAPI.Middleware
{
    internal class ValidationErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}