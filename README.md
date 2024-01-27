# algorithms
Refeshing Algorithms from Computer Science days.

## Helpful links
1. [Data Structures and Algorithms in C#](https://dev.to/adavidoaiei/fundamental-data-structures-and-algorithms-in-c-4ocf)

## Logarithms
What power do you have to raise the base to, to get another number.

For eg: $log{_2}{16}$ means 
- "How many 2s do you multiply together to get 16?" or
- "What power do you have to raise `2` to, to get `16`?"

``` math
\begin{align} log{_2}16&=x \\ 2^x& = 16 \\ x& = 4\end{align}
```

[Math formatting reference](https://github.com/mathjax/MathJax/issues/2312)

## Big O Notation
Big O notation tells you the number of operations an algorithm will make.

For eg: In case of Binary search, the running time of the algorithm in Big O notation is $O(\log n)$.

- Algorithm speed isn't measured in seconds, but in growth of the number of seconds.
- Instead, we talk about how quickly the runtime of an algorithm increases as the size of the input increases.
- Run time of algorithms is expressed in Big $O$ notation.
- $O(\log n)$ is faster than $O(n)$, but it gets a lot faster as the list of items you’re searching grows.

## Binary Search Algorithm
Binary search, also known as half-interval search, logarithmic search, or binary chop is a search algorithm that finds the position of a target value within a sorted array. 

Binary search compares the target value to the middle element of the array. If they are not equal, the half in which the target cannot lie is eliminated and the search continues on the remaining half, again taking the middle element to compare to the target value, and repeating this until the target value is found. If the search ends with the remaining half being empty, the target is not in the array.

Binary search runs in logarithmic time in the worst case, making $O(\log n)$ comparisons, where $n$ is the number of elements in the array.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/defbc02b-db11-4d7e-a3af-10350eb43369">

Code example:
https://github.com/akhanalcs/algorithms/blob/c8a7b652a67f6861bda113b18690c8fced8424ab/src/Algorithms/Search/BinarySearcher.cs#L3-L37

## Common Big O run times
- $O(\log n)$, also known as _log time_. Example: Binary search.
- $O(n)$, also known as _linear time_. Example: Simple search.
- $O(n * \log n)$. Example: A fast sorting algorithm, like quicksort.
- $O(n^2)$. Example: A slow sorting algorithm, like selection sort. Try to remember it like `ss` so `nn` -> $n^2$.
- $O(n!)$. Example: A really slow algorithm, like the traveling salesperson. For eg: To go through 5 cities, you have to calculate $5!$ which is $120$. It grows really, really fast. 🤯

## Arrays and Linked Lists
### Arrays
Sometimes you need to store a list of elements in memory. Suppose you’re writing an app to manage your todos. You’ll want to store the todos as a list in memory.
For eg, the todo list is:
- Brunch
- Bocce
- Tea

Storing the todos in array looks like

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a5160383-67db-43eb-8abf-ae7ed0b524c8">

Now suppose you want to add a fourth task. But the next memory location is taken up by someone else’s stuff.

If you’re out of space and need to move to a new spot in memory every time, adding a new item will be really slow.

### Linked Lists
With linked lists, your items can be anywhere in memory.
Each item stores the address of the next item in the list. A bunch of random memory addresses are linked together.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/36a034ae-33a6-4c8d-bc50-7e7bc1d2c109">

You go to the first address, and it says, “The next item can be found at address 123.” So you go to address 123, and it says, “The next item can be found at address 847,” and so on. Adding an item to a linked list is easy: you stick it anywhere in memory and store the 
address with the previous item.

With linked lists, you never have to move your items. 

### List<T> vs LinkedList<T> in C#
<table>
<thead>
  <tr>
    <th><code>List<T></code></th>
    <th><code>require</code></th>
  </tr>
</thead>
<tbody>
  <tr>
  <td valign="top">
  <p><code>List<T></code> is essentially just an array (with a wrapper), so random access is efficient.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList<T></code> is composed of nodes with each node consisting its value and pointers/reference to the next and previous node.</p>
  <p>Elements' access is only efficient if it's done consecutively (either forwards or backwards).</p>
  <p>Random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer).</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>In most cases, <code>List<T></code> is more useful.</p>
  <p>`List<T>` can only cheaply add/remove at the end of the list because it doesn't require shifting of elements.</p>
  </td>
  <td valign="top">
  <p>Adding or removing elements from a `LinkedList<T>` can be done quickly at any position given you have a reference to a node close to the operation's location.</p>
  <p><code>LinkedList<T></code> will have less cost when adding/removing items in the middle of the list.</p>
  For example:
  
  ```cs
  LinkedList<int> myList = new LinkedList<int>();
  myList.AddLast(1);
  LinkedListNode<int> myNode = myList.AddLast(2); // We keep a reference to this node
  myList.AddLast(3);
  ```
  <p>We can insert a new element after the element 2. Since you already have a reference to this Node, you can simple use the <code>AddAfter</code> method:</p>
  
  ```cs
  myList.AddAfter(myNode, 4); // This will insert 4 after 2
  ```
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>Index-based operations like accessing or updating an element are fast. $O(1)$.</p>
  </td>
  <td valign="top">
  <p>There's no indexed access in </code>LinkedList<T></code> so random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer). $O(n)$</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>For operations which involve adding or removing elements not at the end of the <code>List<T></code>, it incurs $O(n)$ cost due to shifting of elements.</p>  
  </td>
  <td valign="top">
  <p>Since each node points directly to its next node and previous node in a <code>LinkedList<T></code>, insertions and deletions in known locations can be done in $O(1)$ time.</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p><code>List<T></code> requires contiguous memory space and could incur overhead when resizing.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList<T></code> nodes can be anywhere in memory, which makes it more efficient when the list grows frequently.</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p><code>List<T></code> generally more suited for cases where the size of the list is known in advance, or needs of random access operations are high.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList<T></code> is often preferable when you need to frequently add or remove items in the list and the access is mostly sequential.</p>
  </td>
  </tr>
</tbody>
</table>

