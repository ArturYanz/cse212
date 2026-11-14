using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (priority 1), B (priority 3), C (priority 5). Dequeue once.
    // Expected Result: C (the highest priority is at the back of the queue)
    // Defect(s) Found: The loop stoppe at Count -1 and skipped the last item. Fixed with index < _queue.Count
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());

    }

    [TestMethod]
    // Scenario: Enqueue A (5), B (5), C (1). Dequeue once.
    // Expected Result: A (same priority, the one closest to the front goes first)
    // Defect(s) Found: >= made the last tied item win. Fixed by using >
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());

        // Add more test cases as needed below.
    }

    [TestMethod]
    // Scenario: Enqueue A (5), B (1). Dequeue twice.
    // Expected Result: A, then B (a dequeued item is removed from the queue) 
    // Defect(s) Found: Dequeue never removed the item. Fixed by adding _queue.RemoveAt(highPriorityIndex)
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());

        // Add more test cases as needed below.
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with the message "The queue is empty." 
    // Defect(s) Found: none 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }

        // Add more test cases as needed below.
    }
}

