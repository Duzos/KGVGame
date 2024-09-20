using Games;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public abstract class Registry<T> where T : Identifiable
    {
        public readonly Hashtable lookup;

        protected Registry()
        {
            lookup = new Hashtable();

            Defaults();
        }

        protected abstract void Defaults();

        public T Register(string id, T value)
        {
            lookup.Add(id, value);

            return value;
        }
        public T Register(T value)
        {
            return this.Register(value.id(), value);
        }

        public T Get(string id)
        {
            if (!this.lookup.ContainsKey(id)) return default;

            return (T)this.lookup[id];
        }
    }
}
