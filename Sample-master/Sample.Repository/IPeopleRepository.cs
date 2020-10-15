using Sample.Entity;
using System.Collections.Generic;

namespace Sample.Repository
{

    // People Interface, will have all the available actions which will be perform on people.
    public interface IPeopleRepository
    {
        IEnumerable<People> GetSearchPeoples(string q);
        IEnumerable<People> GetPeoples();
        IEnumerable<People> AddPeople(People p);
    }
}
