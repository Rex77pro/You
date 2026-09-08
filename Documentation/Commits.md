# Commits

This is a short guide how to add pending changes into the project

## Branching
 A branch should contain 3 requirements > ***type, issue and title***, shown as below: 
 
 `feat/#00-migrations`

 In order to keep a clean an readable commit history. 

## Commiting
This project has **"Commitlint"** installed, which is a tool for writing simple and consistent messages when committing. 

For writing a commit message, write: `pnpm cz` in the terminal. This opens a dialouge, which is needed, for commiting any changes. 

Afterwards a dotnet test and build be executed.

## Pushing

Pushing for the first time requires the repository to have an set-upstream. This is done by pushing with: `git push -u origin HEAD` 

Every push afterwards on the ongoing branch would be pushed by: `git push`

