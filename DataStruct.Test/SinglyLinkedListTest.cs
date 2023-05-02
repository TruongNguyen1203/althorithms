using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DataStruct.Test
{
    [TestFixture]
    public class SinglyLinkedListTest
    {
        private SinglelyLinkedList<int> _list;

        [SetUp]
        public void Init()
        {
            _list = new SinglelyLinkedList<int>();
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.IsNull(_list.Head);
            Assert.IsNull(_list.Tail);
            Assert.IsTrue(_list.IsEmpty);
        }

        [Test]
        public void AddFirst_and_AddLast_Onetime_CorrectState()
        {
            _list.AddFirst(1);
            CheckStateWithSingleNode(_list);
            
            _list.RemoveFirst();
            _list.AddLast(2);
            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void AddRemoveToGetStateSingleNode_CorrectState()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            _list.RemoveFirst();
            
            CheckStateWithSingleNode(_list);
            _list.AddFirst(3);
            _list.RemoveLast();
            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void AddFistAddLast_CorrectOrder()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            Assert.AreEqual(1, _list.Tail.Value);
            Assert.AreEqual(2, _list.Head.Value);
            
            _list.AddLast(3);
            Assert.AreEqual(3, _list.Tail.Value);
        }

        [Test]
        public void RemoveFirst_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>((() => _list.RemoveFirst()));
        }
        
        [Test]
        public void RemoveLast_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>((() => _list.RemoveLast()));
        }

        [Test]
        public void RemoveLast_SingleElement_HeadTailAreNull()
        {
            _list.AddFirst(1);
            _list.RemoveLast();
            
            Assert.IsTrue(_list.IsEmpty);
            Assert.IsNull(_list.Head);
            Assert.IsNull(_list.Tail);
        }

        [Test]
        public void IterateOver_SeveralItems_ExpectedSequence()
        {
            _list.AddLast(1);
            _list.AddLast(2);
            _list.AddLast(3);

            var result = new List<int>();

            foreach (var item in _list)
            {
                result.Add(item);
            }
            
            CollectionAssert.AreEqual(new List<int>{1,2,3}, result);
        }

        [Test]
        public void RemoveFirst_RemoveLast_CorrectSate()
        {
            _list.AddFirst(1);
            _list.AddFirst(2);
            _list.AddFirst(3);
            _list.AddFirst(4);
            
            _list.RemoveFirst();
            _list.RemoveLast();
            
            Assert.AreEqual(3, _list.Head.Value);
            Assert.AreEqual(2, _list.Tail.Value);
        }

        private void CheckStateWithSingleNode(SinglelyLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }
    }
}