using System.Collections;
using ASPUnitTest.Models;

namespace ASPUnitTest.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();

        public Beer? Get(int id);
    }
}
