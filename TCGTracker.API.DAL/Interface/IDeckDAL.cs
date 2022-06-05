using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IDeckDAL
    {

        List<Deck> GetAllDecksByPlayerId(int playerId);
        Deck GetDeckById(int id);
        int CreateDeck(int playerId, Deck deck);
        void UpdateDeck(int id, Deck deck);

    }
}
