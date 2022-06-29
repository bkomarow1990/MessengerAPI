using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Interfaces;
using Core.Interfaces.CustomServices;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ApplicationUserDto>> Get()
        {
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(await _unitOfWork.UserRepository.Get());
        }

        public Task<ApplicationUserDto> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Create(ApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task Edit(ApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
