# Day 6

So today's was a bit of a snoozer. At first it SOUNDS complex, but then it's just... oh. I'm a little surprised that this was considered the level it is.

My solution was to count the number of zeros, append them at the end of an array that was created by selecting non-zero answers from the one provided.

It wasn't quite as elegant as my favorite answer:

```c#
using System.Linq;
public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
     return arr.OrderBy(x => x==0).ToArray();
  }
}
```

At first I thought about trying to order the array using linq, but I couldn't see how to do it without reordering the other elements. So this is clever in that it works by just saying "put everything that doesn't equal zero in one part". I think I'll need to read up on `OrderBy`, since I would have expected things where the criteria was true to be sorted first.

Here's a more slimmed down version of my solution:

```c#
using System.Linq;
public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
    return arr.Where(x=>x!=0).Concat(arr.Where(x=>x==0)).ToArray();
  }
}
```

They use `.Where` the exact same way that I did, but I didn't think about `Concat` to get the zeroes back in. I'm sure it's more performant than my solution, but I'm mostly just glad that this didn't take me hours today. So I don't care if my solution isn't the fastest.