using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public partial class BrowserViewImpl : Form, BrowserView {
    private readonly BrowserPresenter mPresenter;

    public BrowserViewImpl() {
      InitializeComponent();
      setDataBindings();
      BuildBindingSource.DataSource = new List<Build>();
      ItemSetBindingSource.DataSource = new List<ItemSet>();
      RunePageBindingSource.DataSource = new List<RunePage>();
      MasteryPageBindingSource.DataSource = new MasteryPageList();
      ChampionBindingSource.DataSource = new List<Champion>();
      mPresenter = new BrowserPresenter(this);
    }

    public void showErrorMessage(string message) {
      MessageBox.Show(message, "Error", MessageBoxButtons.OK);
    }

    public void bindBuildsControls(List<Build> buildsData) {
      BuildBindingSource.DataSource = buildsData;
    }

    public void bindChampionControls(List<Champion> championData) {
      ChampionBindingSource.DataSource = championData;
    }

    public void bindMasteryPagesControls(MasteryPageList masteryPagesData) {
      MasteryPageBindingSource.DataSource = masteryPagesData;
    }

    public void bindRunePagesControls(List<RunePage> runePagesData) {
      RunePageBindingSource.DataSource = runePagesData;
    }

    public void bindItemSetsControls(List<ItemSet> itemSetsData) {
      ItemSetBindingSource.DataSource = itemSetsData;
    }

    public void configureMasteryTrees(List<Branch> branches) {
      MasteriesTable.ColumnStyles.Clear();
      MasteriesTable.RowStyles.Clear();
      MasteriesTable.ColumnCount = branches.Count;
      MasteriesTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      var j = 0;
      foreach (Branch branch in branches) {
        var i = 1;
        MasteriesTable.RowCount = branch.Tiers.Count + 1;
        MasteriesTable.Controls.Add(new Label {
          Text = branch.Name,
          AutoSize = true,
          Anchor = AnchorStyles.None
        }, j, 0);
        foreach (Tier tier in branch.Tiers) {
          var tierTable = new TableLayoutPanel {
            RowCount = 1,
            ColumnCount = tier.Masteries.Count
          };
          MasteriesTable.Controls.Add(tierTable, j, i);
          var k = 0;
          foreach (Mastery mastery in tier.Masteries) {
            var img = new PictureBox {
              Tag = mastery
            };
            ToolTip.SetToolTip(img, mastery.Name + "\r\n" + mastery.Description);
            img.Anchor = AnchorStyles.None;
            img.SizeMode = PictureBoxSizeMode.AutoSize;
            img.Image = mastery.Image;
            var lab = new Label();
            lab.DataBindings.Add("Text", MasteryPageBindingSource, mastery.ID, false, DataSourceUpdateMode.OnPropertyChanged);
            lab.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            lab.AutoSize = true;
            lab.BackColor = Color.Black;
            lab.ForeColor = Color.White;
            lab.Font = new Font(lab.Font.FontFamily, 12, FontStyle.Bold);
            img.Controls.Add(lab);
            var r = new ColumnStyle {
              SizeType = SizeType.Percent,
              Width = 100F / tierTable.ColumnCount
            };
            tierTable.ColumnStyles.Add(r);
            tierTable.Controls.Add(img, k, 0);
            ++k;
          }

          ++i;
        }

        ++j;
      }
      for (var i = 0; i < MasteriesTable.RowCount; ++i) {
        var r = new RowStyle {
          SizeType = SizeType.Percent,
          Height = 100F / MasteriesTable.RowCount
        };
        MasteriesTable.RowStyles.Add(r);
      }
      for (var i = 0; i < MasteriesTable.ColumnCount; ++i) {
        var r = new ColumnStyle {
          SizeType = SizeType.Percent,
          Width = 100F / MasteriesTable.ColumnCount
        };
        MasteriesTable.ColumnStyles.Add(r);
      }
    }

    public string askForOpenFilePath() {
      if (openFileDialog.ShowDialog() == DialogResult.OK) {
        return openFileDialog.FileName;
      }

      return null;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e) {
      mPresenter.onOpenFileClicked();
    }

    private void BrowserView_Load(object sender, EventArgs e) {
      mPresenter.onStart();
    }

    private void BuildBindingSource_CurrentChanged(object sender, EventArgs e) {
      var build = (Build)BuildBindingSource.Current;
      ToolTip.SetToolTip(Summoner1, build.Summoner1.Tooltip);
      ToolTip.SetToolTip(Summoner2, build.Summoner2.Tooltip);
    }

    private void ChampionBindingSource_CurrentChanged(object sender, EventArgs e) {
      var champion = (Champion)ChampionBindingSource.Current;
      ToolTip.SetToolTip(Passive, champion.Passive.Tooltip);
      ToolTip.SetToolTip(Spell1, champion.Spell1.Tooltip);
      ToolTip.SetToolTip(Spell2, champion.Spell2.Tooltip);
      ToolTip.SetToolTip(Spell3, champion.Spell3.Tooltip);
      ToolTip.SetToolTip(Spell4, champion.Spell4.Tooltip);
    }

    private void ItemSetBindingSource_CurrentChanged(object sender, EventArgs e) {
      var itemset = (ItemSet)ItemSetBindingSource.Current;
      ToolTip.SetToolTip(Item1, itemset.Item1.Tooltip);
      ToolTip.SetToolTip(Item2, itemset.Item2.Tooltip);
      ToolTip.SetToolTip(Item3, itemset.Item3.Tooltip);
      ToolTip.SetToolTip(Item4, itemset.Item4.Tooltip);
      ToolTip.SetToolTip(Item5, itemset.Item5.Tooltip);
      ToolTip.SetToolTip(Item6, itemset.Item6.Tooltip);
      ToolTip.SetToolTip(Item7, itemset.Item7.Tooltip);
      ToolTip.SetToolTip(Item8, itemset.Item8.Tooltip);
      ToolTip.SetToolTip(Item9, itemset.Item9.Tooltip);
      ToolTip.SetToolTip(Item10, itemset.Item10.Tooltip);
      ToolTip.SetToolTip(Item11, itemset.Item11.Tooltip);
      ToolTip.SetToolTip(Item12, itemset.Item12.Tooltip);
      ToolTip.SetToolTip(Item13, itemset.Item13.Tooltip);
      ToolTip.SetToolTip(Item14, itemset.Item14.Tooltip);
      ToolTip.SetToolTip(Item15, itemset.Item15.Tooltip);
      ToolTip.SetToolTip(Item16, itemset.Item16.Tooltip);
      ToolTip.SetToolTip(Item17, itemset.Item17.Tooltip);
      ToolTip.SetToolTip(Item18, itemset.Item18.Tooltip);
      ToolTip.SetToolTip(Item19, itemset.Item19.Tooltip);
      ToolTip.SetToolTip(Item20, itemset.Item20.Tooltip);
      ToolTip.SetToolTip(Item21, itemset.Item21.Tooltip);
      ToolTip.SetToolTip(Item22, itemset.Item22.Tooltip);
      ToolTip.SetToolTip(Item23, itemset.Item23.Tooltip);
      ToolTip.SetToolTip(Item24, itemset.Item24.Tooltip);
    }

    private void RunePageBindingSource_CurrentChanged(object sender, EventArgs e) {
      var runepage = (RunePage)RunePageBindingSource.Current;
      ToolTip.SetToolTip(Mark1, runepage.Mark1.Tooltip);
      ToolTip.SetToolTip(Mark2, runepage.Mark2.Tooltip);
      ToolTip.SetToolTip(Mark3, runepage.Mark3.Tooltip);
      ToolTip.SetToolTip(Mark4, runepage.Mark4.Tooltip);
      ToolTip.SetToolTip(Mark5, runepage.Mark5.Tooltip);
      ToolTip.SetToolTip(Mark6, runepage.Mark6.Tooltip);
      ToolTip.SetToolTip(Mark7, runepage.Mark7.Tooltip);
      ToolTip.SetToolTip(Mark8, runepage.Mark8.Tooltip);
      ToolTip.SetToolTip(Mark9, runepage.Mark9.Tooltip);
      ToolTip.SetToolTip(Seal1, runepage.Seal1.Tooltip);
      ToolTip.SetToolTip(Seal2, runepage.Seal2.Tooltip);
      ToolTip.SetToolTip(Seal3, runepage.Seal3.Tooltip);
      ToolTip.SetToolTip(Seal4, runepage.Seal4.Tooltip);
      ToolTip.SetToolTip(Seal5, runepage.Seal5.Tooltip);
      ToolTip.SetToolTip(Seal6, runepage.Seal6.Tooltip);
      ToolTip.SetToolTip(Seal7, runepage.Seal7.Tooltip);
      ToolTip.SetToolTip(Seal8, runepage.Seal8.Tooltip);
      ToolTip.SetToolTip(Seal9, runepage.Seal9.Tooltip);
      ToolTip.SetToolTip(Glyph1, runepage.Glyph1.Tooltip);
      ToolTip.SetToolTip(Glyph2, runepage.Glyph2.Tooltip);
      ToolTip.SetToolTip(Glyph3, runepage.Glyph3.Tooltip);
      ToolTip.SetToolTip(Glyph4, runepage.Glyph4.Tooltip);
      ToolTip.SetToolTip(Glyph5, runepage.Glyph5.Tooltip);
      ToolTip.SetToolTip(Glyph6, runepage.Glyph6.Tooltip);
      ToolTip.SetToolTip(Glyph7, runepage.Glyph7.Tooltip);
      ToolTip.SetToolTip(Glyph8, runepage.Glyph8.Tooltip);
      ToolTip.SetToolTip(Glyph9, runepage.Glyph9.Tooltip);
      ToolTip.SetToolTip(Quint1, runepage.Quint1.Tooltip);
      ToolTip.SetToolTip(Quint2, runepage.Quint2.Tooltip);
      ToolTip.SetToolTip(Quint3, runepage.Quint3.Tooltip);
    }

    private void ImageBinding_Format(object sender, ConvertEventArgs e) {
      var binding = (Binding)sender;
      var box = (PictureBox)binding.Control;
      if (box != null && box.Image != null) {
        box.Image.Dispose();
      }
    }

    private void setDataBindings() {
      var binding = new Binding("Image", ChampionBindingSource, "PassiveImage", true);
      binding.Format += ImageBinding_Format;
      Passive.DataBindings.Add(binding);
      binding = new Binding("Image", ChampionBindingSource, "Spell1Image", true);
      binding.Format += ImageBinding_Format;
      Spell1.DataBindings.Add(binding);
      binding = new Binding("Image", ChampionBindingSource, "Spell2Image", true);
      binding.Format += ImageBinding_Format;
      Spell2.DataBindings.Add(binding);
      binding = new Binding("Image", ChampionBindingSource, "Spell3Image", true);
      binding.Format += ImageBinding_Format;
      Spell3.DataBindings.Add(binding);
      binding = new Binding("Image", ChampionBindingSource, "Spell4Image", true);
      binding.Format += ImageBinding_Format;
      Spell4.DataBindings.Add(binding);
      binding = new Binding("Image", BuildBindingSource, "Summoner1Image", true);
      binding.Format += ImageBinding_Format;
      Summoner1.DataBindings.Add(binding);
      binding = new Binding("Image", BuildBindingSource, "Summoner2Image", true);
      binding.Format += ImageBinding_Format;
      Summoner2.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item1Image", true);
      binding.Format += ImageBinding_Format;
      Item1.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item2Image", true);
      binding.Format += ImageBinding_Format;
      Item2.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item3Image", true);
      binding.Format += ImageBinding_Format;
      Item3.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item4Image", true);
      binding.Format += ImageBinding_Format;
      Item4.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item5Image", true);
      binding.Format += ImageBinding_Format;
      Item5.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item6Image", true);
      binding.Format += ImageBinding_Format;
      Item6.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item7Image", true);
      binding.Format += ImageBinding_Format;
      Item7.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item8Image", true);
      binding.Format += ImageBinding_Format;
      Item8.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item9Image", true);
      binding.Format += ImageBinding_Format;
      Item9.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item10Image", true);
      binding.Format += ImageBinding_Format;
      Item10.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item11Image", true);
      binding.Format += ImageBinding_Format;
      Item11.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item12Image", true);
      binding.Format += ImageBinding_Format;
      Item12.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item13Image", true);
      binding.Format += ImageBinding_Format;
      Item13.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item14Image", true);
      binding.Format += ImageBinding_Format;
      Item14.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item15Image", true);
      binding.Format += ImageBinding_Format;
      Item15.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item16Image", true);
      binding.Format += ImageBinding_Format;
      Item16.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item17Image", true);
      binding.Format += ImageBinding_Format;
      Item17.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item18Image", true);
      binding.Format += ImageBinding_Format;
      Item18.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item19Image", true);
      binding.Format += ImageBinding_Format;
      Item19.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item20Image", true);
      binding.Format += ImageBinding_Format;
      Item20.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item21Image", true);
      binding.Format += ImageBinding_Format;
      Item21.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item22Image", true);
      binding.Format += ImageBinding_Format;
      Item22.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item23Image", true);
      binding.Format += ImageBinding_Format;
      Item23.DataBindings.Add(binding);
      binding = new Binding("Image", ItemSetBindingSource, "Item24Image", true);
      binding.Format += ImageBinding_Format;
      Item24.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark1Image", true);
      binding.Format += ImageBinding_Format;
      Mark1.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark2Image", true);
      binding.Format += ImageBinding_Format;
      Mark2.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark3Image", true);
      binding.Format += ImageBinding_Format;
      Mark3.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark4Image", true);
      binding.Format += ImageBinding_Format;
      Mark4.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark5Image", true);
      binding.Format += ImageBinding_Format;
      Mark5.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark6Image", true);
      binding.Format += ImageBinding_Format;
      Mark6.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark7Image", true);
      binding.Format += ImageBinding_Format;
      Mark7.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark8Image", true);
      binding.Format += ImageBinding_Format;
      Mark8.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Mark9Image", true);
      binding.Format += ImageBinding_Format;
      Mark9.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal1Image", true);
      binding.Format += ImageBinding_Format;
      Seal1.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal2Image", true);
      binding.Format += ImageBinding_Format;
      Seal2.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal3Image", true);
      binding.Format += ImageBinding_Format;
      Seal3.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal4Image", true);
      binding.Format += ImageBinding_Format;
      Seal4.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal5Image", true);
      binding.Format += ImageBinding_Format;
      Seal5.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal6Image", true);
      binding.Format += ImageBinding_Format;
      Seal6.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal7Image", true);
      binding.Format += ImageBinding_Format;
      Seal7.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal8Image", true);
      binding.Format += ImageBinding_Format;
      Seal8.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Seal9Image", true);
      binding.Format += ImageBinding_Format;
      Seal9.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph1Image", true);
      binding.Format += ImageBinding_Format;
      Glyph1.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph2Image", true);
      binding.Format += ImageBinding_Format;
      Glyph2.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph3Image", true);
      binding.Format += ImageBinding_Format;
      Glyph3.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph4Image", true);
      binding.Format += ImageBinding_Format;
      Glyph4.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph5Image", true);
      binding.Format += ImageBinding_Format;
      Glyph5.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph6Image", true);
      binding.Format += ImageBinding_Format;
      Glyph6.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph7Image", true);
      binding.Format += ImageBinding_Format;
      Glyph7.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph8Image", true);
      binding.Format += ImageBinding_Format;
      Glyph8.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Glyph9Image", true);
      binding.Format += ImageBinding_Format;
      Glyph9.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Quint1Image", true);
      binding.Format += ImageBinding_Format;
      Quint1.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Quint2Image", true);
      binding.Format += ImageBinding_Format;
      Quint2.DataBindings.Add(binding);
      binding = new Binding("Image", RunePageBindingSource, "Quint3Image", true);
      binding.Format += ImageBinding_Format;
      Quint3.DataBindings.Add(binding);
      binding = new Binding("Image", ChampionBindingSource, "Image", true);
      binding.Format += ImageBinding_Format;
      ChampionImage.DataBindings.Add(binding);
    }
  }
}
