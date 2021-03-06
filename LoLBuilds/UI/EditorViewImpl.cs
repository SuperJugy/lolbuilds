﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using com.jcandksolutions.lol.Model;

namespace com.jcandksolutions.lol.UI {
  public partial class EditorViewImpl : Form, EditorView {
    private readonly Dictionary<string, Button> mMasteryButtons = new Dictionary<string, Button>();
    private readonly EditorPresenter mPresenter;
    private Build mCurrentBuild;
    private ItemSet mCurrentItemSet;
    private MasteryPage mCurrentMasteryPage;
    private RunePage mCurrentRunePage;

    public EditorViewImpl() {
      InitializeComponent();
      mPresenter = new EditorPresenter(this);
    }

    public bool shouldPauseBinding { private get; set; }

    public void showErrorMessage(string message) {
      MessageBox.Show(message, "Error", MessageBoxButtons.OK);
    }

    public void updateBuildsDropdown(object[] buildsList) {
      BuildName.Items.Clear();
      BuildName.Items.AddRange(buildsList);
      checkBuildsCount(true);
    }

    public void updateMasteryPagesDropdown(object[] masteryPagesList) {
      MasteryPage.Items.Clear();
      MasteryPage.Items.AddRange(masteryPagesList);
      MasteryPageName.Items.Clear();
      MasteryPageName.Items.AddRange(masteryPagesList);
      checkMasteryPagesCount(true);
    }

    public void updateRunePagesDropdown(object[] runePagesList) {
      RunePage.Items.Clear();
      RunePage.Items.AddRange(runePagesList);
      RunePageName.Items.Clear();
      RunePageName.Items.AddRange(runePagesList);
      checkRunePagesCount(true);
    }

    public void updateItemSetsDropdown(object[] itemSetsList) {
      ItemSet.Items.Clear();
      ItemSet.Items.AddRange(itemSetsList);
      ItemSetName.Items.Clear();
      ItemSetName.Items.AddRange(itemSetsList);
      checkItemSetsCount(true);
    }

    public void configureBuildsDropdowns(object[] championsList, object[] summonersList) {
      Champion.Tag = new BuildBind(BuildBind.Prop.Champion);
      ItemSet.Tag = new BuildBind(BuildBind.Prop.ItemSet);
      RunePage.Tag = new BuildBind(BuildBind.Prop.RunePage);
      MasteryPage.Tag = new BuildBind(BuildBind.Prop.MasteryPage);
      StartAbilities.Tag = new BuildBind(BuildBind.Prop.StartAbilities);
      MaxOrder.Tag = new BuildBind(BuildBind.Prop.MaxOrder);
      Summoner1.Tag = new BuildBind(BuildBind.Prop.Summoner1);
      Summoner2.Tag = new BuildBind(BuildBind.Prop.Summoner2);
      Champion.Items.AddRange(championsList);
      Summoner1.Items.AddRange(summonersList);
      Summoner2.Items.AddRange(summonersList);
    }

