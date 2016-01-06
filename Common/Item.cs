﻿using System.Drawing;

namespace com.jcandksolutions.lol {
  public class Item {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public string Gold { get; set; }
    public Bitmap Image {
      get {
        return string.IsNullOrWhiteSpace(ImageURL) ? null : new Bitmap("img/item/" + ImageURL);
      }
    }
    public string Tooltip {
      get {
        return Name + "\n\rCost: "+ Gold + "\n\r" + Description;
      }
    }

    public override string ToString() {
      return Name;
    }
  }
}
