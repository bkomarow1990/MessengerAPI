using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserDto>> Get();
        Task<ApplicationUserDto> GetUserById(string id);
        Task Create(ApplicationUserDto user);
        Task Edit(ApplicationUserDto user);
        Task Delete(string id);
    }
}
