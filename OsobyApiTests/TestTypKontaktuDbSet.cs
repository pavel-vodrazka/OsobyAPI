using OsobyApi.Models;
using System.Linq;

namespace OsobyApiTests
{
    internal class TestTypKontaktuDbSet : TestDbSet<TypKontaktu>
    {
        public override TypKontaktu Find(params object[] keyValues)
        {
            return this.SingleOrDefault(typKontaktu => typKontaktu.Id == (int)keyValues.Single());
        }
    }
}
