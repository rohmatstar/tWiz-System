using API.Utilities.Handlers;

namespace Client.Contracts
{
        public interface IRepository<T, X>
            
            where T : class
        {
            Task<ResponseHandler<IEnumerable<T>>> Get();
            Task<ResponseHandler<T>> Get(X id);
            Task<ResponseHandler<T>> Post(T entity);
            Task<ResponseHandler<T>> Put(X id, T entity);
            Task<ResponseHandler<T>> Delete(X id);


        }
    
}
