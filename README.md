# PokerShowDown #

## PreRequisites
This application requires .NET Core 2.2 or higher

## Installation

### Clone
- Clone this repo to your local machine using `https://github.com/mikeberezowski/PokerShowDown.git`

From the root directory navigate to PokerApp\PokerConsoleApp

```shell
$ cd PokerApp\PokerConsoleApp
$ dotnet run
```

## Features
The current implementation only accepts a single Showdown in a text file.  
The current implementation handles a single Showdown with up to 10 players.  
Only the following Poker hands are calculated:  
Flush  
Three of a kind  
One Pair  
High Card  

## Usage
If you don't provide an input file a test file will be used (AppData\testData.txt)  

There is a windows batch file which will run several test files. From the application directory run runtests.bat  
```shell
$ .\runtests.bat
```
You can provide an input file in a .txt format  
```shell
$ dotnet run input.txt
```  
The file data is in two lines:  
\<Player Name\>  
\<Player Hand\>  

Where \<Player Name\> is a string denoting the player's name
and \<Player Hand\> is a comma separated list of the cards in the following format:  
8S, 4D, 9H, 10C  
Where the first digits represent the card value: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
The last digit is a single character representing the suit:  
H = **Hearts**  
D = **Diamonds**  
C = **Clubs**  
S = **Spades**  

Example:  
PlayerOne  
4D, 5D, 4C, 4S, JD  

## Documentation
Please see the documentation found in the [/Documentation](https://github.com/mikeberezowski/PokerShowDown/tree/master/Documentation) folder within the repository
