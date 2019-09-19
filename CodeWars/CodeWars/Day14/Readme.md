# Day 14

I think I'm done with katas. They mostly depend on knowing some obscure trick or being a math major -- things I could have done maybe 10 years ago when I was fresh out of school, but now trying to recall the math facts and patterns and connections through the fog of a decade of full-time work... it just leaves me frustrated.

So I'm calling it. I got a brute-force solution, and let's see what the "real" answer is:

```c#
 public static string solEquaStr(long n) {
    List<string> results = new List<string>(); // List of results
    
    long sqrtn = (long)Math.Ceiling(Math.Sqrt(n));
    
    // x^2 - 4y^2 = (x - 2y)(x + 2y).
    // Thus we can find all solutions to x^2 - 4y^2 = n
    // by finding all pairs (i, j) s.t. ij = n and i - j is a multiple of 4.
    //
    // To make sure we only find each factor pair once, only search for the smaller 
    // factor of the pair (i.e. search for factors in [1, sqrt(n)].
    // 
    // i + n/i has a single minimum at sqrt(n), so searching in ascending i-order
    // will return the results in descending x-order.
    for (long i = 1; i <= sqrtn; i++)
    {
      if (n % i == 0)
      {
        long j = n / i; // The other factor
        if ((j - i) % 4 == 0)
        {
          long x = (j + i) / 2;
          long y = (j - i) / 4;
          results.Add("[" + x.ToString() + ", " + y.ToString() + "]");
        }
      }
    }
    
    return "[" + string.Join(", ", results) + "]";
  }
```

They start with the square root of n. The base assumption doesn't make any sense to me though -- and is all math. Solutions are all pairs of numbers where multiplied they equal n and i-j is a multiple of 4? 

I'm sure I could work out the math. The code is nothing fancy, just based off that assumption. The retrun is identical to what I did, so yay for thinking to use a `string.Join`! The rest of it... eh. Obviously I'm just missing something foundational. Which is a repeating theme. So I'm going to drop this and go watch a pluralsight on Unity instead.