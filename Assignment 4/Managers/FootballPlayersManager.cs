using Assignment_1;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Runtime.CompilerServices;

namespace Assignment_4.Managers
{
    public class FootballPlayersManager
    {
        private static int id;
        private static readonly List<FootballPlayer> data = new List<FootballPlayer>
        {
            new FootballPlayer
            {
                Id = ++id, Age = 25, Name = "Falke", ShirtNumber = 42
            },
            new FootballPlayer
            {
                Id = ++id, Age = 29, Name = "Ole", ShirtNumber = 13
            },
            new FootballPlayer
            {
                Id = ++id, Age = 20, Name = "Karsten", ShirtNumber = 19
            },
            new FootballPlayer
            {
                Id = ++id, Age = 28, Name = "Poul", ShirtNumber = 77
            }
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(data);
        }
        public FootballPlayer GetById(int id)
        {
            return data.Find(fbp => fbp.Id == id);
        }
        public FootballPlayer Add(FootballPlayer fbpToAdd)
        {
            fbpToAdd.Id = ++id;
            data.Add(fbpToAdd);
            return fbpToAdd;
        }
        public FootballPlayer Update(int id, FootballPlayer updatedFbp)
        {
            FootballPlayer fbp = data.Find(fbp => fbp.Id == id);
            if (fbp == null) return null;
            if (!string.IsNullOrEmpty(updatedFbp.Name)) fbp.Name = updatedFbp.Name;
            if (updatedFbp.Age !< 1) fbp.Age = updatedFbp.Age;
            if (updatedFbp.ShirtNumber !< 1) fbp.ShirtNumber = updatedFbp.ShirtNumber;
            return fbp;
        }
        public FootballPlayer Delete(int id)
        {
            FootballPlayer fbp = data.Find(fbp => fbp.Id == id);
            if (fbp == null) return null;
            data.Remove(fbp);
            return fbp;
        }
    }
}
