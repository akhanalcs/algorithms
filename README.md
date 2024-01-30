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

### Insertions and deletions work great in Lists
Lets say you want to add items in a certain order.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a59e4c61-2ab3-4de2-9b7b-ea23e83887f0">

With lists, it’s as easy as changing what the previous element points to.

<img width="650" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/42cfd79f-0ff6-46b8-a91c-efe3772a488d">

But for arrays, you have to shift all the rest of the elements down.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/57c70d22-2937-4fea-ad69-13e5e9e9385c">

And if there’s no space, you might have to copy everything to a new location! Lists are better if you want to insert elements into the middle. 

### Runtimes for common operations on Arrays and Lists
|  | Arrays | Lists |
|---|---|---|
| Reading | $O(1)$ | $O(n)$ |
| Insertion | $O(n)$ | $O(1)$ |
| Deletion | $O(n)$ | $O(1)$ |

It’s worth mentioning that insertions and deletions are $O(1)$ time only if you can instantly access the element to be deleted. It’s a common practice to keep track of the first and last items in a linked list, so it would take only $O(1)$ time to delete those.

### List<T> vs LinkedList<T> in C#
[Reference](https://stackoverflow.com/a/169983/8644294)

<table width="100%">
<thead>
  <tr>
    <th width="50%"><code>List&lt;T&gt;</code></th>
    <th width="50%"><code>LinkedList&lt;T&gt;</code></th>
  </tr>
</thead>
<tbody>
  <tr>
  <td valign="top">
  <p><code>List&lt;T&gt;</code> is essentially just an array (with a wrapper), so random access is efficient.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList&lt;T&gt;</code> is composed of nodes with each node consisting its value and pointers/reference to the next and previous node.</p>
  <p>Elements' access is only efficient if it's done consecutively (either forwards or backwards).</p>
  <p>Random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer).</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>In most cases, <code>List&lt;T&gt;</code> is more useful.</p>
  <p><code>List&lt;T&gt;</code> can only cheaply add/remove at the end of the list because it doesn't require shifting of elements.</p>
  </td>
  <td valign="top">
  <p>Adding or removing elements from a <code>LinkedList&lt;T&gt;</code> can be done quickly at any position given you have a reference to a node close to the operation's location.</p>
  <p><code>LinkedList&lt;T&gt;</code> will have less cost when adding/removing items in the middle of the list.</p>
  For example:
  
  ```csharp
  LinkedList<int> myList = new LinkedList<int>();
  myList.AddLast(1);
  // We keep a reference to this node
  LinkedListNode<int> myNode = myList.AddLast(2);
  myList.AddLast(3);
  ```

  <p>We can insert a new element after the element 2. Since you already have a reference to this Node, you can simply use the <code>.AddAfter</code> method:</p>
  
  ```csharp
  // This will insert 4 after 2
  myList.AddAfter(myNode, 4);
  ```

  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>Index-based operations like accessing or updating an element are fast. <code>O(1)</code>.</p>
  </td>
  <td valign="top">
  <p>There's no indexed access in </code>LinkedList&lt;T&gt;</code> so random access is relatively expensive since it must walk the chain each time (hence why it doesn't have an indexer). <code>O(n)</code></p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p>For operations which involve adding or removing elements not at the end of the <code>List&lt;T&gt;</code>, it incurs <code>O(n)</code> cost due to shifting of elements.</p>  
  </td>
  <td valign="top">
  <p>Since each node points directly to its next node and previous node in a <code>LinkedList&lt;T&gt;</code>, insertions and deletions in known locations can be done in <code>O(1)</code> time.</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p><code>List&lt;T&gt;</code> requires contiguous memory space and could incur overhead when resizing.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList&lt;T&gt;</code> nodes can be anywhere in memory, which makes it more efficient when the list grows frequently.</p>
  </td>
  </tr>
  <tr>
  <td valign="top">
  <p><code>List&lt;T&gt;</code> generally more suited for cases where the size of the list is known in advance, or needs of random access operations are high.</p>
  </td>
  <td valign="top">
  <p><code>LinkedList&lt;T&gt;</code> is often preferable when you need to frequently add or remove items in the list and the access is mostly sequential.</p>
  </td>
  </tr>
