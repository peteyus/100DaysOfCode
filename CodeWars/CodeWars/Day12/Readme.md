# Day 12 and 13

So today was a two-parter. After getting almost all the logic and then getting stuck on diagonal matches, I called it a night yesterday at nearly two hours. Today I got a solution, and it worked, and I don't much care about anything else.

I proabbly should. But ya know. I don't know why I'm so irritable but that's not really what this post is about. I wrote code, I learned a thing, yay!

Doing this at bedtime is apparently not working, I just don't know when else to fit it in.

I originally imagined my solution to be a lot more elegant but as it dragged on I stopped caring. I really feel like I'm missing some background here in understanding how to think of things more simply.

```c#
  class Connect4
  {
    private List<List<int>> b = new int[7][].Select(t => new int[6].ToList()).ToList();
    private string[] wC = { "0", "1111", "2222"};
    private bool gOver = false;
    private int turn = 1;
    
    public string play(int c)
    { 
      if (gOver)             return "Game has finished!";
      if (b[c].Last() != 0)  return "Column full!";
      
      var r = b[c].IndexOf(0);
      b[c][r] = turn;
      gOver = won(c, r);
      turn = ~turn & 3;
      return gOver ? "Player "+ b[c][r] +" wins!" : "Player "+ b[c][r] +" has a turn";  
    }
    
    private bool won(int c, int r)
    {
      var winToCheck = new List<IEnumerable<int>> {
        b[c].Select(cl =>       cl),                                    // col
        b.SelectMany(cl =>      cl.Where((x,iR) => iR == r)),           // row
        b.SelectMany((cl,iC) => cl.Where((x,iR) => iR-r == iC-c)),      // Diag down
        b.SelectMany((cl,iC) => cl.Where((x,iR) => r-iR == iC-c)) };    // Diag up
      return winToCheck.Any(x => string.Concat(x).Contains(wC[turn]));
    }
  }
```

This one is a lot more like what I pictured in my head -- I went with `List<List<int>>` so that I could use fancy Linq statements and then my brain just wasn't seeing it. I had intended to come back and make mine prettier, but by the time it was working I just didn't care.

First is to create the game board. On play, if game over is true return that, if the "last" value in the column isn't 0 then return column full, otherwise store the current player.

Then we check to see if they won, if not then we set the other player (which is a really interesting trick -- bitwise complement operator (~) and then bitwise & to 3. I need to think through this one some more.)

Checking to see if they one is a fancy Linq statement like I was thinking, and the whole reason I went with `List<List<int>>`. He dumps the board into four strings, first the column played in, then the row played in, then diagonals. There's more fancy pants math I need to look into for that. Probably in the debugger, because it doesn't make much sense to me looking at it. Too much going on to reason through the variables.

But it's fancy. And I can claim to think "Hey, that was what I inteded." But since I got frustrated and gave up, we'll never know what mine could have looked like, other than how it does.