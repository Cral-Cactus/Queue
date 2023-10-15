using System;

namespace Queue
{
    internal class Program
    {
        static void Main()
        {
            CircularQueue<int> queue = new CircularQueue<int>(3);

            // Enqueue elements
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4); // Queue will automatically resize

            // Dequeue elements
            Console.WriteLine("Dequeued element: " + queue.Dequeue());
            Console.WriteLine("Dequeued element: " + queue.Dequeue());

            // Enqueue more elements after dequeue
            queue.Enqueue(5);
            queue.Enqueue(6);

            // Convert queue to array and print
            int[] array = queue.ToArray();
            Console.WriteLine("Queue elements as array:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}