using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRaitingRepository
    {
        Task<Rating> addRating(Rating rating);
    }
}
