using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Entity_Prototype
{
    class Entity
    {
        public int Id { get; set; }

        public Entity() { }
        public Entity(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            string ris = null;
            
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                ris += property.Name + " " + property.GetValue(this) + "\n";
            }

            return ris;
        }

        public void FromDictionary(Dictionary<string, string> diz)
        {
            foreach(PropertyInfo property in this.GetType().GetProperties())
            {
                if (diz.ContainsKey(property.Name.ToLower()))
                {
                    object val = diz[property.Name.ToLower()];

                    switch (property.PropertyType.Name.ToLower())
                    {
                        case "datetime": 
                            val = DateTime.Parse(diz[property.Name.ToLower()]); 
                            break;
                        case "int32":
                            val = int.Parse(diz[property.Name.ToLower()]);
                            break;
                        case "double":
                            val = double.Parse(diz[property.Name.ToLower()]);
                            break;
                        case "boolean":
                            val = bool.Parse(diz[property.Name.ToLower()]);
                            break;
                    }
                    property.SetValue(this, val);
                }

            }

        }
    }
}
