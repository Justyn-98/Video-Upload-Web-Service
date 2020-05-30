using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccessLayer.DataSeeder
{
    public class SeederHelper
    {
        public readonly string _videoName = "Film ";

        public readonly string _commentName = "Komentarz: ";

        public readonly string _descriptionName = "Opis:  ";

        private readonly List<string> _videoCategoriesNames = new List<string>()
        {
            "Sc-Fi", "Komedia", "Dramat","Śmieszne Kotki",""
        };

        private readonly Random _random = new Random();

        public string GetProductCategoryName(int index)
        {
            if (index - 1 >= _videoCategoriesNames.Count)
                return Guid.NewGuid().ToString();

            return _videoCategoriesNames.ElementAt(index - 1);
        }

        public string GetRandomNumber()
            => _random.Next(100).ToString();

        public string GetRandomString()
            => Guid.NewGuid() + " " + Guid.NewGuid();
    }
}

