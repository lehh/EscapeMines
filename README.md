# Escape Mines

Console game application which reads from a file, set their written configuration and execute their written commands. It will output the result of each sequence of commands.  

Made with .NET Core v3.1

## File Format

The file must be in the EscapeMines **root directory** as **game.txt**

**First line**: board size (row, column) in tiles separated by space.
**Second line**: list of zero based mines locations (row, column) separated by space. Each row/column pair separated by comma.
**Third line**: zero based exit location (row, column) separated by space.
**Fourth line**: zero based turtle position (row, column, direction) separated by space. Direction can be N, S, E or W.
**Fifth line and greater**: sequence of commands to be executed. These commands can be M, R or L. M as move, R as rotate to the right and L as rotate to the left.

**Example**:

    4 5
    1,1 1,3 3,3
    2 4
    1 0 N
    L L M L M M M M
    R R M M L M M

## Tests

To run the unit tests, just run the following command in the console: 

    dotnet test EscapeMines.Tests

To run the integrations tests, just run the following command in the console:

    dotnet test EscapeMines.IntegrationTests

### Code Coverage
The unit tests coverage report files are into the EscapeMines.Tests\TestResults folder.