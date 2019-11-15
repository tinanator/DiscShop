using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class CashierManager
    {
        private StoreManager store;
        public CashierManager(StoreManager store){
            this.store = store;
        }

        public int buy(int id, int count){
            if (this.store.isDiscAvailable(id, count)){
                store.getDisc(id, count);
                return 1;
            }
            return 0;
        } 
    }
}
