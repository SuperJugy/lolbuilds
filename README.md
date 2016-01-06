LoL Builds
==========
An application to manage your League of Legends Builds.

Usage
-----
The program is divided in 4 modules: DB Updater, Build Editor, Build Browser and Build Calculator.

1.  The DB updater connects to the Riot API servers and downloads the information required for the program to work. This module will be disabled until you register in the settings your API Key. If you don't have an API KEy you can register for one at Riot's API website. You just need to execute this module once every time there is a patch. Keep in mind that it can take a time to download all the information. If the application freezes, don't panic, it means it is working.
2.  The Build Editor helps you manage your builds and save them in files. This module will be disabled until the Data base files are downloaded. This module has 4 parts:
    1.  Builds: In this page you create your builds themselves. A build consists of a Champion, an Item Set, a Mastery Page, a Rune Page, the starting abilities and the maxing order of abilities.
      1.  The Champion is a simple dropdown to select the champion the build is for.
      2.  The Item Set is a drop down that will be filled with the Item Set Names that you register in the Item Sets Tab. Select the Item Set for the build.
      3.  The Mastery Page is a drop down that will be filled with the Mastery Page Names that you register in the Mastery Pages Tab. Select the Mastery Page for the build.
      4.  The Rune Page is a drop down that will be filled with the Rune Page Names that you register in the Rune Pages Tab. Select the Rune Page for the build.
      5.  The Starting Abilities is a text box where you can type which abilities to start with. For example "Q -> E -> E -> W".
      6.  The Max Order is a text box where you can type the order to max the abilities in. For example "R -> E -> Q -> W".
    2.  Mastery Pages: This page helps you manage you Mastery Pages similar to what you would have in the LoL client.
    3.  Rune Pages: This page helps you manage you Rune Pages by having all 30 slots as drop downs divided in the 4 categories.
    4.  Item Set: This page helps you manage you Item Sets by having 4 slots in 6 categories: start, early gae¡me, mid game, late game, situational and consumables.
    5.  You can save and open files by clicking the File menu and selecting the right option.
3.  The Build Browser will be able to display your build files in a more eye friendly way so you can use them while you play. It should be intuitive enough to use.
4.  The Calculator is a work in progress for the moment.

Requirements to Compile Yourself
--------------------------------
- Visual Studio 2010.
- .Net 4 Framework.
- Nugget Package Manager.

Requirements to Just Use
------------------------
- .Net 4 Framework.
- Riot API Key and Internet (Just to update the database files).