    public void configureRunePagesDropdowns(object[] marksList, object[] sealsList, object[] glyphsList, object[] quintsList) {
      Mark1.Tag = new RunePageBind(RunePageBind.Prop.Mark1);
      Mark2.Tag = new RunePageBind(RunePageBind.Prop.Mark2);
      Mark3.Tag = new RunePageBind(RunePageBind.Prop.Mark3);
      Mark4.Tag = new RunePageBind(RunePageBind.Prop.Mark4);
      Mark5.Tag = new RunePageBind(RunePageBind.Prop.Mark5);
      Mark6.Tag = new RunePageBind(RunePageBind.Prop.Mark6);
      Mark7.Tag = new RunePageBind(RunePageBind.Prop.Mark7);
      Mark8.Tag = new RunePageBind(RunePageBind.Prop.Mark8);
      Mark9.Tag = new RunePageBind(RunePageBind.Prop.Mark9);
      Seal1.Tag = new RunePageBind(RunePageBind.Prop.Seal1);
      Seal2.Tag = new RunePageBind(RunePageBind.Prop.Seal2);
      Seal3.Tag = new RunePageBind(RunePageBind.Prop.Seal3);
      Seal4.Tag = new RunePageBind(RunePageBind.Prop.Seal4);
      Seal5.Tag = new RunePageBind(RunePageBind.Prop.Seal5);
      Seal6.Tag = new RunePageBind(RunePageBind.Prop.Seal6);
      Seal7.Tag = new RunePageBind(RunePageBind.Prop.Seal7);
      Seal8.Tag = new RunePageBind(RunePageBind.Prop.Seal8);
      Seal9.Tag = new RunePageBind(RunePageBind.Prop.Seal9);
      Glyph1.Tag = new RunePageBind(RunePageBind.Prop.Glyph1);
      Glyph2.Tag = new RunePageBind(RunePageBind.Prop.Glyph2);
      Glyph3.Tag = new RunePageBind(RunePageBind.Prop.Glyph3);
      Glyph4.Tag = new RunePageBind(RunePageBind.Prop.Glyph4);
      Glyph5.Tag = new RunePageBind(RunePageBind.Prop.Glyph5);
      Glyph6.Tag = new RunePageBind(RunePageBind.Prop.Glyph6);
      Glyph7.Tag = new RunePageBind(RunePageBind.Prop.Glyph7);
      Glyph8.Tag = new RunePageBind(RunePageBind.Prop.Glyph8);
      Glyph9.Tag = new RunePageBind(RunePageBind.Prop.Glyph9);
      Quint1.Tag = new RunePageBind(RunePageBind.Prop.Quint1);
      Quint2.Tag = new RunePageBind(RunePageBind.Prop.Quint2);
      Quint3.Tag = new RunePageBind(RunePageBind.Prop.Quint3);
      Mark1.Items.AddRange(marksList);
      Mark2.Items.AddRange(marksList);
      Mark3.Items.AddRange(marksList);
      Mark4.Items.AddRange(marksList);
      Mark5.Items.AddRange(marksList);
      Mark6.Items.AddRange(marksList);
      Mark7.Items.AddRange(marksList);
      Mark8.Items.AddRange(marksList);
      Mark9.Items.AddRange(marksList);
      Seal1.Items.AddRange(sealsList);
      Seal2.Items.AddRange(sealsList);
      Seal3.Items.AddRange(sealsList);
      Seal4.Items.AddRange(sealsList);
      Seal5.Items.AddRange(sealsList);
      Seal6.Items.AddRange(sealsList);
      Seal7.Items.AddRange(sealsList);
      Seal8.Items.AddRange(sealsList);
      Seal9.Items.AddRange(sealsList);
      Glyph1.Items.AddRange(glyphsList);
      Glyph2.Items.AddRange(glyphsList);
      Glyph3.Items.AddRange(glyphsList);
      Glyph4.Items.AddRange(glyphsList);
      Glyph5.Items.AddRange(glyphsList);
      Glyph6.Items.AddRange(glyphsList);
      Glyph7.Items.AddRange(glyphsList);
      Glyph8.Items.AddRange(glyphsList);
      Glyph9.Items.AddRange(glyphsList);
      Quint1.Items.AddRange(quintsList);
      Quint2.Items.AddRange(quintsList);
      Quint3.Items.AddRange(quintsList);
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
            var but = new Button();
            if (tier.Limit == 1) {
              but.Click += Mastery1Button_Click;
            } else {
              but.Click += Mastery5Button_Click;
            }
            but.MouseUp += MasteryButton_MouseUp;
            ToolTip.SetToolTip(but, mastery.Name + "\r\n" + mastery.Description);
            but.AutoSize = true;
            but.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            but.Anchor = AnchorStyles.None;
            but.Tag = new MasteryPageBind(mastery);
            but.TextChanged += MasteryPageChanged;
            mMasteryButtons.Add(mastery.ID, but);
            var r = new ColumnStyle {
              SizeType = SizeType.Percent,
              Width = 100F / tierTable.ColumnCount
            };
            tierTable.ColumnStyles.Add(r);
            tierTable.Controls.Add(but, k, 0);
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

    public void configureItemSetsDropdowns(object[] itemsList) {
      Item1.Tag = new ItemSetBind(ItemSetBind.Prop.Item1);
      Item2.Tag = new ItemSetBind(ItemSetBind.Prop.Item2);
      Item3.Tag = new ItemSetBind(ItemSetBind.Prop.Item3);
      Item4.Tag = new ItemSetBind(ItemSetBind.Prop.Item4);
      Item5.Tag = new ItemSetBind(ItemSetBind.Prop.Item5);
      Item6.Tag = new ItemSetBind(ItemSetBind.Prop.Item6);
      Item7.Tag = new ItemSetBind(ItemSetBind.Prop.Item7);
      Item8.Tag = new ItemSetBind(ItemSetBind.Prop.Item8);
      Item9.Tag = new ItemSetBind(ItemSetBind.Prop.Item9);
      Item10.Tag = new ItemSetBind(ItemSetBind.Prop.Item10);
      Item11.Tag = new ItemSetBind(ItemSetBind.Prop.Item11);
      Item12.Tag = new ItemSetBind(ItemSetBind.Prop.Item12);
      Item13.Tag = new ItemSetBind(ItemSetBind.Prop.Item13);
      Item14.Tag = new ItemSetBind(ItemSetBind.Prop.Item14);
      Item15.Tag = new ItemSetBind(ItemSetBind.Prop.Item15);
      Item16.Tag = new ItemSetBind(ItemSetBind.Prop.Item16);
      Item17.Tag = new ItemSetBind(ItemSetBind.Prop.Item17);
      Item18.Tag = new ItemSetBind(ItemSetBind.Prop.Item18);
      Item19.Tag = new ItemSetBind(ItemSetBind.Prop.Item19);
      Item20.Tag = new ItemSetBind(ItemSetBind.Prop.Item20);
      Item21.Tag = new ItemSetBind(ItemSetBind.Prop.Item21);
      Item22.Tag = new ItemSetBind(ItemSetBind.Prop.Item22);
      Item23.Tag = new ItemSetBind(ItemSetBind.Prop.Item23);
      Item24.Tag = new ItemSetBind(ItemSetBind.Prop.Item24);
      Item1.Items.AddRange(itemsList);
      Item2.Items.AddRange(itemsList);
      Item3.Items.AddRange(itemsList);
      Item4.Items.AddRange(itemsList);
      Item5.Items.AddRange(itemsList);
      Item6.Items.AddRange(itemsList);
      Item7.Items.AddRange(itemsList);
      Item8.Items.AddRange(itemsList);
      Item9.Items.AddRange(itemsList);
      Item10.Items.AddRange(itemsList);
      Item11.Items.AddRange(itemsList);
      Item12.Items.AddRange(itemsList);
      Item13.Items.AddRange(itemsList);
      Item14.Items.AddRange(itemsList);
      Item15.Items.AddRange(itemsList);
      Item16.Items.AddRange(itemsList);
      Item17.Items.AddRange(itemsList);
      Item18.Items.AddRange(itemsList);
      Item19.Items.AddRange(itemsList);
      Item20.Items.AddRange(itemsList);
      Item21.Items.AddRange(itemsList);
      Item22.Items.AddRange(itemsList);
      Item23.Items.AddRange(itemsList);
      Item24.Items.AddRange(itemsList);
    }

    public void populateBuild(Build build) {
      mCurrentBuild = build;
      Champion.SelectedItem = build.ChampionName;
      ItemSet.SelectedItem = build.ItemSet;
      RunePage.SelectedItem = build.RunePage;
      MasteryPage.SelectedItem = build.MasteryPage;
      StartAbilities.Text = build.StartAbilities;
      MaxOrder.Text = build.MaxOrder;
      Summoner1.SelectedItem = build.Summoner1;
      Summoner2.SelectedItem = build.Summoner2;
    }

    public void populateMasteryPage(MasteryPage masteryPage) {
      mCurrentMasteryPage = masteryPage;
      foreach (KeyValuePair<string, Button> a in mMasteryButtons) {
        a.Value.Text = masteryPage[a.Key];
      }
    }

    public void populateRunePage(RunePage runePage) {
      mCurrentRunePage = runePage;
      Mark1.SelectedItem = runePage.Mark1;
      Mark2.SelectedItem = runePage.Mark2;
      Mark3.SelectedItem = runePage.Mark3;
      Mark4.SelectedItem = runePage.Mark4;
      Mark5.SelectedItem = runePage.Mark5;
      Mark6.SelectedItem = runePage.Mark6;
      Mark7.SelectedItem = runePage.Mark7;
      Mark8.SelectedItem = runePage.Mark8;
      Mark9.SelectedItem = runePage.Mark9;
      Seal1.SelectedItem = runePage.Seal1;
      Seal2.SelectedItem = runePage.Seal2;
      Seal3.SelectedItem = runePage.Seal3;
      Seal4.SelectedItem = runePage.Seal4;
      Seal5.SelectedItem = runePage.Seal5;
      Seal6.SelectedItem = runePage.Seal6;
      Seal7.SelectedItem = runePage.Seal7;
      Seal8.SelectedItem = runePage.Seal8;
      Seal9.SelectedItem = runePage.Seal9;
      Glyph1.SelectedItem = runePage.Glyph1;
      Glyph2.SelectedItem = runePage.Glyph2;
      Glyph3.SelectedItem = runePage.Glyph3;
      Glyph4.SelectedItem = runePage.Glyph4;
      Glyph5.SelectedItem = runePage.Glyph5;
      Glyph6.SelectedItem = runePage.Glyph6;
      Glyph7.SelectedItem = runePage.Glyph7;
      Glyph8.SelectedItem = runePage.Glyph8;
      Glyph9.SelectedItem = runePage.Glyph9;
      Quint1.SelectedItem = runePage.Quint1;
      Quint2.SelectedItem = runePage.Quint2;
      Quint3.SelectedItem = runePage.Quint3;
    }

    public void populateItemSet(ItemSet itemSet) {
      mCurrentItemSet = itemSet;
      Item1.SelectedItem = itemSet.Item1;
      Item2.SelectedItem = itemSet.Item2;
      Item3.SelectedItem = itemSet.Item3;
      Item4.SelectedItem = itemSet.Item4;
      Item5.SelectedItem = itemSet.Item5;
      Item6.SelectedItem = itemSet.Item6;
      Item7.SelectedItem = itemSet.Item7;
      Item8.SelectedItem = itemSet.Item8;
      Item9.SelectedItem = itemSet.Item9;
      Item10.SelectedItem = itemSet.Item10;
      Item11.SelectedItem = itemSet.Item11;
      Item12.SelectedItem = itemSet.Item12;
      Item13.SelectedItem = itemSet.Item13;
      Item14.SelectedItem = itemSet.Item14;
      Item15.SelectedItem = itemSet.Item15;
      Item16.SelectedItem = itemSet.Item16;
      Item17.SelectedItem = itemSet.Item17;
      Item18.SelectedItem = itemSet.Item18;
      Item19.SelectedItem = itemSet.Item19;
      Item20.SelectedItem = itemSet.Item20;
      Item21.SelectedItem = itemSet.Item21;
      Item22.SelectedItem = itemSet.Item22;
      Item23.SelectedItem = itemSet.Item23;
      Item24.SelectedItem = itemSet.Item24;
    }

    public bool confirmNotLoseChanges(string message, string title) {
      return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No;
    }

    public void setSaveEnabled(bool enabled) {
      SaveMenuItem.Enabled = enabled;
    }

    public string askForSaveFilePath() {
      return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
    }

    public string askForOpenFilePath() {
      return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
    }

    public string askForName() {
      var nameDialog = new NameDialog();
      return nameDialog.ShowDialog() == DialogResult.OK ? nameDialog.ItemName : null;
    }

    public void addBuild(Build newBuild) {
      BuildName.Items.Add(newBuild.BuildName);
      checkBuildsCount(false);
    }

    public void addMasteryPage(MasteryPage newMasteryPage) {
      MasteryPage.Items.Add(newMasteryPage["name"]);
      MasteryPageName.Items.Add(newMasteryPage["name"]);
      checkMasteryPagesCount(false);
    }

    public void addRunePage(RunePage newRunePage) {
      RunePage.Items.Add(newRunePage.RunePageName);
      RunePageName.Items.Add(newRunePage.RunePageName);
      checkRunePagesCount(false);
    }

    public void addItemSet(ItemSet newItemSet) {
      ItemSet.Items.Add(newItemSet.ItemSetName);
      ItemSetName.Items.Add(newItemSet.ItemSetName);
      checkItemSetsCount(false);
    }

    public void updateBuildName(string name) {
      BuildName.Items.Remove(mCurrentBuild.BuildName);
      BuildName.Items.Add(name);
      BuildName.SelectedItem = name;
    }

    public void updateMasteryPageName(string name) {
      bool isSelected = (string)MasteryPage.SelectedItem == mCurrentMasteryPage["name"];
      MasteryPage.Items.Remove(mCurrentMasteryPage["name"]);
      MasteryPage.Items.Add(name);
      if (isSelected) {
        MasteryPage.SelectedItem = name;
      }
      MasteryPageName.Items.Remove(mCurrentMasteryPage["name"]);
      MasteryPageName.Items.Add(name);
      MasteryPageName.SelectedItem = name;
    }

    public void updateRunePageName(string name) {
      bool isSelected = (string)RunePage.SelectedItem == mCurrentRunePage.RunePageName;
      RunePage.Items.Remove(mCurrentRunePage.RunePageName);
      RunePage.Items.Add(name);
      if (isSelected) {
        RunePage.SelectedItem = name;
      }
      RunePageName.Items.Remove(mCurrentRunePage.RunePageName);
      RunePageName.Items.Add(name);
      RunePageName.SelectedItem = name;
    }

    public void updateItemSetName(string name) {
      bool isSelected = (string)ItemSet.SelectedItem == mCurrentItemSet.ItemSetName;
      ItemSet.Items.Remove(mCurrentItemSet.ItemSetName);
      ItemSet.Items.Add(name);
      if (isSelected) {
        ItemSet.SelectedItem = name;
      }
      ItemSetName.Items.Remove(mCurrentItemSet.ItemSetName);
      ItemSetName.Items.Add(name);
      ItemSetName.SelectedItem = name;
    }

    private void checkBuildsCount(bool selectFirst) {
      DeleteBuildButton.Enabled = BuildGroupBox.Enabled = BuildName.Items.Count != 0;
      if (BuildGroupBox.Enabled) {
        BuildName.SelectedIndex = selectFirst ? 0 : BuildName.Items.Count - 1;
      }
    }

    private void checkMasteryPagesCount(bool selectFirst) {
      DeleteMasteryPageButton.Enabled = MasteryPageGroupBox.Enabled = MasteryPageName.Items.Count != 0;
      if (MasteryPageGroupBox.Enabled) {
        MasteryPageName.SelectedIndex = selectFirst ? 0 : MasteryPageName.Items.Count - 1;
      }
    }

    private void checkRunePagesCount(bool selectFirst) {
      DeleteRunePageButton.Enabled = RunePageGroupBox.Enabled = RunePageName.Items.Count != 0;
      if (RunePageGroupBox.Enabled) {
        RunePageName.SelectedIndex = selectFirst ? 0 : RunePageName.Items.Count - 1;
      }
    }

    private void checkItemSetsCount(bool selectFirst) {
      DeleteItemSetButton.Enabled = ItemSetGroupBox.Enabled = ItemSetName.Items.Count != 0;
      if (ItemSetGroupBox.Enabled) {
        ItemSetName.SelectedIndex = selectFirst ? 0 : ItemSetName.Items.Count - 1;
      }
    }

    private void Builder_Load(object sender, EventArgs e) {
      try {
        mPresenter.start();
      } catch (Exception ex) {
        showErrorMessage(ex.Message);
        Close();
      }
    }

    private void HandleMasteryClick(Button clickedButton, Button partner1, Button partner2, int limit) {
      int clickedValue = int.Parse(clickedButton.Text);
      int partnerValue1 = int.Parse(partner1.Text);
      var partnerValue2 = 0;
      if (partner2 != null) {
        partnerValue2 = int.Parse(partner2.Text);
      }
      if (clickedValue == limit) {
        return;
      }

      ++clickedValue;
      if (clickedValue + partnerValue1 + partnerValue2 > limit) {
        if (partnerValue1 > 0) {
          --partnerValue1;
        } else {
          --partnerValue2;
        }
      }
      clickedButton.Text = clickedValue.ToString();
      partner1.Text = partnerValue1.ToString();
      if (partner2 != null) {
        partner2.Text = partnerValue2.ToString();
      }
    }

    private void Mastery1Button_Click(object sender, EventArgs e) {
      var mainBut = (Button)sender;
      Button partner1 = null;
      Button partner2 = null;
      Mastery mastery = ((MasteryPageBind)mainBut.Tag).mProp;
      if (mastery.Partners.Count > 0) {
        partner1 = mMasteryButtons[mastery.Partners[0]];
        if (mastery.Partners.Count > 1) {
          partner2 = mMasteryButtons[mastery.Partners[1]];
        }
      }
      HandleMasteryClick(mainBut, partner1, partner2, 1);
    }

    private void Mastery5Button_Click(object sender, EventArgs e) {
      var mainBut = (Button)sender;
      Button partner1 = null;
      Button partner2 = null;
      Mastery mastery = ((MasteryPageBind)mainBut.Tag).mProp;
      if (mastery.Partners.Count > 0) {
        partner1 = mMasteryButtons[mastery.Partners[0]];
        if (mastery.Partners.Count > 1) {
          partner2 = mMasteryButtons[mastery.Partners[1]];
        }
      }
      HandleMasteryClick(mainBut, partner1, partner2, 5);
    }

    private void MasteryButton_MouseUp(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        var clickedButton = (Button)sender;
        int clickedValue = int.Parse(clickedButton.Text);
        if (clickedValue == 0) {
          return;
        }

        --clickedValue;
        clickedButton.Text = clickedValue.ToString();
      }
    }

