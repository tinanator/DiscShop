using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class StoreManager : Manager
    {
        public Dictionary<int, int> discs = new Dictionary<int, int>();
        public void add(int albumId, int count){
            discs[albumId] = count;
        }

        public int getCount(int id){
            return discs[id];
        }

        public void getDisc(int id, int count){
            discs[id] -= count;
        }

        public bool isDiscAvailable(int id, int count){ 
            if (this.discs[id] - count >= 0){
                return true;
            }
            return false;
        }

        public void remove(int id){
            discs.Remove(id);
        }

       
    }
}
