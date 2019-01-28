using System;
namespace AlgorithmsLearning
{
    public class Node
    {
        public Node next { get; set; }
        public int data { get; set; }
        public Node(int num)
        {
            data = num;
        }
    }
}
