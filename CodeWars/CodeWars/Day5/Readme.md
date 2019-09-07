# Day 5

Attempt 1 works just fine for the samples, but times out on the final tests. WTF, damnit I even used a queue! That was my first thought, too!

Clearly they've got some ridiculous number of iterations involved. Like, seriously ridiculous. I'm getting 200,000,000 iterations in just over 5 seconds. At 1 billion, I hit an out of memory error.

I guess it's time to look for a mathematical solution?

Yeah, forget that. That was more than an hour of trying to see the stupid pattern. I feel like I'm clearly missing something mathematical. Looking through the discsusions, someone gave a hint about looking at how dubling and sums works, and while I thought I was onto something for a minute (maybe I should scan in my notes? Not that it would mean anything to anyone) I clearly was not. Because I'm not any closer to an answer, and trying to eliminate the number of records I feel like I should be on every iteration just isn't giving me a result that makes any sort of mathematical sense. 

Now the question is, does giving up mean I look at the solutions or that I save this for tomorrow and fight with it some more?

I'm thinking more the first one. I know I'm missing something mathematical and I could probably beat my head against this for hours and not get it. So let's unlock the soultions and see what we get.

Let's look over two solutions, because at a glance netiher makes sense.

```c#
public class Line
    {
        public static string WhoIsNext(string[] names , long n)
        { 
            long x = 5;
            long i = 1;
  
            while (n > x)
            {
                n -= x;
                x *= 2;
                i *= 2;
            }
            
            return (names[(n - 1)/i]);
        }
    }
```
Simple loop that handles the doubling on each row. This looks like it might be the smart version of the notes I was trying to write. So given `x` (number of names) and `i` (current iteration), we loop while `n` (number we were given) is larger than x.

On each loop, we subtract the current value of `x` from `n`, then we double `x` and `i`. So `i` isn't the iteration? it's the number of people on each iteration and that's what I was missing on my stupid math. I was assuming one added per iteration, not doubling the number every iteration. I was growing linearly, not exponentially, but because the numbers got so big, so fast, I didn't double check my stupid logic there.

So then when we've finished looping, we return the names at the index of now-reduced value of `n` (which position in the current iteration we are), subtract 1 to get to a zero-based index, and divide it by i (the number of repeats of people in the current iteration).

Okay, so let's look at example number two:

```c#
public class Line
{
    public static string WhoIsNext(string[] names , long n)
    {
        var l = names.Length;
        return n <= l ? names[n - 1] : WhoIsNext(names, (n - l + 1) / 2);
    }
}
```

So recursive function calls are fun. We calculate `l` as `names.Length`. If `n` is less than or equal to `l`, then we have an index we can return. If not, then we call again but reduce the value of `n` by subtracting `l + 1` from it, then dividing by two. 

I'm staring at it. And I still don't understand why the heck it works. Whether or not it makes any sense, it sure is fast. Despite the recursive function call, it returns in less than 1ms because the math is so simplistic (I won't say simple, but it's very few operations on every iteration).

So why does this work?

On iteration 1, it just returns the index (converted to 0 based). Clear enough.

On iteration 2, there aren't just 5 names, there are 15 possibilites. So given say 13 as `n`, on the first iteration we'll see that `n > l` and call the function again. But we're losing data? `n - l + 1` in that case would be 9, I think? then divided by 2 it's 4. So second iteration we return `n - 1` which is the third index which is, actually, the right answer.

{ 1, 2, 3, 4, 5, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 }

So iteration 3, let's say we pick 43. `n - l + 1` is `39`, so we call the second iteration with `19`. Did I go too big? Shit. Yes. So then I wasn't wrong, so now I don't understand WHY I was wrong, so GAAAAAAAAAH.

I was using exponential growth, because each iteration is 2^iteration + the number of possibilities from before. So iteration 3 has 35 positions. So then why was I wrong before?

I think I'm too frustrated for this tonight. Tomorrow's project is to figure this crap out and then spend some time learning Unity instead of banging my head against this any more. I'm still missing something mathematical and I'm getting stuck on it. Maybe I'll reach out to the team to see what assumptions I'm making incorrectly?

Stupid logic. Yup. Fuckit.

# Day 5, round 2

If the "first" iteration (only five possibilities) is considered 0, the number of possibilities on any iteration `i` with array length `l` can be expressed as `l * Math.Pow(2, i)`. So while the given target `n` is greater than the sum of each iteration, we iterate. Once we find an iteration larger than `n`, we subtract the total of the previous iteration from `n` and that's the position in line of "this" iteration.

For any given iteration, there are `Math.Pow(2, i)` copies of each name. If we divide `n` by that number, take the integer of `n-1`, that should be the position in line.

I think. Let's go try it out.

Holy hell I think I got it. My answer matches the self-referential function. And is just as fast (return in 0 ms)