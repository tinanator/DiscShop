using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
     class AuthorManager : Manager
    {
        static List<Author> authorsList = new List<Author>();
        static int nextId = 0;
        
        public override int add(string newName) {
            for (int i = 0; i < authorsList.Count; i++){
                if (authorsList[i].name == newName) {
                    return -1;
                }
            }
            int id = nextId++;
            Author newAuthor = new Author(id, newName);
            authorsList.Add(newAuthor);
            return id;
        }

        public override int getId(string author){
            for (int i = 0; i < authorsList.Count; i++){
                if (authorsList[i].name == author) {
                    return authorsList[i].id;
                }
            }
            return -1;
        }

        public int isIdExists(int id)
        {
            if (authorsList.Exists(x => x.id == id)) {
                return 1;
            }
            return 0;
        }

        public override int delete(int id){
            
            if (isIdExists(id) != -1) {
                authorsList.RemoveAll(x => x.id == id);
                return 1;
            }
            return 0;
        }
        public override string getById(int id){
            for (int i = 0; i < authorsList.Count; i++) {
                if (authorsList[i].id == id) {
                    return authorsList[i].name;
                }
            }
            return "no";
        }
        public void getAll(){ 
            for (int i = 0; i < authorsList.Count; i++){
                Console.WriteLine(authorsList[i].name);
            }
        }
        
    }
}
