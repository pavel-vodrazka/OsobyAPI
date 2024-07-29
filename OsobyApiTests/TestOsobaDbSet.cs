using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestOsobaDbSet : TestDbSet<Osoba>
    {
        public override Osoba Find(params object[] keyValues)
        {
            return this.SingleOrDefault(osoba => osoba.Id == (int)keyValues.Single());
        }
    }
}
