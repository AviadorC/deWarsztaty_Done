using System;
using System.Threading.Tasks;
using NowyOssus.Model;
using Refit;

namespace NowyOssus.Service
{
    public interface IStarWarsApi
    {
        [Get("/people/?page={page}")]
        Task<GeneralResponse<Character>> GetCharacters(int page);
    }
}
