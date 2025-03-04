﻿using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateBoardCommand(BoardCreateDTO boardData) : IRequest<BoardReadDTO>;
}
