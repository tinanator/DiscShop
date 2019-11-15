using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class CountryManager : Manager
    {

        static List<Country> countriesList = new List<Country>();
        static int nextId = 0;
        public override int getId(string country)
        {
            for (int i = 0; i < countriesList.Count; i++) {
                if (countriesList[i].name == country) {
                    return countriesList[i].id;
                }
            }
            return -1;
        }
        public int isIdExists(int id)
        {
            if (countriesList.Exists(x => x.id == id)) {
                return 1;
            }
            return 0;
        }
        public override int add(string name)
        {
            for (int i = 0; i < countriesList.Count; i++) {
                if (name == countriesList[i].name) {
                    return -1;
                }
            }
            int id = nextId++;
            Country newCountry = new Country(id, name);
            countriesList.Add(newCountry);
            return id;
        }

        public override string getById(int id){
            for (int i = 0; i < countriesList.Count; i++) {
                if (countriesList[i].id == id) {
                    return countriesList[i].name;
                }
            }
            return "no";
        }
        public override int delete(int id){
            if (isIdExists(id) != -1) {
                countriesList.RemoveAll(x => x.id == id);
                return 1;
            }
            return 0;
        }
    }
}
