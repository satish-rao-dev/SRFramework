using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRFramework.WPF.ExtensionMethods
{
    public static class ListExtensionMethods
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
        {
            if (list == null)
                return null;
            return new ObservableCollection<T>(list);
        }
    }
}
