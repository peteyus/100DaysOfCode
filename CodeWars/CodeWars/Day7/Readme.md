# Day 7

Now the part of the day I always hate. Do I submit now or do I play with it and see if I can make it fancier?

I mean, I know I'm just going to submit it as-is, but I *SHOULD* play with it. Right? But if I don't really see a way to improve it, how do I improve it?

Maybe I should spend some time on Wednesday studying algorithms? Not that I really know that it will help a whole lot, but sometimes I look at these and feel like "well there should be a nice, pretty mathematical solution to this but herp derp here's a loop in stead!"

Okay, I know that's putting myself down more than I deserve. Still... herp derp.

It took me two tries, but I forgot to commit in between. The first time, I had the sample tests all working but then failed on a random test that hit a scenario I hadn't planned for. Fine enough, some debugging and tweaking had me seeing the problem (not using my `end` variable for comparison) soon enough. Still had it done in 30 minutes which isn't bad.

Okay... let's see what the community came up with.

Huh. The top one isn't a one-liner.

```c#
public class Intervals
{
    public static int SumIntervals(IEnumerable<ValueTuple<int, int>> intervals)
    {
        intervals = intervals.Where(IsValid);
        if (!intervals.Any())
            return 0;
        var flattened = intervals.SelectMany(n => new int[] { n.Item1, n.Item2 });
        var min = flattened.Min();
        var range = flattened.Max() - min;
        // just count up all the numbers in range that are not contained in an interval
        var vacant = Enumerable.Range(min, range)
            .Where(n => !intervals.Any(i => IsInInterval(n, i)))
            .Count();
        return range - vacant + 1;

        bool IsValid(ValueTuple<int, int> interval) => !interval.Equals(default) && interval.Item2 > interval.Item1;
        bool IsInInterval(int val, ValueTuple<int, int> interval) => val > interval.Item1 && val <= interval.Item2;
    }
}
```

This one's using some functions to help, which is fine enough. That was where my brain went first. So looking at the code, I'll have to put it into a compiler because I don't understand what his `SelectMany` is returning. It looks to me like it should be the same sort of input he got (an array of tuples of ints), but then how is `Min` and `Max` returning anything useful?

He mostly seems to depend on Linq functions. The line starting with `var vacant` looks like he's taking the overall min, overall max, and just dumping an entire range of numbers in between (fine), then checking against his input that all of the values for each number in the range to make sure that the given value is included in a range. I'm a little surprised this is performant -- given my random example, he'd have to loop over all of the inputs nearly 20,000 times. That feels expensive. Maybe he just got lucky?

```c#
public class Intervals
{
  public static int SumIntervals((int, int)[] intervals)
  {
    return intervals
      .SelectMany(i => Enumerable.Range(i.Item1, i.Item2 - i.Item1))
      .Distinct()
      .Count();
  }
}
```

I suppose I just didn't look down far enough for one-liners. So this one turns each record into an integer range, uses `SelectMany` to get out all of the integers, takes the `Distinct` count, and has an answer. That one is actually pretty clever. 

The problem I'm finding with these katas is while they give me a chance to learn from my own code, I'm not learning new things that I can apply to my day-to-day code. And maybe that's okay? I see this and think "Huh, that's clever" but I'm not going to remember it if a vaguely similar situation comes up. Where does that cleverness come from? What experience do I need to think "Yes, let me do it this obscure way! Haha, such genius!"? 

Something to think about I guess.