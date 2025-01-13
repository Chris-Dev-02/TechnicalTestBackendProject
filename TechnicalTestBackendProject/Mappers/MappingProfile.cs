using AutoMapper;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region Model to DTO mappings

            // UserModel to UserReadDTO
            CreateMap<UserDTO, UserReadDTO>()
                .ForMember(dest => dest.Boards, opt => opt.MapFrom(src => src.Boards));

            // TaskModel to TaskReadDTO
            CreateMap<TaskModel, TaskReadDTO>()
                .ForMember(dest => dest.Board, opt => opt.MapFrom(src => src.Board));  // Map the Board entity directly

            // BoardModel to BoardReadDTO
            CreateMap<BoardModel, BoardReadDTO>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            #endregion

            #region DTO to Model mappings

            // UserCreateDTO to UserModel
            CreateMap<UserCreateDTO, UserDTO>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());  // Password will be handled separately, such as by hashing

            // LoginDTO to UserModel (for user login, you would typically authenticate against a stored hash)
            CreateMap<LoginDTO, UserDTO>();

            // UserModel to UserAuthDTO (for returning user data after login)
            CreateMap<UserModel, UserAuthDTO>();

            // UserUpdateDTO to UserModel
            CreateMap<UserUpdateDTO, UserModel>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());  // Password will be handled separately

            // TaskCreateDTO to TaskModel
            CreateMap<TaskCreateDTO, TaskModel>()
                .ForMember(dest => dest.Board, opt => opt.Ignore()) // Handle BoardId manually later, or lookup
                .ForMember(dest => dest.BoardId, opt => opt.MapFrom(src => src.BoardId));  // Set BoardId

            // TaskUpdateDTO to TaskModel
            CreateMap<TaskUpdateDTO, TaskModel>();

            // BoardCreateDTO to BoardModel
            CreateMap<BoardCreateDTO, BoardModel>();

            // BoardUpdateDTO to BoardModel
            CreateMap<BoardUpdateDTO, BoardModel>();

            #endregion
        }
    }
}
