using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class CircularLinkedList
{
    private Node head;

    public CircularLinkedList()
    {
        head = null;
    }

    public void AddNode(int data)
    {
        if (head == null)
        {
            head = new Node(data);
            head.Next = head;
        }
        else
        {
            AddNode(data, head);
        }
    }

    private void AddNode(int data, Node current)
    {
        if (current.Next == head)
        {
            current.Next = new Node(data);
            current.Next.Next = head;
        }
        else
        {
            AddNode(data, current.Next);
        }
    }

    public void DeleteNodeAfter(int targetData)
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty");
            return;
        }

        Node currentNode = head;
        bool foundTarget = false;

        while (currentNode != null && !foundTarget)
        {
            if (currentNode.Data == targetData)
            {
                foundTarget = true;
                Console.WriteLine("Deleted elements after {0}:", targetData);
                currentNode.Next = head; 
            }
            else
            {
                currentNode = currentNode.Next;
            }
        }

        if (!foundTarget)
        {
            Console.WriteLine("Element {0} not found in the list", targetData);
        }
    }

    public Node GetHead()
    {
        return head;
    }

    public void DisplayList()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty");
        }
        else
        {
            DisplayList(head);
        }
    }

    private void DisplayList(Node current)
    {
        Console.Write(current.Data + " ");
        if (current.Next != head)
        {
            DisplayList(current.Next);
        }
        else
        {
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList myList = new CircularLinkedList();

            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            myList.AddNode(4);
            myList.AddNode(5);

            Console.WriteLine("Initial list:");
            myList.DisplayList();

            Console.Write("Enter the value to delete the element after: ");
            int targetValue = int.Parse(Console.ReadLine());
            myList.DeleteNodeAfter(targetValue);

            Console.WriteLine("List after deletion:");
            myList.DisplayList();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
