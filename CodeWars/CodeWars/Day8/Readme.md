# Day 8

Hell yeah I knew what to do with this one :)

At first I looked at it and was like "Uhhhhhhhh. They use big words."

Then I started thinking about it. And I was like wait, this is just graph traversal. Which I did last year. Only, last year I was doing depth-first. This is breadth-first. Boom, I knew I needed a queue, I just had to go look up the theory of BFS to get it. And I was spot on!

So I wrote my solution. And messed up the nulls, but hey that's what testing is for! Fixed that, and got both sample tests in one (ish, haha, if you don't count the null issue). So I submitted, and passed the "hidden" tests. So I immediately clicked on to submit my solution because I knew it was solid.

Now let's compare the top-rated in the community:

```c#
  public static List<int> TreeByLevels(Node node)
  {
    //level sort a tree...
    // something like, visit(n), enqueue left, enqueue right
    var list = new List<int>();
    
    var queue = new Queue<Node>();
    if (node != null) {
      queue.Enqueue(node);
    }
    
    while (queue.Count > 0) {
      var n = queue.Dequeue();
      if (n != null) {
        list.Add(n.Value);
        queue.Enqueue(n.Left);
        queue.Enqueue(n.Right);
      }
    }
    
    return list;
  }
```

Well now, this solution looks mighty familiar. In fact... it looks so very similar to mine... only mine is shorter :) That's right -- I feel like I beat the community on this one. Today is one of those few days where I feel REALLY good about what I do. I know I can do it, even if I don't know all of the things I feel like I should know. And I know I'm damn good at it.

The things his solution does that mine doesn't is an explicit null check and short circuit before enqueueing the first node, and then an extra level of nesting inside the queue loop. I honestly like my solution better, because mine feels more readable AND the null check is unnecessary. 

Oh, and my name is now officially higher than Victor's on the CodeWars board :) Yeah that kinda feels good. I know nobody else is active in there, but all of the positions there were still earned and I'm earning mine.