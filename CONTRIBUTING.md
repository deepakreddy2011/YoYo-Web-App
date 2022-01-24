# Contribution Guidelines

Please note that this project is released with a [Contributor Code of Conduct](CODE_OF_CONDUCT.md). By participating in this project you agree to abide by its terms. Please also review our [Contributor License Agreement ("CLA")](INDIVIDUAL_CONTRIBUTOR_LICENSE.md) prior to submitting changes to the project.  You will need to attest to this agreement following the instructions in the [Paperwork for Pull Requests](#paperwork-for-pull-requests) section below.

---

# How to Contribute

Now that we have the disclaimer out of the way, let's get into how you can be a part of our project. There are many different ways to contribute. One way is to put in an issue. Another would be to clone this repo, branch it and make the change yourself which you can add via PR. More info on how to do that is below.

## Issues

We track our work using Issues in GitHub. Feel free to open up your own issue to point out areas for improvement or to suggest your own new experiment. If you are comfortable with signing the waiver linked above and contributing code or documentation, grab your own issue and start working.

## Coding Standards

We have some general guidelines towards contributing to this project.

### Languages

SVG
JavaScript
TypeScript


## Adding an Icon
 
   ####  Background information
   The utility icons in this package are chosen by the Orion design team. Most icons come from the Material Design set, in the round style. When we add new SVGs,      we copy the files from Material (this is because the design tool that the designers use, Figma, eliminates the viewBox information for the icons).



   The most straight forward way to add an icon is to do the following:

1. First, clone this repository, then create a branch for your work
2. Get the list of new icons from the design team, or from the design documents in Figma. Make sure to only include icons that are meant for web. Exclude icons that are only meant for native apps.
3. For each Material icon, copy the SVG file from the Material Design icons repo into the @optum/orion-icons SVG folder. Make sure to copy the correct style, which is usually round. The Material icons are available here: https://github.com/google/material-design-icons/tree/master/src
4. For non-Material icons, make sure the SVG path is centered within a 24x24 viewBox.
5. Consider using a tool like svgo to optimize the SVG shapes.
6. The SVGs should have this format:

    ```
    <svg xmlns="http://www.w3.org/2000/svg" height="24" width="24" viewBox="0 0 24 24">
     <path d="..." />
    </svg>
    ```
    
    - The SVG should have width, height, viewBox, and xmlns attributes and values shown.
    - The SVG code should be a small number of shapes, preferably a single path element. There should be no unnecessary elements.
    - The elements should not have any extra attributes like fill, style, or id.
    - Consider hand-editing the SVG code to make sure each file is consistent.
		
7. Next, run the "generate components" script (`npm run generate-components-for-svgs`) at the root of the orion-icons projects to generate the  [React](https://reactjs.org/) and [Angular](https://angular.io/docs) components from the SVGs.
8. cd into the src of the react icon library (orion-icons/src/components/utility-icons-react/src) in the index.tsx file, import the component that corresponds with the name of your svg
9. Also, add it as an export to the index.ts file. Once this is done, it will make it so that all versions of your icon are available to consumers of the library when it's merged and deployed.

## Testing/viewing Your Icon
To view your icon it this projects test app, do the following.

* cd into the src of the test project called "example" (orion-icons/src/components/utility-icons-react/example/src)
* Open the App.tsx file, import your component into it and add it to the table.
* Note: if you are trying to view icons from the standard svg library, you will need to link the npm package to the example app before importing it. Info on how to do this can be found here: https://docs.npmjs.com/cli/v8/commands/npm-link
* In a new window, cd into the svgs folder (orion-icons/src/svgs)
* In a another window, cd into the base react component library (orion-icons/src/components/utility-icons-react/) run `npm install` and `npm start`
* cd back out into the base of the example app in the other window (orion-icons/src/components/utility-icons-react/example/) link the orion-icons-svgs by running  the command `npm link @optum/orion-icons-svgs` and run `npm start` there as well and a window should pop open in your browser with your icon in the page

## Pull Requests

If you've gotten as far as reading this section, then thank you for your suggestions.

## Paperwork for Pull Requests

* Please read this guide and make sure you agree with our [Contributor License Agreement ("CLA")](INDIVIDUAL_CONTRIBUTOR_LICENSE.md).
* Make sure git knows your name and email address:
   ```
   $ git config user.name "J. Random User"
   $ git config user.email "j.random.user@example.com"
   ```
>The name and email address must be valid as we cannot accept anonymous contributions.
* Write good commit messages.
> Concise commit messages that describe your changes help us better understand your contributions.
* The first time you open a pull request in this repository, you will see a comment on your PR with a link that will allow you to sign our Contributor License Agreement (CLA) if necessary.
> The link will take you to a page that allows you to view our CLA.  You will need to click the `Sign in with GitHub to agree button` and authorize the cla-assistant application to access the email addresses associated with your GitHub account.  Agreeing to the CLA is also considered to be an attestation that you either wrote or have the rights to contribute the code.  All committers to the PR branch will be required to sign the CLA, but you will only need to sign once.  This CLA applies to all repositories in the Optum org.

## General Guidelines

Ensure your pull request (PR) adheres to the following guidelines:

* Try to make the name concise and descriptive.
* Give a good description of the change being made. Since this is very subjective, see the [Updating Your Pull Request (PR)](#updating-your-pull-request-pr) section below for further details.
* Every pull request should be associated with one or more issues. If no issue exists yet, please create your own.
* Make sure that all applicable issues are mentioned somewhere in the PR description. This can be done by typing # to bring up a list of issues.

### Updating Your Pull Request (PR)

A lot of times, making a PR adhere to the standards above can be difficult. If the maintainers notice anything that we'd like changed, we'll ask you to edit your PR before we merge it. This applies to both the content documented in the PR and the changed contained within the branch being merged. There's no need to open a new PR. Just edit the existing one.

[email]: mailto:opensource@optum.com
