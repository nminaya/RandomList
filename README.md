# RandomList
RandomList it's basically a Collection of items that can be iterated randomly.

Use:

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
