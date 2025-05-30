using System;
using System.Collections;
using System.Collections.Generic;


namespace lab_7
{
    public class Node
    {
        public long Data { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }
        public Node(long data)
        {
            Data = data;
            Previous = null;
            Next = null;
        }
    }

    public class DoublyLinkedList : IEnumerable<long>
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }
        public bool IsEmpty()
        {
            return head == null;
        }

        public void AddLast(long data)
        {
            Node newNode = new Node(data);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public long FindFirstMultipleOf5()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Список порожній. Пошук неможливий.");
                return default(long);
            }
            foreach (long data in this)
            {
                if (data % 5 == 0)
                {
                    return data;
                }
            }
            return default(long);
        }
        
        public long SumOfEvenPositionElements()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Список порожній. Розрахунок суми неможливий.");
                return 0;
            }
            long sum = 0;
            int position = 1;
            foreach (long data in this)
            {
                if (position % 2 == 0)
                {
                    sum += data;
                }
                position++;
            }
            return sum;
        }

        public DoublyLinkedList GetElementsGreaterThan(long value)
        {
            DoublyLinkedList newList = new DoublyLinkedList();
            if (!IsEmpty())
            {
                foreach (long data in this)
                {
                    if (data > value)
                    {
                        newList.AddLast(data);
                    }
                }
            }
            else
            {
                Console.WriteLine("Список порожній. Отримання елементів неможливе.");
            }
            return newList;
        }

        private void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            else
            {
                tail = node.Previous;
            }
        }

        public void RemoveElementsGreaterThanAverage()
        {
            if (IsEmpty())
            {
                return;
            }

            long sum = 0;
            int count = 0;
            Node current = head;
            while (current != null)
            {
                sum += current.Data;
                count++;
                current = current.Next;
            }

            if (count == 0)
            {
                return;
            }

            double average = (double)sum / count;
            Node nodeToRemove = head;
            while (nodeToRemove != null)
            {
                if (nodeToRemove.Data > average)
                {
                    Node nextNode = nodeToRemove.Next;
                    RemoveNode(nodeToRemove);
                    nodeToRemove = nextNode;
                }
                else
                {
                    nodeToRemove = nodeToRemove.Next;
                }
            }
        }
        public IEnumerator<long> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public long this[int index]
        {
            get
            {
                if (IsEmpty())
                {
                    throw new IndexOutOfRangeException("Список порожній.");
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Індекс не може бути від'ємним.");
                }

                Node current = head;
                int currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        return current.Data;
                    }
                    current = current.Next;
                    currentIndex++;
                }

                throw new IndexOutOfRangeException("Індекс знаходиться за межами списку.");
            }
        }
    }
}

    
