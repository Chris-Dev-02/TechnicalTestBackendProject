﻿using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserReadDTO>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserReadDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByIdAsync(request.Id);
        }
    }
}