    private void BuildsNavigatorCopyItem_Click(object sender, EventArgs e) {
      mPresenter.onCopyBuild(mCurrentBuild);
    }

    private void MasteryPagesNavigatorCopyItem_Click(object sender, EventArgs e) {
      mPresenter.onCopyMasteryPage(mCurrentMasteryPage);
    }

    private void RunePagesNavigatorCopyItem_Click(object sender, EventArgs e) {
      mPresenter.onCopyRunePage(mCurrentRunePage);
    }

    private void ItemSetsNavigatorCopyItem_Click(object sender, EventArgs e) {
      mPresenter.onCopyItemSet(mCurrentItemSet);
    }

    private void AddBuildButton_Click(object sender, EventArgs e) {
      mPresenter.onAddBuild();
    }

    private void AddMasteryPageButton_Click(object sender, EventArgs e) {
      mPresenter.onAddMasteryPage();
    }

    private void AddRunePageButton_Click(object sender, EventArgs e) {
      mPresenter.onAddRunePage();
    }

    private void AddItemSetButton_Click(object sender, EventArgs e) {
      mPresenter.onAddItemSet();
    }

    private void DeleteBuildButton_Click(object sender, EventArgs e) {
      mPresenter.onDeleteBuild(mCurrentBuild);
      BuildName.Items.Remove(mCurrentBuild.BuildName);
      checkBuildsCount(true);
    }

