using BLL.Services.Contracts;

namespace BLL.Factory
{
    public interface IServiceCollection
    {
        IBookService Books { get; }
    }
}