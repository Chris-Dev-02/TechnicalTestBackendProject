using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class BoardService : ICRUDService<BoardModel>
    {
        public Task<BoardModel> Create(BoardModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<BoardModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BoardModel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BoardModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BoardModel> Update(int id, BoardModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
