using System;
using System.Collections.Generic;
using System.Text;

namespace task2Console
{
    class Manager
    {
        public Manager(){ }
        public virtual int getId(string name){ return 0;}
        public virtual int add(string name){ return 0; }
        public virtual int delete(int id){ }
        public virtual string getById(int id){ return "no"; }

    }
}
