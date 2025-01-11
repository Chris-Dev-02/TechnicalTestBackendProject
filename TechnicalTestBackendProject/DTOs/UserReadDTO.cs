﻿using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Role UserRole { get; set; }
        public ICollection<BoardReadDTO>? Boards { get; set; }
    }
}
