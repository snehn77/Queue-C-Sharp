using System;
using System.Collections.Generic;

namespace Queue
{
    class MyQueue
    {
        private int QueueSize;

        public int front = 0,rear = 0;

        // Implementing queue using Array
        Object[] queue;

        // Default constructor is called taking in the size of queue as parameter
        public MyQueue(int SizeOfQueue)
        {
            queue = new Object[SizeOfQueue];
            QueueSize = SizeOfQueue;
        }


        public void Enqueue(object element)
        {
            // Condition for if Queue is full
            if (QueueSize == Size())
            {
                Console.WriteLine("Queue is full");
            }
            // If not full insert
            else
            {
                queue[rear++] = element;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Dequeue()
        {
            int size = Size();
            // Check if queue is empty
            if (size == 0)
            {
                Console.WriteLine("Queue is empty");       
            }
            else if(size == 1)
            {
                queue[0] = null;
                rear = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                queue[front] = null;
                for(int i = 0; i < size-1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                queue[size - 1] = null;
                rear = rear - 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Peek()
        {
            // Check if queue is empty
            if (Size() == 0)
            {
                Console.WriteLine("Queue is empty");
            }
            // If not empty return the top element
            else
            {
                Console.WriteLine("\nElement at Front: " + queue[front]);
            }
        }

        public int Size()
        {
            int count = 0;
            // Check if queue is empty
            foreach (var i in queue)
            {
                if (i != null)
                {
                    count = count + 1;
                }
            }
            return count;
        }

        public bool Contains(object element)
        {
            Console.WriteLine();
            // Check if queue is empty
            int size = Size();
            if (size == 0)
            {
                return false;
            }
            // If element in stack return true
            for (int i=0 ; i<size ; i++)
            {
                if(queue[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Reverse()
        {
            // Check if queue is empty
            int size = Size();
            if (size == 0)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            object[] reverseQueue = new Object[size];
            int count = 0;

            for(int i = rear-1; i >= front; i--)
            {
                reverseQueue[count] = queue[i];
                count = count + 1;
            }

            for (int i = 0; i< size; i++)
            {
                queue[i] = reverseQueue[i];
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nQueue Reversed Successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // This method gives Iterated List form the starting index of element using IEnumerable and yeild return
        public void Iterator()
        {

            // Check if queue is empty
            if (Size() == 0)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }


            IEnumerable<object> myQueue = GetIteratedQueue();
            Console.WriteLine("\nIterated Queue is: ");
            foreach (var i in myQueue)
            {
                if (i != null)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public IEnumerable<object> GetIteratedQueue()
        {
            foreach (var items in queue)
            {
                // Returning the element after every iteration
                yield return items;
            }
        }

        public void Print()
        {
            Console.WriteLine();
            if (Size() == 0)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            for (int i = 0; i < Size(); i++)
            {
                Console.WriteLine("Item {0}: {1}", (i+1), queue[i]);
            }
        }
    }
}