    private void DeleteMasteryPageButton_Click(object sender, EventArgs e) {
      mPresenter.onDeleteMasteryPage(mCurrentMasteryPage);
      MasteryPage.Items.Remove(mCurrentMasteryPage["name"]);
      MasteryPageName.Items.Remove(mCurrentMasteryPage["name"]);
      checkMasteryPagesCount(true);
    }

    private void DeleteRunePageButton_Click(object sender, EventArgs e) {
      mPresenter.onDeleteRunePage(mCurrentRunePage);
      RunePage.Items.Remove(mCurrentRunePage.RunePageName);
      RunePageName.Items.Remove(mCurrentRunePage.RunePageName);
      checkRunePagesCount(true);
    }

    private void DeleteItemSetButton_Click(object sender, EventArgs e) {
      mPresenter.onDeleteItemSet(mCurrentItemSet);
      ItemSet.Items.Remove(mCurrentItemSet.ItemSetName);
      ItemSetName.Items.Remove(mCurrentItemSet.ItemSetName);
      checkItemSetsCount(true);
    }

    private void RenameBuildButton_Click(object sender, EventArgs e) {
      mPresenter.onRenameBuild(mCurrentBuild);
    }

    private void RenameMasteryPageButton_Click(object sender, EventArgs e) {
      mPresenter.onRenameMasteryPage(mCurrentMasteryPage);
    }

