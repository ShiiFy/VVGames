using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.Interface
{
    public interface IAdmin
    {
        List<UUsers> GetAllUsers(); //Получиние списка пользователей
        bool ToggleUserBlock(int userId); //Изменение блокировки пользователя
        bool ToggleUserRole(int userId); //Изменение роли пользовател
    }
}
