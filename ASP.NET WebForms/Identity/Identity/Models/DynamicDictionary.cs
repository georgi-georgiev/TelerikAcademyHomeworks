using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class DynamicDictionary : DynamicObject, INotifyPropertyChanged
    {
        public DynamicDictionary()
        {
            InternalValues = new Dictionary<string, object>();
        }
        //public DynamicRow Row { get; protected set; }
        protected Dictionary<string, object> InternalValues { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return InternalValues.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {

            InternalValues[binder.Name] = value;
            FirePropertyChanged(binder.Name);
            return true;
        }

        public void FirePropertyChanged(string propName)
        {
            var propChange = PropertyChanged;
            if (propChange != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}