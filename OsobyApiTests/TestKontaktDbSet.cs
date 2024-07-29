using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestKontaktDbSet : TestDbSet<Kontakt>
    {
        public override Kontakt Find(params object[] keyValues)
        {
            return this.SingleOrDefault(kontakt => kontakt.Id == (int)keyValues.Single());
        }
    }
}
