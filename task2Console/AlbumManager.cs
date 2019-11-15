using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace task2Console
{
    class AlbumManager : Manager
    {
        static List<Album> albumsList = new List<Album>();
        static int nextId = 0;
        AuthorManager man = new AuthorManager();
        GenreManager genreman = new GenreManager();
        CountryManager countryman = new CountryManager();
        StoreManager store = new StoreManager();
        public int add(string newName, int authorId, List<int> genresId, int countryId)
        {
            for (int i = 0; i < albumsList.Count; i++) {
                if (albumsList[i].authorId == authorId && albumsList[i].name == newName) {
                    return -1;
                }
            }
            int id = nextId++;
            Album newAlbum = new Album(id, newName, authorId, genresId, countryId);
            albumsList.Add(newAlbum);
            return id;
        }

        public int getId(string name, int authorId){
            for (int i = 0; i < albumsList.Count; i++){ 
                if (albumsList[i].name == name && albumsList[i].authorId == authorId){
                    return albumsList[i].id;
                }
            }
            return -1;
        }
        public int isIdExists(int id)
        {
            if (albumsList.Exists(x => x.id == id)) {
                return 1;
            }
            return 0;
        }
        public override string getById(int id){ 
            if (albumsList.Exists(x => x.id == id)){

                return albumsList[albumsList.FindIndex(x => x.id == id)].name;
            }
            return "no";
        }

        public override int delete(int id){
            if (isIdExists(id) != -1) {
                albumsList.RemoveAll(x => x.id == id);
                store.remove(id);
                return 1;
            }

            return 0;
        }

        public void showByGenre(int id){
            for (int i = 0; i < albumsList.Count; i++){ 
                if (albumsList[i].genresId.Exists(x => x == id)){
                    Console.WriteLine(man.getById(albumsList[i].authorId) + " - " + albumsList[i].name);
                }
            }
        }

        public void showByCountry(int id){
            for (int i = 0; i < albumsList.Count; i++) {
                if (albumsList[i].countryId == id) {
                    Console.WriteLine(man.getById(albumsList[i].authorId) + " - " + albumsList[i].name);
                }
            }
        }
        public void showByAuthor(int id){
            for (int i = 0; i < albumsList.Count; i++) {
                if (albumsList[i].authorId == id) {
                    Console.WriteLine(albumsList[i].name);
                }
            }
        }
        public void showAll(){
            for (int i = 0; i < albumsList.Count; i++) {
                Console.WriteLine(man.getById(albumsList[i].authorId) + " - " + albumsList[i].name);
            }
        }
    }

}
