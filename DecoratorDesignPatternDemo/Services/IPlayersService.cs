using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecoratorDesignPatternDemo.Models;

namespace DecoratorDesignPatternDemo.Services
{
    public interface IPlayersService
    {
        IEnumerable<Player> GetPlayersList(); 
    }
}
