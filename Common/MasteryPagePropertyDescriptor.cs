using System;
using System.ComponentModel;

namespace com.jcandksolutions.lol {
  public class MasteryPagePropertyDescriptor : PropertyDescriptor {
    public override Type ComponentType {
      get {
        return typeof(MasteryPage);
      }
    }
    public override bool IsReadOnly {
      get {
        return false;
      }
    }
    public override Type PropertyType {
      get {
        return typeof(string);
      }
    }

    public MasteryPagePropertyDescriptor(string name) : base(name, null) {
    }

    public override object GetValue(object component) {
      return ((MasteryPage)component)[Name];
    }

    public override void SetValue(object component, object value) {
      ((MasteryPage)component)[Name] = (string)value;
    }

    public override bool CanResetValue(object component) {
      return true;
    }

    public override void ResetValue(object component) {
      ((MasteryPage)component)[Name] = null;
    }

    public override bool ShouldSerializeValue(object component) {
      return ((MasteryPage)component)[Name] != null;
    }
  }
}