</tbody>
</table>

## Selection Sort Algorithm
Suppose you have a bunch of music on your computer. For each artist, you have a play count.
You want to sort this list from most to least played, so that you can rank your favorite artists. 

One way is to go through the list and find the most-played artist. Add that artist to a new list.

<img width="550" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/82531c93-b3ff-4741-b68d-f9150cada251">

Do it again to find the next-most-played artist.

<img width="550" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/c06c9604-8199-44fc-ae2b-de524766da8a">

Keep doing this, and you’ll end up with a sorted list.

Now let's find how long it takes to run. **Remember that $O(n)$ time means you touch every element in a list once**.

You have an operation that takes $O(n)$ time, and you have to do that $n$ times:

<img width="750" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a42b74a6-7d4f-4959-b447-e86d40daa3ad">

This takes $O(n × n)$ time or $O(n^2)$ time.

Code example:
https://github.com/akhanalcs/algorithms/blob/f8338488287750ec939c2171a389424f354d043b/src/Algorithms/Sort/SelectionSorter.cs#L5-L31

Tested using:
https://github.com/akhanalcs/algorithms/blob/929d1c50ccdb4a00658c78ffb488e0d5ce9d6efa/tests/Algorithms.UnitTests/Sort/SelectionSorterTests.cs#L5-L20

## Recursion
Suppose you’re digging through your grandma’s attic and come across a mysterious locked suitcase.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/750d88ca-cd4a-4aa7-9c40-6f18e98351c7">

Grandma tells you that the key for the suitcase is probably in this other box.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/1b577ed5-78ad-44b0-a0a3-9586c02ad19c">

Here's a way to find the key using recursion (**pseudocode**)
```py
# Every recursive function has two parts: the base case, and the recursive case
def look_for_key(box):
  for item in box:
    # Recursive case: when the function calls itself
    if item.is_a_box():
      look_for_key(item) # <--- Recursion!
    # Base case: when the function doesn't call itself again
    elif item.is_a_key():
      print “found the key!”
```

Check out the Recursion folder for code examples.

## Quicksort
Quicksort is a sorting algorithm. It’s much faster than selection sort $O(n^2)$ and is frequently used in real life.
In the worst case, quicksort takes $O(n^2)$ time. In the average case, quicksort takes $O(n * \log n)$ time.

The simplest arrays that a sorting algorithm can handle

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a8f2c186-5a8a-40be-bddf-a83696244b77">

Empty arrays and arrays with just one element will be the base case. You can just return those arrays as is—there’s nothing to sort:
```py
def quicksort(array):
  if len(array) < 2:
    return array
```

An array with two elements is pretty easy to sort too.

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/b557fbf2-8463-414b-be3c-15557b5b43a2">

Consider an array of 4 elements.

<table>
<thead>
  <tr>
    <th>$33$</th>
    <th>$10$</th>
    <th>$15$</th>
    <th>$7$</th>
  </tr>
</thead>
<tbody>
</tbody>
</table>

Remember that you're using D&C, so you want to break down this array until you're at the base case.

First, pick an element from the array. This element is called the _pivot_. For eg: $33$.

Now find the elements smaller than the pivot and the elements larger than the pivot. This is called _partitioning_.

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/460c03d4-aec9-4b53-b76e-195d4eff4646">

Now you have 
- A sub-array of all the numbers less than or equal to the pivot
- The pivot 
- A sub-array of all the numbers greater than the pivot

The array on the left has three elements. You already know how to sort an array of three elements: call quicksort on it recursively.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/1ddb24e1-0923-4598-a6ae-b3ff42fbb2d3">

```
quicksort([10, 15, 7]) + [33] + quicksort([])
> [7, 10, 15] + [33] + []
> [7, 10, 15, 33]
```
Code example:
https://github.com/akhanalcs/algorithms/blob/4215d8cf60cb10c94ac8c191c2db94b034b833c3/tests/Algorithms.UnitTests/Sort/QuickSorterTests.cs#L5-L18

