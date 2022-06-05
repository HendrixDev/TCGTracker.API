using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class MatchDAL : IMatchDAL
    {
        public int CreateMatch(Match Match)
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public Match GetMatchById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMatch(int id, Match Match)
        {
            throw new NotImplementedException();
        }
    }
}
