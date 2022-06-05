using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IMatchDAL
    {
        List<Match> GetAllMatches();
        Match GetMatchById(int id);
        int CreateMatch(Match Match);
        void UpdateMatch(int id, Match Match);



    }
}
