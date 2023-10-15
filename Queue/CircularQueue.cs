using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 16;
    private T[] elements;
    private int startIndex;
    private int endIndex;

    public int Count { get; private set; }

    public CircularQueue()
    {
        elements = new T[DefaultCapacity];
        startIndex = 0;
        endIndex = 0;
        Count = 0;
    }

    public CircularQueue(int capacity)
    {
        elements = new T[capacity];
        startIndex = 0;
        endIndex = 0;
        Count = 0;
    }

    public void Enqueue(T element)
    {
        if (Count >= elements.Length)
        {
            Grow();
        }

        elements[endIndex] = element;
        endIndex = (endIndex + 1) % elements.Length;
        Count++;
    }

    private void Grow()
    {
        int newCapacity = elements.Length * 2;
        T[] newElements = new T[newCapacity];
        for (int i = 0; i < Count; i++)
        {
            newElements[i] = elements[(startIndex + i) % elements.Length];
        }
        elements = newElements;
        startIndex = 0;
        endIndex = Count;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T dequeuedElement = elements[startIndex];
        startIndex = (startIndex + 1) % elements.Length;
        Count--;

        return dequeuedElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            array[i] = elements[(startIndex + i) % elements.Length];
        }
        return array;
    }
}
