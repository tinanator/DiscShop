using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace task2Console
{
    class Program
    {
        static void add(Manager man, string name){
            int id = man.add(name);
            if (id == -1) {
                Console.WriteLine("already exists");
            } else {
                Console.WriteLine("id = " + id);
            }
        }
        static void delete(Manager man, int id, string name) {   
            if (man.delete(id) == 1) {
                Console.WriteLine(name + " is deleted");
            } else {
                Console.WriteLine("No genre with such id");
            }
        }
        static string getName(ref String[] arg){
            string name = "";
            for (int i = 2; i < arg.Length; i++) {
                name += arg[i];
                name += ' ';
            }
            return name.Trim();
        }
        static void Main(string[] args)
        {
            bool isReading = true;
            StoreManager store = new StoreManager();
            CashierManager cashier = new CashierManager(store);
            GenreManager genreManager = new GenreManager();
            AuthorManager authorManager = new AuthorManager();
            CountryManager countryManager = new CountryManager();
            AlbumManager albumManager = new AlbumManager(authorManager, store);


            ///////////////////////test//////////////////////////////////////////////////////
            var genres1 = new List<string> {"rock", "jazz", "blues", "rnb",
                "classic", "soul", "metall", "pop", "pop-rock", "grunge", "punk"};//11
            var countries1 = new List<string> {"usa", "russia", "italia", "france", "britain", "germany"};//6
            var authors1 = new List<string> {"deep purple", "rammstein", "queen", "muse", "zaz",
                "italian guy", "alla pugachova", "stas mikhailov", "vsemi loubim", "arctic monkeys", "mozart", "lady gaga"};//12

            int state = 0;
            int index = 0;
            //////////////////////////test/////////////////////////////////////////////////////
            string[] arg = {};
            while (true){

                if (!isReading) {
                    arg = ((Console.ReadLine()).Trim()).Split(' ');
                }

                ////////////////////TEST/////////////////////////////////
                
                if (isReading){
                    //string[] arg = Console.ReadLine().Split(' ');
                    if (state == 0) {
                        Console.Write("add genre " + genres1[index] + "\n");
                        arg = ("add genre " + genres1[index++]).Split(' ');
                        if (index == 10) {
                            state++;
                            index = 0;
                        }
                    } else if (state == 1) {
                        Console.Write("add country " + countries1[index] + "\n");
                        arg = ("add country " + countries1[index++]).Split(' ');
                        if (index == 5) {
                            state++;
                            index = 0;
                        }
                    } else {
                        Console.Write("add author " + authors1[index] + "\n");
                        arg = ("add author " + authors1[index++]).Split(' ');
                        if (index == 11) {
                            state++;
                            index = 0;
                            isReading = false;
                        }
                    }
                }
                ///////////////////////////////////////////////
           
                switch (arg[0]){
                    case "add":{
                        try{
                            if (arg[1] == "genre") {
                                add(genreManager, arg[2]);
                            }
                            else if (arg[1] == "author") {
                                add(authorManager, getName(ref arg));
                            }
                            else if (arg[1] == "country") {
                                add(countryManager, getName(ref arg));
                            }
                            else if (arg[1] == "album") {
                                string name = getName(ref arg);
                                if (name == "") {
                                    Console.WriteLine("Wrong name");
                                    continue;
                                }
                                Console.Write("author id: ");
                                int author = 0;
                                author = int.Parse(Console.ReadLine());
                                if (authorManager.isIdExists(author) == 0){
                                    Console.WriteLine("No author with this id");
                                    continue;
                                } else {
                                    Console.Write("genres ids: ");
                                    string[] genres = Console.ReadLine().Split(' ');
                                    List<int> genresList = new List<int>();
                                    bool b = false;
                                    for (int i = 0; i < genres.Length; i++) {
                                        if (genreManager.isIdExists(int.Parse(genres[i])) == 0) {
                                            Console.WriteLine("No genre with this id");
                                            b = true;
                                        }
                                    genresList.Add(int.Parse(genres[i]));
                                    }
                                    if (b) continue;
                                    Console.Write("country id: ");
                                    int country = int.Parse(Console.ReadLine());
                                    if (countryManager.isIdExists(country) == 0) {
                                        Console.WriteLine("No country with this id");
                                        continue;
                                    }
                                    int id = albumManager.add(name.Trim(), author, genresList, country);
                                    if (id == -1) {
                                        Console.WriteLine("already exists");
                                        continue;
                                    } else {
                                        Console.WriteLine("id = " + id);
                                    }
                                    store.add(id, 0);
                                }
                            } 
                            else {
                                Console.WriteLine("command is not correct");
                            }
                        }
                        catch(IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                        catch(FormatException){
                            Console.WriteLine("Id must be a number");
                        }   
                    }
                    break;

                    case "getId":{ 
                        try{
                            if (arg[1] == "genre") {
                                int id = genreManager.getId(arg[2]);
                                if (id == -1) {
                                    Console.WriteLine("This genre doesn't exist");
                                } else {
                                    Console.WriteLine("id = " + id);
                                }
                            }
                            else if (arg[1] == "author") {
                                string name = getName(ref arg);
                                if (name == ""){
                                    Console.WriteLine("Command is not correct");
                                    continue;
                                }
                                int id = authorManager.getId(name);
                                if (id == -1) {
                                    Console.WriteLine("This author doesn't exist");
                                } else {
                                    Console.WriteLine("id = " + id);
                                }
                            }
                            else if (arg[1] == "country") {
                                string name = getName(ref arg);
                               
                                if (name == "") {
                                    Console.WriteLine("Command is not correct");
                                    continue;
                                }
                                int id = countryManager.getId(name);
                                if (id == -1) {
                                Console.WriteLine("This country doesn't exists");
                                } else {
                                    Console.WriteLine("id = " + id);
                                }
                            }
                            else if (arg[1] == "album") {
                                string name = getName(ref arg);
                                if (name == ""){
                                    Console.WriteLine("Command is not correct");
                                    continue;
                                }
                                Console.Write("Author: ");
                                try{

                                    int albumId = albumManager.getId(name, int.Parse(Console.ReadLine()));
                                    if (albumId == -1){
                                        Console.WriteLine("This album doesn't exist");
                                    }
                                    else{
                                        Console.WriteLine("id = " + albumId);
                                    }
                                }
                                catch(FormatException){
                                    Console.WriteLine("Id must be a number");
                                }
                            } 
                            else {
                                Console.WriteLine("Command is not correct");
                            }
                        }
                        catch(IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                            

                    break;
                    }
                    case "delete":{ 
                        try{
                            if (arg[1] == "genre") {
                                delete(genreManager, int.Parse(arg[2]), "genre");
                                albumManager.deleteByGenre(int.Parse(arg[2]));
                            } 
                            else if (arg[1] == "country") {
                                delete(countryManager, int.Parse(arg[2]), "country");
                                albumManager.deleteByCountry(int.Parse(arg[2]));
                            } 
                            else if (arg[1] == "author") {
                                delete(authorManager, int.Parse(arg[2]), "author");
                                albumManager.deleteByAuthor(int.Parse(arg[2]));
                            } 
                            else if (arg[1] == "album") {
                                delete(albumManager, int.Parse(arg[2]), "album");
                            } else {
                                Console.WriteLine("Command is not correct");
                            }
                        }
                        catch(IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                    }break;
                    case "getById":{ 
                        try{
                            if (arg[1] == "genre") {
                               
                                int id = int.Parse(arg[2]);
                                if (genreManager.isIdExists(id) == 0) {
                                    Console.WriteLine("No genre with this id");
                                    continue;
                                }
                                Console.WriteLine(genreManager.getById(id));
                                    
                            } else if (arg[1] == "author") {
                               
                                int id = int.Parse(arg[2]);
                                if (authorManager.isIdExists(id) == 0) {
                                    Console.WriteLine("No author with this id");
                                }
                                Console.WriteLine(authorManager.getById(id));
  
                            } else if (arg[1] == "country") {
                             
                                int id = int.Parse(arg[2]);
                                if (countryManager.isIdExists(id) == 0) {
                                    Console.WriteLine("No country with this id");
                                    continue;
                                }
                                Console.WriteLine(countryManager.getById(id));
                               
                            } else if (arg[1] == "album") {
                               
                                int id = int.Parse(arg[2]);
                                if (albumManager.isIdExists(id) == 0) {
                                    Console.WriteLine("No album with this id");
                                    continue;
                                }
                            
                                Console.WriteLine(albumManager.getById(id) + " - " + albumManager.getAuthorId(id));
                               
                            }
                            else{
                                Console.WriteLine("Command is not correct");
                            }
                        } 
                        catch (IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                        catch (FormatException){
                            Console.WriteLine("Id must be a number");        
                        }
                            
                    }break;
                    
                    case "addToStore": {
                            try{
                                int id = int.Parse(arg[1]);
                                if (albumManager.getById(id) == "no") {
                                    Console.WriteLine("No disc with such id");
                                    continue;
                                }
                                int count = int.Parse(arg[2]);
                                store.add(id, count);
                                Console.WriteLine("Added " + count + " discs");
                            }
                            catch(IndexOutOfRangeException){
                                Console.WriteLine("not enough arguments");
                            }
                            catch(FormatException){
                                Console.WriteLine("Id and count must be numbers");
                            }

                        }break;
                    case "buy":{
                        try{
                            int id = int.Parse(arg[1]);
                            if (albumManager.getById(id) == "no") {
                                Console.WriteLine("Your order is rejected. No disc with such id");
                                continue;
                            }
                            int count = int.Parse(arg[2]);
                            int isBought = cashier.buy(id, count);
                            if (isBought == 1) {
                                Console.WriteLine("Your order is accepted");
                            } else {
                                Console.WriteLine("Your order is rejected");
                            }
                        }
                        catch(FormatException){
                            Console.WriteLine("id and count must be numbers");
                        }
                        catch(IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                            
                    } break;
                    case "count":{
                        try{
                            int id = int.Parse(arg[1]);
                            if (albumManager.getById(id) == "no") {
                                Console.WriteLine("No album with such id");
                                continue;
                            }
                            Console.WriteLine(store.getCount(id));
                        }
                        catch(IndexOutOfRangeException) {
                            Console.WriteLine("not enough arguments");
                        }
                        catch(FormatException){
                            Console.WriteLine("Id and count must be numbers");
                        }
                          
                    }
                    break;
                    case "showBy":{
                        try{
                            if (arg[1] == "genre") {
                                albumManager.showByGenre(int.Parse(arg[2]));
                            } else if (arg[1] == "country") {
                                albumManager.showByCountry(int.Parse(arg[2]));
                            } else if (arg[1] == "author") {
                                albumManager.showByAuthor(int.Parse(arg[2]));
                            }
                        }
                        catch(IndexOutOfRangeException){
                            Console.WriteLine("not enough arguments");
                        }
                        catch(FormatException){
                            Console.WriteLine("Id must be a number");
                        }
                            
                    }break;
                    case "showAuthor": {
                        try{
                            int id = int.Parse(arg[1]);
                            Console.WriteLine(albumManager.getAuthorId(id));
                        }
                        catch(FormatException){
                            Console.WriteLine("Id must be a number");
                        }
                        
                    }
                    break;
                    case "showCountry":{
                        try {
                            int id = int.Parse(arg[1]);
                            Console.WriteLine(albumManager.getCounryId(id));
                        } catch (FormatException) {
                            Console.WriteLine("Id must be a number");
                        }
                    }
                    break;
                    case "showGenres":{

                        try {
                            
                            List<int> tmpGenres = new List<int>();
                            int id = int.Parse(arg[1]);
                            tmpGenres = albumManager.getGenresList(id);
                            for (int i = 0; i < tmpGenres.Count; i++){
                                Console.Write(tmpGenres[i]);
                                Console.Write(' ');
                            }
                            Console.WriteLine();
                            
                        } catch (FormatException) {
                            Console.WriteLine("Id must be a number");
                        }
                    }
                    break;
                    case "showAll":{
                            albumManager.showAll();
                        }
                        break;
                    case "showStore":{
                            albumManager.showStore();    
                    } break;
                    case "exit":
                        return;
                    default:{ Console.WriteLine(""); } break; 
                    
                }
            }
        }
    }
}
