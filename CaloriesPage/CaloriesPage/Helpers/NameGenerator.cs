using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesPage.Helpers
{
    public static class NameGenerator
    {
        private static List<string> _participants => new List<string>() { "Jan", "Karol", "Ania", "Tomek", "Grzegorz", "Asia", "Pawel", "Mateusz", "Andrzej" };

        public static string GeneratePresenter()
        {
            int min = 0;
            int max = _participants.Count();
            int randomIndex = RandomNumber(min, max);
            return _participants[randomIndex];
        }

        private static int RandomNumber(int min, int max)
        {
            int seed = DateTime.Now.Millisecond;
            Random random = new Random(seed);
            return random.Next(min, max);
        }
    }
}
