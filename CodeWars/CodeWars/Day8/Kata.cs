namespace CodeWars.Day8
{
    using System.Collections.Generic;

    public class Kata
    {
        public static List<int> TreeByLevels(Node node)
        {
            var result = new List<int>();

            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node == null)
                {
                    continue;
                }
                result.Add(node.Value);
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

            return result;
        }
    }

    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }
}
