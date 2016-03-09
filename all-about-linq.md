## useful tip
`OfType` can be used to filter specific type of value.
``` cs
object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0,"" };
var doubles = numbers.OfType<string>();
```
