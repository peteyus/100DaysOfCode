#Day 2

I'm almost afraid to submit this one.

I got the answer. On the first try. But man is it ugly. Part of me wants to refactor before I submit. Part of me just wants to be done already with this today.

Game stuff feels like an area where I'm missing the most. Was there a better way to conceptualize this than just looping through the board, tracking a bunch of bools that will break as soon as the game adds more than one boat?

Should I be factoring for a full game, or just the simple case presented in the kata?

I suppose it doesn't matter. As far as codewars is concerned, I got the answer and I'm done. I suppose what matters is what I want to get out of it... I'd like a better solution. But I want to be done. So I'm gonna be done and call my hacky-but-works solution enough for today. And be proud that I understood the problem well enough to get it on my first try. Including the messed-up x/y values.

Comparing the top solution with mine, so I learn something from this:

```c#
using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWars
{
    class Kata
    {
        public static Dictionary<string,double> damagedOrSunk(int[,] board, int[,] attacks)
        {
           var result = new Dictionary<string, double>();
          
           var boardBefore = board.Cast<int>().Where(x => x != 0)
            .GroupBy(x=>x)
            .ToDictionary(gr => gr.Key, gr =>gr.Count());

          // Apply attacks
            for( var i = 0; i < attacks.GetLength(0); i++)
                board[board.GetLength(0) - attacks[i,1], attacks[i,0] -1] = 0;
        
            var boardAfter = board.Cast<int>().Where(x => x != 0)
              .GroupBy(x=>x)
              .ToDictionary(gr => gr.Key, gr =>gr.Count());
            
            result["sunk"] = boardBefore.Keys.Count - boardAfter.Keys.Count;
            result["notTouched"] = boardAfter.Count(x => x.Value == boardBefore[x.Key]);

            result["damaged"] = boardBefore.Keys.Count - result["sunk"] - result["notTouched"];
            result["points"] = result["sunk"] + 0.5 * result["damaged"] - 1 * result["notTouched"];

            return result;
        }
    }
}
```

First, he converts the board from a multidimensional array to an enumerable of ints. Which is SO much easier to think about. This is a good trick to remember.

Then he groups those ints and gets a count of which numbers are present -- this solution won't break with more ships. 55 ships? Cool, that's just one more key in the dictionary, with a count of how many pieces are in that ship.

Next he does the same transform I did, just in one step instead of a messy foreach loop. And he changes the incoming board[,] parameter.

He repeats the dictionary trick to get an "after" picture. Then he calculates the four variables. Sunk is easy -- any keys that don't appear in the "After" dictionary were totally sunk. Undamaged is the keys where the "after" dictionary has the same count as the before dictionary. And the hit ones are all the keys minus the undamaged and sunk ones. Then just add up the results like I did to get the score.

I will say that his takes some mental gymnastics to understand. And I get that brevity isn't always the best code -- because when I first looked at this I had no idea how it was doing it until I walked through line by line. My code at least is readable.

That's my story and I'm sticking to it.