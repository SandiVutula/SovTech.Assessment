using SovTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Services.Contract
{
    public interface IJokeService
    {
        Task<string> GetCategories();
        Task<string> GetRandomJokeByCategory(string category);
    }
}