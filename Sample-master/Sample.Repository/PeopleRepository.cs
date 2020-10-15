using Sample.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Repository
{
    public class PeopleRepository:IPeopleRepository
    {
        static List<People> peoples;
        public IEnumerable<People> GetPeoples()
        {
            peoples= InitializePeople().ToList();
            return peoples;
        }

        // Search based on person's first or last name.
        public IEnumerable<People> GetSearchPeoples(string q)
        {
            // Convert all first and last name to lower character and also convert search term to lower character 
            // then search the search term anywhere in first or last name.
            var result = peoples.Where(x => x.FirstName.ToLower().Contains(q.ToLower()) || x.LastName.ToLower().Contains(q.ToLower()));
            return result;
        }

        // Add new people.
        public IEnumerable<People> AddPeople(People p)
        {
            peoples.Add(p);
            return peoples;
        }
         // seed the People data
        public IEnumerable<People> InitializePeople()
        {
            var peopleList = new List<People>{
                new People{
                    PeopleID=1, 
                    FirstName="John", 
                    LastName="Doe",
                    Age=35,
                    Interests=new List<PeopleInterests>{new PeopleInterests{InterestID=1,Interest="Coding"},new PeopleInterests{InterestID=2,Interest="Gaming"}},
                    Address=new PeopleAddress{Street="1234 Somewhere",City="Some City",Zip=12345,State="NE"},
                    PeopleImage=new PeopleImage{ImageID=1,Image=null}
                },
                new People{
                    PeopleID=2,
                    FirstName="John",
                    LastName="Doe 2",
                    Age=34,
                    Interests=new List<PeopleInterests>{new PeopleInterests{InterestID=1,Interest="Surfing"},new PeopleInterests{InterestID=2,Interest="Programming"}},
                    Address=new PeopleAddress{Street="1234 Somewhere",City="Some City",Zip=12345,State="NE"},
                    PeopleImage=new PeopleImage{ImageID=1,Image=null}
                }
            };
            return peopleList;
        }

    }
}
