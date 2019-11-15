using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class GenreManager : Manager
    {
        static List<Genre> genresList = new List<Genre>();
        static int nextId = 0;
        public override int  getId(string genre)
        {
            for (int i = 0; i < genresList.Count; i++) {
                if (genresList[i].name == genre) {
                    return genresList[i].id;
                }
            }
            return -1;
        }

        public int isIdExists(int id){
            if (genresList.Exists(x => x.id == id)) {
                return 1;
            }
            return 0;
        }
        public override int add(string name)
        {
            for (int i = 0; i < genresList.Count; i++) {
                if (name == genresList[i].name) {
                    return -1;
                }
            }
            int id = nextId++;
            Genre newGenre = new Genre(id, name);
            genresList.Add(newGenre);
            return id;
        }


        public override int delete(int id){
            
            if (isIdExists(id) != -1){
                genresList.RemoveAll(x => x.id == id);
                
                return 1;
            }
            return 0;
        }

        public override string getById(int id){
            if (genresList.Exists(x => x.id == id)) {
                return genresList[genresList.FindIndex(x => x.id == id)].name;
            }
            return "no";
        }
    }
}