## Hash Functions
A hash function is a function where you put in a string and you get back a number.

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/30d15112-6abc-46db-ab22-c0697ed78d0e">

- It needs to be consistent. For example, suppose you put in “apple” and get back “4”. Every time you put in “apple”, you should get “4” back. Without this, your hash table won’t work.
- It should map different words to different numbers. For example, a hash function is no good if it always returns “1” for any word you put in. In the best case, every different word should map to a different number.
- The hash function knows how big your array is and only returns valid indexes. So if your array is 5 items, the hash function doesn’t return 100 … that wouldn’t be a valid index in the array.

Let's create a price catalog using it.

Start with an empty array. You’ll store all of your prices in this array.

<img width="200" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d9c9a8c8-3cc6-4cca-acfb-ea50fbed0063">

Let’s add the price of an apple. Feed “apple” into the hash function.

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/20383ee9-9787-40c1-8853-b92914c76cb1">

The hash function outputs “3”. So let’s store the price of an apple at index 3 in the array.

<img width="250" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/2b95a5f2-ee58-46a3-9734-e72cc4fdb5e2">

Now you ask, “Hey, what’s the price of an apple?” You don’t need to search for it in the array. Just feed “apple” into the hash function.
It tells you that the price is stored at index 3.

The hash function tells you exactly where the price is stored, so you don’t have to search at all! 

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/02e635e7-7d03-4be4-a8fb-6847777ad385">

### Good hash function
A good hash function distributes values in the array evenly.

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/031625f3-2541-41ec-81d7-ef7b0a3f8eab">

A bad hash function groups values together and produces a lot of collisions.

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/570d541b-4827-412b-9015-c7507d301303">

## Hash Table
Hash Table = Hash Function + Array

C# has a type `Dictionary<TKey,TValue>` which is type-safe and can often be used as an alternative to Hashtable. For example:
```cs
Dictionary<string, double> catalog = new();

catalog["apple"] = 0.67;
catalog["milk"] = 1.49;
catalog["avocado"] = 0.99;

foreach(var key in catalog.Keys)
{
    Console.WriteLine($"Key: {key}, Value: {dictionary[key]}");
}
```

Performance of Hash tables

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/5e8a4386-462b-4b77-ba88-5e4babe17b0d">

In the average case, hash tables take O(1) for everything. $O(1)$ is called constant time.
It doesn’t mean instant. It means the time taken will stay the same, regardless of how big the hash table is.

<p align="left">
  <img width="185" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/f81d0771-bdb7-4e6e-b1dc-b6c94f0b1eee">
&nbsp;
  <img width="201" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/86402cf5-cb31-484d-951d-262ed4510138">
&nbsp;
  <img width="208" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/db1e16b7-1741-4449-ae2f-37c364ca4edf">
</p>

Comparision of Hash tables to Arrays and Linked Lists

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a6565709-8de5-4f81-9416-7f82adf10101">

## Breadth-first search
The algorithm to solve a shortest-path problem is called breadth-first search.

Breadthfirst search runs on graphs. It can help answer two types of questions:
- Question type 1: Is there a path from node A to node B?
- Question type 2: What is the shortest path from node A to node B?

Suppose you’re in San Francisco, and you want to go from Twin Peaks to the Golden Gate Bridge. You want to get there by bus, with the minimum number of transfers. Here are your options:

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d8e706af-0492-4ec7-894c-13ea3359253d">

The shortest route to the bridge is three steps long.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/8de8c1ec-f204-42d5-b96b-25a0c31ed2ec">

To figure out how to get from Twin Peaks to the Golden Gate Bridge, there are two steps:
1. Model the problem as a graph.
2. Solve the problem using breadth-first search.

### Queues
The queue is called a FIFO data structure: First In, First Out. In contrast, a stack is a LIFO data structure: Last In, First Out.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/10e0c5c9-c52a-43e7-957c-1bc1d05df7f5">

### Example 1: Find the mango seller
<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a25a51f7-c1bc-4b35-9b8c-fe9fcd09b0ba">

