using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class DeckDAL : IDeckDAL
    {
        public int CreateDeck(int playerId, Deck deck)
        {
            throw new NotImplementedException();
        }

        public List<Deck> GetAllDecksByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public Deck GetDeckById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeck(int id, Deck deck)
        {
            throw new NotImplementedException();
        }
    }
}
