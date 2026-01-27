public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
{
    if (_queue.Count == 0)
        throw new InvalidOperationException("The queue is empty.");

    int bestIndex = 0;
    int bestPriority = _queue[0].Priority;

    // IMPORTANT: use '>' (not '>=') so ties keep the earliest (FIFO)
    for (int i = 1; i < _queue.Count; i++)
    {
        if (_queue[i].Priority > bestPriority)
        {
            bestPriority = _queue[i].Priority;
            bestIndex = i;
        }
    }

    string value = _queue[bestIndex].Value;
    _queue.RemoveAt(bestIndex); // MUST remove the same item you return
    return value;
}



    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}