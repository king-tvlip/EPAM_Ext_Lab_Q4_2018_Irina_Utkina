namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserRepository : IBaseRepository<User>
    {
        void InitiallizeUser();

        User ChooseThemeAndRate(User user);//todo pn несоблюдение стилистики кода. У тебя до этого все наименования методов были без подчеркиваний. Нужно привести весь код к единому виду.
    }
}
