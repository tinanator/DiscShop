using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class Author
    {
        public Author(int id, string name){
            this.id = id;
            this.name = name;
        }
        public int id{
            get => _id;
            private set { _id = value; }
        }
        public string name{
            get => _name;
            private set{ _name = value; }
        }
        private int _id;
        private string _name;
        
    }

    class Genre
    {
        public Genre(int id, string name){
            this.id = id;
            this.name = name;
        }
        public int id{
            get => _id;
            private set{ _id = value; }
        }
        public string name{
            get => _name;
            private set { _name = value; }
        }
        private int _id;
        private string _name;
    }

    class Album
    {
        public Album(int id, string name, int authorId, List<int> genresId, int countryId){
            this.id = id;
            this.name = name;
            this.authorId = authorId;
            this.genresId = genresId;
            this.countryId = countryId;
        }
        public int id{
            get => _id;
            private set{ _id = value; }
        }
        public string name{
            get => _name;
            private set{ _name = value; }
        }
        public int authorId{
            get => _authorId;
            private set{ _authorId = value; }
        }
        public List<int> genresId{
            get => _genresId;
            private set{ _genresId = value; }
        }
        public int countryId{
            get => _countryId;
            private set { _countryId = value; }
        }

        private int _id;
        private string _name;
        private int _authorId;
        private List<int> _genresId;
        private int _countryId;
    }

    class Country
    {
        public Country(int id, string name){
            this.id = id;
            this.name = name;
        }

        public int id{
            get => _id; 
            private set { _id = value; }
        }
        private int _id;
        private string _name;

        public string name{
            get => _name;
            private set { _name = value; }
        }
    }

    
}
