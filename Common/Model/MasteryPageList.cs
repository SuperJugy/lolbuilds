using System.Collections.Generic;
using System.ComponentModel;

namespace com.jcandksolutions.lol.Model {
  public class MasteryPageList : BindingList<MasteryPage>, ITypedList {
    PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors) {
      HashSet<string> names = MasteryPage.MasteryNames;
      var props = new PropertyDescriptor[names.Count];
      var i = 0;
      foreach (string key in names) {
        props[i] = new MasteryPagePropertyDescriptor(key);
        ++i;
      }
      return new PropertyDescriptorCollection(props, true);
    }

    string ITypedList.GetListName(PropertyDescriptor[] listAccessors) {
      return "Foo";
    }
  }
}
