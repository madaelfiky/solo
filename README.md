# Table Of Contents
* [Introduction](#introduction)
* [Prerquistes](#prerquistes) 
* [Getting Started](#getting-started)
* [Project Stucture](#projecct-structure)
* [Writing Tests](#writing-tests)
* [Author(s)/Maintainer(s)](#authors-maintainers)

# Introduction 
This is an automation frameworkk for testing Dafater Application by using Page Object Model Battern

# Prerquistes
I assume you don't have any development tools instlled. So  make sure you have everything that listed installed.
  - [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/)
  - [SpecFlow Extension](https://specflow.org/)<br>
  		- Extensions menue > Manage Extensions > Search for SpecFlow

# Getting Started
Clone this project to your machine to start work. after cloning is done open the project in Microsoft Visual Studio

# Project Stucture
```markdown
.
├── .gitignore								// all files needs to be ignored from git commit
├──Dafater.BDD.Tests						// Our Test Project
	├── Constants
		├── Configuration
		├── Form
		├── Users
	├── Fetures
	├── Hooks
		├── GlobalHooks.cs
		├── ScenarioHooks.cs
		├── TestState
	├── Resources
		├── Data
		├── Settings
	├── Selenium
		├── Driver
		├── Locators
		├── Pages
	├── Steps
		├── *StepDef.cs
	├── Utilities
		├── CsvHelpe.cs
		├── DataUtil.cs
	├── Default.srprofile
	├── README.md
```
# Writing Tests
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)