    private void RenameRunePageButton_Click(object sender, EventArgs e) {
      mPresenter.onRenameRunePage(mCurrentRunePage);
    }

    private void RenameItemSetButton_Click(object sender, EventArgs e) {
      mPresenter.onRenameItemSet(mCurrentItemSet);
    }

    private void BuildName_SelectedIndexChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        mPresenter.onSelectedBuildChanged((string)BuildName.SelectedItem);
      }
    }

    private void MasteryPageName_SelectedIndexChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        mPresenter.onSelectedMasteryPageChanged((string)MasteryPageName.SelectedItem);
      }
    }

    private void RunePageName_SelectedIndexChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        mPresenter.onSelectedRunePageChanged((string)RunePageName.SelectedItem);
      }
    }

    private void ItemSetName_SelectedIndexChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        mPresenter.onSelectedItemSetChanged((string)ItemSetName.SelectedItem);
      }
    }

    private void SaveMenuItem_Click(object sender, EventArgs e) {
      mPresenter.onSaveFileClicked(false);
    }

    private void NewMenuItem_Click(object sender, EventArgs e) {
      mPresenter.onNewFileClicked();
    }

    private void SaveAsMenuItem_Click(object sender, EventArgs e) {
      mPresenter.onSaveFileClicked(true);
    }

    private void OpenMenuItem_Click(object sender, EventArgs e) {
      mPresenter.onOpenFileClicked();
    }

    private void Builder_FormClosing(object sender, FormClosingEventArgs e) {
      if (mPresenter.shouldCancelFormClosing()) {
        e.Cancel = true;
      }
    }

    private void BuildChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        var control = (Control)sender;
        var bind = (BuildBind)control.Tag;
        bind.updateProperty(mCurrentBuild, control);
        mPresenter.onBuildChanged();
      }
    }

    private void MasteryPageChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        var control = (Control)sender;
        var bind = (MasteryPageBind)control.Tag;
        bind.updateProperty(mCurrentMasteryPage, control);
        mPresenter.onMasteryPageChanged();
      }
    }

    private void RunePageChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        var control = (Control)sender;
        var bind = (RunePageBind)control.Tag;
        bind.updateProperty(mCurrentRunePage, control);
        mPresenter.onRunePageChanged();
      }
    }

    private void ItemSetChanged(object sender, EventArgs e) {
      if (!shouldPauseBinding) {
        var control = (Control)sender;
        var bind = (ItemSetBind)control.Tag;
        bind.updateProperty(mCurrentItemSet, control);
        mPresenter.onItemSetChanged();
      }
    }
  }
}
