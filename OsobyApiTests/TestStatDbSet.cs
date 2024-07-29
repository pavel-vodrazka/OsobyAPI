using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestStatDbSet : TestDbSet<Stat>
    {
        public override Stat Find(params object[] keyValues)
        {
            return this.SingleOrDefault(stat => stat.Id == (int)keyValues.Single());
        }
    }
}
