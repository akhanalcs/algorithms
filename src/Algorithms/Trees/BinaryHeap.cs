using System.Runtime.CompilerServices;

namespace Algorithms.Trees;

// TODO: Maybe complete this later by following Microsoft's code: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Collections/src/System/Collections/Generic/PriorityQueue.cs
// Built in min-heap implementation in .NET: PriorityQueue<TElement,TPriority> Class
public class BinaryHeap<TElement, TPriority>
{
    private (TElement Element, TPriority Priority)[] _nodes;
    
    //Custom comparer to be used to order the heap.
    private readonly IComparer<TPriority>? _comparer;

    private int _size;
    private int _version;

    public BinaryHeap() => (_nodes, _comparer) = (Array.Empty<(TElement, TPriority)>(), null);

    public BinaryHeap(IComparer<TPriority>? comparer) =>
        (_nodes, _comparer) = (Array.Empty<(TElement, TPriority)>(), comparer);

    public void Enqueue(TElement element, TPriority priority)
    {
        _version++;
        var currentSize = _size;

        if (_nodes.Length == currentSize) Grow(currentSize + 1);

        _size = currentSize + 1;

        if (_comparer is null) MoveUpDefaultComparer((element, priority), currentSize); // For eg: Put this (e,p) element at index: currentSize
        else MoveUpCustomComparer((element, priority), currentSize);
    }

    public TElement Dequeue()
    {
        if (_size == 0) throw new InvalidOperationException("The Heap is empty!");
        var element = _nodes[0].Element;
        RemoveRootNode();
        return element;
    }
    
    // A Min-Heap would be organized such that the parent node is always less than or equal to its child nodes.
    // Reference: Heap implementation at https://en.wikipedia.org/wiki/Binary_heap
    // Array Representation: 
    // Index || 0 | 1 | 2 | 3 | 4 | 5
    // Value || 1 | 5 | 3 | 7 | 9 | 8
    // Binary Tree Representation:
    //         1
    //       /     \
    //     5         3
    //   /   \      /
    // 7       9   8
    // For Eg: 5, 1, 7, 9, 3, 8
    // First: ((E,5), 0) -> [5]
    // Second: ((E,1), 1) -> [1,5] and so on
    private void MoveUpDefaultComparer((TElement Element, TPriority Priority) node, int nodeIndex) // Put this (Element,Priority) element at index: nodeIndex.
    {
        var nodes = _nodes;

        while (nodeIndex > 0)
        {
            var parentIndex = GetParentIndex(nodeIndex);
            (TElement Element, TPriority Priority) parent = nodes[parentIndex];
            
            // In a min-heap, a parent is always supposed to be smaller or equal to its children.
            // Like in the real world where you want to do at least or bigger things than your father 😁
            // "< 0" means the first argument is less than the second argument (parent.Priority in this case)
            if (Comparer<TPriority>.Default.Compare(node.Priority, parent.Priority) < 0)
            {
                nodes[nodeIndex] = parent; // In this case, parent switches position with the child
                nodeIndex = parentIndex; // And the nodeIndex becomes parent's Index
            }
            // Parent node is less than child node
            else
            {
                break;
            }
        }

        nodes[nodeIndex] = node;
    }

    private void MoveUpCustomComparer((TElement Element, TPriority Priority) node, int nodeIndex)
    {
        var nodes = _nodes;

        while (nodeIndex > 0)
        {
            var parentIndex = GetParentIndex(nodeIndex);
            (TElement Element, TPriority Priority) parent = nodes[parentIndex];
            // In a min-heap, a parent is always supposed to be smaller or equal to its children.
            // Like in the real world where you want to do at least or bigger things than your father 😁
            if (_comparer!.Compare(node.Priority, parent.Priority) < 0)
            {
                nodes[nodeIndex] = parent; // In this case, parent switches position with the child
                nodeIndex = parentIndex; // And the nodeIndex becomes parent's Index
            }
            // Parent node is less than child node which is great!
            else
            {
                break;
            }
        }

        nodes[nodeIndex] = node;
    }

    // Grow the BinaryHeap to match the specified min capacity
    private void Grow(int minCapacity)
    {
        const int growFactor = 2;
        const int minimumGrow = 4;

        var newCapacity = growFactor * _nodes.Length;
        
        // Ensure minimum growth is respected
        newCapacity = Math.Max(newCapacity, _nodes.Length + minimumGrow);
        
        // If the computed capacity is still less than specified, set to the original argument.
        if (newCapacity < minCapacity) newCapacity = minCapacity;

        Array.Resize(ref _nodes, newCapacity);
    }
    
    // If the tree root is at index 0, with valid indices 0 through n − 1, then each element 'e' at index 'i' has
    // - children at indices: 2i + 1 and 2i + 2
    // - parent at index: floor((i − 1) / 2).
    // Reference: Heap implementation at https://en.wikipedia.org/wiki/Binary_heap
    private static int GetParentIndex(int index) => (index - 1) / 2;
    private static int GetFirstChildIndex(int index) => 2 * index + 1;

    // For eg: _size here is 6, lastNodeIndex is 5
    // Before Array:
    // Index || 0 | 1 | 2 | 3 | 4 | 5
    // Value || 1 | 5 | 3 | 7 | 9 | 8
    // And we want to remove node at Index 0, i.e. _nodes[0]
    // Before Tree:
    //         1
    //       /     \
    //     5         3
    //   /   \      /
    // 7       9   8
    // After Tree:
    //         3
    //       /     \
    //     5         8
    //   /   \       
    // 7       9   
    // After array:
    // Index || 0 | 1 | 2 | 3 | 4
    // Value || 3 | 5 | 8 | 7 | 9
    // This operation takes place in two steps:
    // 1. Replace the root node with the last node in the tree (last node is 8 in the Before array).
    // 2. "Heapify" the tree to ensure the smallest element is again at the top.
    //    "Heapify" means adjusting the value down the tree until the tree again becomes a valid min heap tree.
    private void RemoveRootNode()
    {
        var lastNodeIndex = --_size; // Decrements the value of _size, and then assign the new value to lastNodeIndex
        _version++;

        if (lastNodeIndex > 0)
        {
            var lastNode = _nodes[lastNodeIndex];
            if (_comparer is null) MoveDownDefaultComparer(lastNode, 0); // Put the lastNode at the root node (0)
            else MoveDownCustomComparer(lastNode, 0); // Put the lastNode at the root node (0)
        }

        // Allows the garbage collector to reclaim the memory
        // If I was putting node of type (string, int), this will set the tuple at lastNodeIndex in the _nodes array
        // to the default value (which is (null, 0) for (string, int)
        if (RuntimeHelpers.IsReferenceOrContainsReferences<(TElement, TPriority)>())
        {
            _nodes[lastNodeIndex] = default;
        }
    }

    private void MoveDownDefaultComparer((TElement Element, TPriority Priority) node, int nodeIndex)
    {
        
    }

    private void MoveDownCustomComparer((TElement Element, TPriority Priority) node, int nodeIndex)
    {
        
    }
}