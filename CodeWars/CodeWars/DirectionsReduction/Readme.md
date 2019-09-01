# Day 1

So I got day one done. And, as usual with code katas, I look at the public solutions after I get mine done, and start to feel imposter syndrome rearing its head. I know that I'm good at my job, but I am missing so many fundamental concepts in software engineering that I overlook faster/more elegant solutions for ones that are conceptually simple. It's always `list<string>` or `dictionary<int, string>` when maybe what I need is a `stack` or a `queue`, or I don't even need a structure I can just use some sort of low level magic and boom there's the answer.

Of course, I know that's not realistic. And the whole reason that 100 days of code was on my list was to find a project that's not a WPF application where I can get away with those simpler structures and code katas are a good start. They won't all be like this though.

My solution uses nested loops, which are confusing to read and hard to follow the logic. By far the cleanest solution I saw online was this:

```c#
using System;
using System.Collections.Generic;

public class DirReduction {
    public static String[] dirReduc(String[] arr) {
        Stack<String> stack = new Stack<String>();

        foreach (String direction in arr) {
            String lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;

            switch(direction) {
                case "NORTH": if ("SOUTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                case "SOUTH": if ("NORTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                case "EAST":  if ("WEST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                case "WEST":  if ("EAST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
            }
        }
        String[] result = stack.ToArray();        
        Array.Reverse(result);
        
        return result;               
    }
}
```

So what does his solution do that mine doesn't? Using the inherent nature of a stack, he just calls `stack.Peek()` to see the next value, and if the value after it is the opposite of the current one, he calls `stack.Pop()` to clear it off. If not, then he pushes the current direction to the stack and continues his foreach. When he's done, he's either `Pop`ped every matching pair off the stack, or he's left with directions that aren't immediately contradictory. Nice and simple.

My first solution to this one (forgot to commit before "fixing" it) was very similar to my end result, only it reduced ALL matching pairs out of the directions. So the first test passed, but only by luck. Really, I think mine is the "better" solution for the problem as given, since going NORTH EAST SOUTH WEST is a lovely circle, and the whole BS in the story about trying to preserve water... but I also didn't finish reading because I thought I understood and I clearly didn't. 

C'est la vie... we fail, so we learn, so that we don't fail to learn.

Are these readme's the best place to record my thoughts?