You want to find the mango seller using breadth-first search.

To implement the graph in code, you can use a data structure that lets you express relationships: a **hash table**!

Here's how it looks like in Python
```py
graph = {}
graph[“you”] = [“alice”, “bob”, “claire”]
# Notice that in a directed graph like this, you only put names that have arrow directed towards them.
graph[“bob”] = [“anuj”, “peggy”]
graph[“alice”] = [“peggy”]
graph[“claire”] = [“thom”, “jonny”]
graph[“anuj”] = []
graph[“peggy”] = []
graph[“thom”] = []
graph[“jonny”] = []
```

This is how you'll implement the search

<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/7f9d681a-de93-4d05-8fa2-8ed98dd9f8eb">

Here's how the search looks like in Python
```py
def search(name):
  search_queue = deque()
  search_queue += graph[name] 
  searched = [] # This array is how you keep track of which people you’ve searched before.
  while search_queue:
    person = search_queue.popleft() 
    if not person in searched: # Only search this person if you haven’t already searched them.
      if person_is_seller(person):
        print person + “ is a mango seller!”
        return True
      else:
        search_queue += graph[person] 
      searched.append(person) # Marks this person as searched
  return False

search(“you”)
```

Implementation of this in C# looks like below
https://github.com/akhanalcs/algorithms/blob/2840b0dadc78341292e2d349653045b5bfff3e3d/tests/Algorithms.UnitTests/Search/BreadthFirstSearcherTests.cs#L7-L31

https://github.com/akhanalcs/algorithms/blob/2840b0dadc78341292e2d349653045b5bfff3e3d/src/Algorithms/Search/BreadthFirstSearcher.cs#L3-L39

#### Running time
If you search your entire network for a mango seller, that means you’ll follow each edge (remember, an edge is the arrow or connection from one person to another). So the running time is at least $O(number of edges)$.

You also keep a queue of every person to search. Adding one person to the queue takes constant time: $O(1)$. Doing this for every person will take $O(number of people)$ total. Breadth-first search takes $O(number of people + number of edges)$, and it’s more commonly written as $O(V+E)$. $V$ for number of vertices, $E$ for number of edges.

### Dependency
Arrow is pointed towards a dependency.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/e185cd90-a44c-4ea8-88b7-c8c4fb2df896">

It tells you that I can’t eat breakfast until I’ve brushed my teeth. So “eat breakfast” depends on “brush teeth”.

On the other hand, showering doesn’t depend on brushing my teeth, because I can shower before I brush my teeth. 

From this graph, you can make a list of the order in which I need to do my morning routine:

| 1. Wake up | 1. Wake up |
|:---|:---|
| **2. Shower** | **2. Brush teeth** |
| **3. Brush teeth** | **3. Shower** |
| **4. Eat breakfast** | **4. Eat breakfast** |

If task A (Shower) depends on task B (Wake up), task A shows up later in the list.

Dependent (Shower) always shows up later because the dependency (Wake up) needs to be resolved first.

### Tree
A tree is a special type of graph, where no edges ever point back.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/4fe22e05-a49e-4046-9ec2-1ae275fe8b08">

## Dijkstra's algorithm (finds the path with smallest total weight)
Compare it to BFS (which finds the path with fewest segments)

<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d852c3b0-ac97-4d6b-9b8f-71b0d301c77b">

### Weighted graphs vs Unweighted graphs
<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/37df2b0d-7667-4ecc-a28d-40d5a9618254">

To calculate the **shortest path** in an **unweighted** graph, use **breadth-first search**. To calculate the **shortest path** in a **weighted** graph, use **Dijkstra’s algorithm**.

### Directed graphs vs undirected graphs
<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d2416cb5-f3c0-4675-b4cf-d13e30840e19">

An undirected graph means that both nodes point to each other. That’s a cycle!

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/ecc65ddf-407c-4bde-aa93-6e0345182525">

With an undirected graph, each edge adds another cycle. Dijkstra’s algorithm only works with directed acyclic graphs, called DAGs for short.


