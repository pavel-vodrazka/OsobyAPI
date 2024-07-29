using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestNarodnostDbSet : TestDbSet<Narodnost>
    {
        public override Narodnost Find(params object[] keyValues)
        {
            return this.SingleOrDefault(narodnost => narodnost.Id == (int)keyValues.Single());
        }
    }
}
