using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class CircularLinkedListTests
    {
        [TestMethod]
        public void TestDeleteNodeAfter()
        {
            CircularLinkedList myList = new CircularLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            myList.AddNode(4);
            myList.AddNode(5);

            myList.DeleteNodeAfter(3);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, GetListArray(myList)); 
        }

        private int[] GetListArray(CircularLinkedList list)
        {
            Node current = list.GetHead();
            if (current == null)
            {
                return new int[0];
            }

            int[] result = new int[0];
            do
            {
                Array.Resize(ref result, result.Length + 1);
                result[result.Length - 1] = current.Data;
                current = current.Next;
            } while (current != list.GetHead());

            return result;
        }
    }
}
