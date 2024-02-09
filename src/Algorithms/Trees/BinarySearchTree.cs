namespace Algorithms.Trees;

public class Node<T>(Node<T>? left, Node<T>? right, T value)
{
    public Node<T>? Left { get; set; } = left;
    public Node<T>? Right { get; set; } = right;
    public T Value { get; } = value;
}

// For every node in BST, the nodes to its left are smaller in value, and the nodes to the right are larger in value.
public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node<T>? Root { get; set; }

    public BinarySearchTree() {} // parameterless ctor
    public BinarySearchTree(T firstElem) => Root = new Node<T>(null, null, firstElem); // ctor with first element as parameter

    public Node<T>? Find(T target)
    {
        if (target is null) throw new ArgumentNullException(nameof(target));
        var current = Root;
        while (current is not null)
        {
            var comparision = target.CompareTo(current.Value);
            // Greater than zero: This (target) instance follows other (current.Value) in the sort order.
            // It means that the target is greater than current.
            if (comparision > 0)
                current = current.Right; // If a value is greater than the current node's value, it should be located in the right subtree
            else if (comparision < 0)
                current = current.Left;
            else
                return current;
        }

        return null;
    }

    public void Add(T target)
    {
        if (Root is null)
            Root = new Node<T>(null, null, target);
        else
            AddAtNode(Root, target);
    }

    private static void AddAtNode(Node<T> node, T target)
    {
        var comparision = target.CompareTo(node.Value);
        // target is greater than node.Value, so we will go to Right child
        if (comparision > 0)
        {
            // If the right child is null, we found place to insert
            if (node.Right is null)
                node.Right = new Node<T>(null, null, target);
            // Right child is not null, so go on to the next level
            else
                AddAtNode(node.Right, target);
        }
        // target is less than node.Value, so we will go to Left child
        else if (comparision < 0)
        {
            // If the left child is null, we found place to insert
            if (node.Left is null)
                node.Left = new Node<T>(null, null, target);
            // Left child is not null, so go on to the next level 
            else
                AddAtNode(node.Left, target);
        }
        
        // If none of the above is true, that means that the target is equal to node.Value
        // BSTs typically do not allow duplicate values, so don't do anything
    }
    
    public IEnumerable<T> GetAllElements() => GetElementsAtNode(Root);

    // Better choice in terms of efficiency and performance compared to GetElementsAtNode1
    private static IEnumerable<T> GetElementsAtNode(Node<T>? node)
    {
        if (node is null) yield break;
        foreach (var value in GetElementsAtNode(node.Left)) yield return value;
        yield return node.Value;
        foreach (var value in GetElementsAtNode(node.Right)) yield return value;
    }
    
    private static IEnumerable<T> GetElementsAtNode1(Node<T>? node)
    {
        if (node is null) return Enumerable.Empty<T>();
        return GetElementsAtNode1(node.Left).Concat([node.Value]).Concat(GetElementsAtNode1(node.Right));
    }
}