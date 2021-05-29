# ProseMath
A .NET project that uses the PROSE SDK to generate programs for mathematical expressions using input output examples.

Microsoft PROSE is a framework of technologies for programming by examples: automatic generation of programs from input-output examples.

Given a domain-specific language (DSL) and input-output examples for the desired program’s behavior, PROSE synthesizes a ranked set of DSL programs that are consistent with the examples.

You can find the PROSE repository which contains examples on using existing PROSE DSL API's and examples for creating program synthesis by authoring DSL here - 
[https://microsoft.github.io/prose/](https://microsoft.github.io/prose/)

## Setup (Linux)


1.  Install .NET Core SDK (preferably version 2.1) from : https://www.microsoft.com/net/download/linux

1.  Install VS Code extension for C# : https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp

1. Clone this repository:

    ```
    git clone https://github.com/phanindra-R/ProseMath.git
    cd ProseMath
    ```
    
1. Open this folder in VS Code and using Termianal (Ctrl+`) run:

    ```
    dotnet build
    ```
    
   you should get the following message:
    ```
    Build succeeded.
    0 Warning(s)
    0 Error(s)
    ```

## Run (VS code)

1. Run the Application:

    ```
    dotnet run
    ```
1. Select 1 for the following prompt:

    ```
    Select one of the options: 
            1 - provide new example, 
            2 - run top synthesized program on a new input, 
            3 - exit
    ```
1. Enter the input in correct format:

    ```
    "[1,2,3,4]","7"
    ```
1. For the above Example The Top 4 synthesised programs should be: 

    ```
    Top 4 learned programs:
    ==========================
    Program 1: 
    Sum(v, ElementAt(v, 2), ElementAt(v, 3))
    ==========================
    Program 2: 
    Sum(v, ElementAt(v, 2), Sum(v, ElementAt(v, 0), ElementAt(v, 2)))
    ==========================
    Program 3: 
    Sum(v, ElementAt(v, 2), Sum(v, ElementAt(v, 0), Sum(v, ElementAt(v, 0), ElementAt(v, 1))))
    ==========================
    Program 4: 
    Sum(v, ElementAt(v, 2), Sum(v, ElementAt(v, 0), Sum(v, ElementAt(v, 0), Mul(v, ElementAt(v, 0), ElementAt(v, 1)))))
    ```
    
1. Note that the root node for the AST can be any operation (Sum | Mul | Div) not just Sum. And the Maximum reccursive depth is limited to avoid overflow (you can change this in ProseMath.grammar file).

1. You can play with different input and verify the generated output programs. You can also change the no. of top programs to print (4 here) in the program.cs file.
