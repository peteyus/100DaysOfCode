# Day 9

Few things make me want to say "nope" faster than geometry. And yet here we are.

I think what's most frustrating is there are people commenting "Oh, so easy" and "this should be a 7kyu". Then why the hell is it a 4, and what am I not seeing?

I can, of course, reveal the answer. But that's not going to solve anything for me.

I've tried looking up the theory. I found out the math for calculating the new points after rotation (thanks wikipedia!). So then what? The comments all say the brute-force approach ("is this point in the polygon") won't work. Which makes sense, I need to find a more efficient way. But I don't even know where to begin on this.

Yeah. I think this might a "forget it, let's just see what I can learn from the solutions" kind of night. Because I have no freakin' idea. Even after looking at solutions to similar problems. I'm like, "Oh, this might work! Only... it depends on calculating based on int points and I *know* that I can't count on my corners being on ints.

So yeah. I'm definitely missing something foundational here. And the comments on it make me feel really resentful. "Oh so easy." You know buddy... bite me. Easy if you happen to have a background in this kind of problem.

Survey says:

```c#
  public class Kata
  {
    public int RectangleRotation(int a, int b)
    {
      var alpha = new Factors(a);
      var beta = new Factors(b);
      return alpha.Even * beta.Even + alpha.Odd * beta.Odd;
    }

    public class Factors
    {
      public int Odd { get; private set; }
      public int Even { get; private set; }

      public Factors(int value)
      {
        var result = (int)(value/Math.Sqrt(2.0));
        Even = (result % 2 == 0) ? result : result + 1;
        Odd = (result % 2 == 0) ? result + 1 : result;
      }
    }
  }
```

Huh? WTF does the square root of 2 have to do with this?

Yup. Dunno. This one's going on slack. Hopefully I can at least learn from today.