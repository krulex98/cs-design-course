using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics.BinaryTrees
{
	public class Node<T>
		where T: IComparable<T>
	{
		public T Value { get; }
		
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }

		public Node(T value)
		{
			Value = value;
			Left = Right = null;
		}
	}

	public class BinaryTree<T> : IEnumerable<T>
		where T: IComparable<T>
	{
		private Node<T> _root;

		public T Value => _root.Value;
		public Node<T> Left => _root.Left;
		public Node<T> Right => _root.Right;

		public BinaryTree()
		{
			_root = null;
		}
		
		public void Add(T item)
		{
			if (_root == null)
			{
				_root = new Node<T>(item);
				return;
			}
			
			AddInner(new Node<T>(item));
		}

		private void AddInner(Node<T> newNode)
		{
			var curr = _root;
			Node<T> nodeForInsert = null;

			while (curr != null)
			{
				nodeForInsert = curr;

				if (newNode.Value.CompareTo(curr.Value) <= 0)
					curr = curr.Left;
				else
					curr = curr.Right;
			}

			if (newNode.Value.CompareTo(nodeForInsert.Value) <= 0)
				nodeForInsert.Left = newNode;
			else
				nodeForInsert.Right = newNode;
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (_root == null)
				yield break;

			var curr = _root;
			var stack = new Stack<Node<T>>();

			while (stack.Count > 0 || curr != null)
			{
				while (curr != null)
				{
					stack.Push(curr);
					curr = curr.Left;
				}

				curr = stack.Pop();

				yield return curr.Value;

				curr = curr.Right;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public static class BinaryTree
	{
		public static IEnumerable<int> Create(params int[] arr)
		{
			var tree = new BinaryTree<int>();
			foreach (var item in arr)
			{
				tree.Add(item);
			}

			return tree;
		}
	}
}