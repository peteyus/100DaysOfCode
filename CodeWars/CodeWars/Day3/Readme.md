# Day 3
What the actual hell? I feel like this one was way harder than it should have been.

Obviously I need to spend some time learning pattern matching or something. I just could not see a way to solve it, and then the top solution is like five lines long.

Shit, there's even one that does it in one line!?!

```c#
        public static string WhatIsTheTime(string timeInMirror)
        {
                return DateTime.Parse("12:00").Subtract(TimeSpan.Parse(timeInMirror)).ToString("hh:mm");
        }
```

Like... what is that? 12:00 - the time? That is so blindingly obvious in retrospect, and frustrating that I've got half a page of scribbles that I overlooked that. Like how does that even work? 

The imposter syndrome is strong today. I don't even want to push this branch, I'm so annoyed at the solution. But I will. Because I should. And because future me will want to be able to look back on this and see, "Hahaha, ridiculous simpleton old me coulnd't even picture a clock." 

That's my story and I'm sticking to it. Some day I'll feel like I'm good at what I do.
