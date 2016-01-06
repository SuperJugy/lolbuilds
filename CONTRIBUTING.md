Contributing
============

Thanks
------

Thanks for contributing to the project! This doc will guide you on to how to contribute to the project so the evolution goes faster and smooth.

Setup
-----

After cloning correctly our repo, to be able to run this project, you will need Visual Studio 2010 with .Net 4.0 and The Nugget Package Manager.

This should be enough to run the project but in order for the program to work, it will need acces to the Riot API. This is achieved with a API Key so you will need to sign up for one and save it in the settings.

Style Guide-lines
-----------------

TODO. Just try to follow the style already present.

Submitting PRs
--------------

After you have made the changes following the style guidelines and testing correctly, you can commit your changes in git. Preferably, squash all the commits into one commit if you have made previous commits, unless the changes were big enough or require more organization in which case you can use more than one commit. Just try to keep the commits as an coherent set of changes.

Please don't submit things like:

- Fixed issue 43
- Fixed typo
- Fixed styles
- Fixed issue 43 (again)
- Fixed failing tests after fixing issue 43

Finally, push your commits to your fork and submit a PR for review. If after the submittion the team suggests more changes, this changes should be also squashed to the previous commits and force pushed to the same branch. Github is intelligent enough to understand that anything under the branch selected during the creation of the PR is considered as what is being submitted, so you don't need to close the PR and make a new one, just squash and force push. If it is a work in progress, you can push several commits until the work is done and reviewed by the team and then, just before merging, squash into coherent commits.

Thanks again and happy coding!
