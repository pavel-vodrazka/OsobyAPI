using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestBydlisteDbSet : TestDbSet<Bydliste>
    {
        public override Bydliste Find(params object[] keyValues)
        {
            return this.SingleOrDefault(bydliste => bydliste.Id == (int)keyValues.Single());
        }
    }
}
