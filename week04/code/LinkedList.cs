using System;
using System.Collections.Generic;

public class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}

public class LinkedList
{
    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    // Métodos auxiliares para pruebas
    public bool HeadAndTailAreNull() => Head == null && Tail == null;
    public bool HeadAndTailAreNotNull() => Head != null && Tail != null;

    public override string ToString()
    {
        var values = new List<int>();
        var current = Head;
        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }
        return "<LinkedList>(" + string.Join(",", values) + ")";
    }

    // Métodos base (ya deben existir en la plantilla)
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
        Count++;
    }

    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail!.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
        Count++;
    }

    public void RemoveHead()
    {
        if (Head == null) return;
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
            Head!.Prev = null;
        }
        Count--;
    }

    public void RemoveTail()
    {
        if (Head == null) return;
        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Tail = Tail!.Prev;
            Tail!.Next = null;
        }
        Count--;
    }

    public void InsertAfter(Node node, int value)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));
        Node newNode = new Node(value);
        newNode.Next = node.Next;
        newNode.Prev = node;
        if (node.Next != null)
            node.Next.Prev = newNode;
        else
            Tail = newNode;
        node.Next = newNode;
        Count++;
    }

    // ========== PROBLEMA 3: Remove (por valor) ==========
    public void Remove(int value)
    {
        if (Head == null) return;
        if (Head.Value == value)
        {
            RemoveHead();
            return;
        }
        Node? current = Head;
        while (current != null && current.Value != value)
            current = current.Next;
        if (current == null) return;
        if (current == Tail)
        {
            RemoveTail();
            return;
        }
        current.Prev!.Next = current.Next;
        current.Next!.Prev = current.Prev;
        Count--;
    }

    // ========== PROBLEMA 4: Replace ==========
    public void Replace(int oldValue, int newValue)
    {
        Node? current = Head;
        while (current != null)
        {
            if (current.Value == oldValue)
                current.Value = newValue;
            current = current.Next;
        }
    }

    // ========== PROBLEMA 5: Reverse Iterator ==========
    public IEnumerable<int> Reverse()
    {
        Node? current = Tail;
        while (current != null)
        {
            yield return current.Value;
            current = current.Prev;
        }
    }
}