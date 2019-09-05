# Day 4

First method, with StringBuilder: 2199ms
Second method, without StringBuilder: 2106ms

So I managed to think through a way to simplify it, although it didn't speed up much. I don't know how much of the time on this thing is the tests though, and how much is my code. That's impossible to know unless I come up with other ways to do this. 

I'm really trying hard to think it through without submitting. But I'm just not seeing another way -- I need to split it out into words, then I need to build new words based on whether or not the first character of the word is a letter, then join it all back together. StringBuilder was my first instinct because string "addition" feels icky. But the less icky method definitely cost me in time, which is good to know.

The question is what other way is there? I'm sure there's a stupid simple one liner I'm not thinking of... shall we find out?

Sure enough... one line.

```c#
using System.Linq;
public class Kata
{
    public static string PigIt(string str)
    {
        return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
    }
}
```

This one definitely has a lot less logic in it though. Nothing to handle punctuation, which is called out in the description and then just lacking in the tests. So I suppose that's an argument for TDD -- if there's not a test for it, it's not a requirement? 

Either way, I kinda feel like my solution is more robust, given that punctuation was in the description. Ah well.

At least it didn't take me two hours today. Now I'm gonna go watch Unity videos for a while.