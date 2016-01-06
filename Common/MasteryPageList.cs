using System.ComponentModel;

namespace com.jcandksolutions.lol {
  public class MasteryPageList : BindingList<MasteryPage>, ITypedList {
    PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors) {
      var names = MasteryPage.MasteryNames;
      PropertyDescriptor[] props = new PropertyDescriptor[names.Count];
      int i = 0;
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
