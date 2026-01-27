using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
public void TestPriorityQueue_1()
   {
    // Scenario: Enqueue items with different priorities, including a tie at the highest priority.
    // Expected Result: Dequeue returns the highest priority first; ties are returned in FIFO order.
    // Defect(s) Found: (fill after first run, if any)

    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("low", 1);
    priorityQueue.Enqueue("first-high", 5);
    priorityQueue.Enqueue("mid", 3);
    priorityQueue.Enqueue("second-high", 5);

    Assert.AreEqual("first-high", priorityQueue.Dequeue());
    Assert.AreEqual("second-high", priorityQueue.Dequeue());
    Assert.AreEqual("mid", priorityQueue.Dequeue());
    Assert.AreEqual("low", priorityQueue.Dequeue());
    }


[TestMethod]
public void TestPriorityQueue_2()
{
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown (and message matches requirement, if specified).
    // Defect(s) Found: (fill after first run, if any)

    var priorityQueue = new PriorityQueue();

    var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());

    // If the requirements specify an exact message, keep this assertion.
    Assert.AreEqual("The queue is empty.", ex.Message);
}
}
