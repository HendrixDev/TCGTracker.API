using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;
using Type = TCGTracker.API.Entities.Models.Type;

namespace TCGTracker.API.DAL
{
    public class MockData : IMockData
    {
        public List<Player> GetMockPlayers()
        {
            return new List<Player>()
            {
                new Player
                {
                    PlayerId = 1,
                    PlayerName = "Zack",
                    Decks = new List<Deck>
                    {
                        new Deck(1, 1, "Firefighters", new List<Type> {Type.Fire, Type.Fighting }),
                        new Deck(1, 2, "RayEels", new List<Type> {Type.Electric, Type.Dragon }),
                        new Deck(1, 3, "Lapras/Zacian", new List<Type> {Type.Water, Type.Metal })
                    }
                },
                new Player
                {
                    PlayerId = 2,
                    PlayerName = "Daniel",
                    Decks = new List<Deck>
                    {
                        new Deck(2, 1, "Water", new List<Type> {Type.Water }),
                        new Deck(2, 2, "Blastoise", new List<Type> {Type.Water })
                    }
                },
                new Player
                {
                    PlayerId = 3,
                    PlayerName = "Isaiah",
                    Decks = new List<Deck>
                    {
                        new Deck(3, 1, "Electric", new List<Type> {Type.Electric }),
                    }
                }
            };
        }
    }
}
