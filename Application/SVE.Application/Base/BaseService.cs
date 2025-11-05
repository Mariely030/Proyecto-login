using SVE.Domain.Base;

namespace SVE.Application.Base
{
    public abstract class BaseService
    {
        protected async Task<OperationResult> ExecuteAsync(Func<Task<OperationResult>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        protected async Task<OperationResult> ExecuteAsync(Func<Task> action)
        {
            var result = new OperationResult();
            try
            {
                await action();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        protected async Task<OperationResult> ExecuteAsync<T>(Func<Task<T>> action)
        {
            var result = new OperationResult();
            try
            {
                result.Data = await action();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
