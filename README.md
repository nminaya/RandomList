[![NuGet version](https://lut.im/OEI5WbSXAz/dLdWUBIxQy8JPbCq.svg)](https://www.nuget.org/packages/RandomList.Core/)

# RandomList
RandomList it's basically a Collection of items that can be iterated randomly.

## Use:

```csharp
   // Creating a RandomList of string 
   var randomList = new RandomList<string>();

   // Adding items
   randomList.Add("First");
   randomList.Add("Second");
   randomList.Add("Third");
```
Then, when the collection is iterated:

![example](https://lut.im/xFNQPeDzgB/V3RbzPwjKCv0KEp1.png)

The elements are not in the same order in wich they were added. That's because RandomList randomizes the order of the elements.

## Installation:

It is available on Nuget. To install via Package Manager Console:

```Jekyll
PM> Install-Package RandomList.Core
```

Or browsing "RandomList" through NuGet VS VSIX.

## Features:
### Randomize method:

Having a RandomList, you can randomize the order of the elements again.

```csharp
var randomList = new RandomList<int>{ 1, 2, 3, 4};

// actual order of elements: 2, 1, 4, 3

//Randomizing
randomList.Randomize();

// new order of elements: 3, 1, 2, 4
```

### GetItemRandomly method:
Having a RandomList, you can get an element randomly.

```csharp
var randomList = new RandomList<int>{ 1, 2, 3, 4};

// Getting an item 
int item = randomList.GetItemRandomly();
```
