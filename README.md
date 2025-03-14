# algorithms
Refreshing Algorithms from Computer Science days.

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
- $O(\log n)$, also known as _log time_. Example: Binary search. $O(\log n)$ basically means time goes up linearly while $n$ goes up exponentially. For eg: if it takes $1$ second to compute $10$ elements, it will take $2$ seconds to compute $100$ elements, $3$ seconds to compute $1000$ elements, and so on.
- $O(n)$, also known as _linear time_. Example: Simple search. $O(n)$ basically means time goes up linearly with $n$. If it takes $1$ second to compute $10$ elements, it will take $10$ seconds to compute $100$ elements.
- $O(n * \log n)$. Example: A fast sorting algorithm, like quicksort. $O(n * \log n)$ basically means time goes up slightly faster than linearly with $n$. If it takes $10$ seconds to process $10$ elements (10 * log₁₀(10) = 10 * 1 = 10), it would take about $200$ seconds to process $100$ elements (100 * log₁₀(100) = 100 * 2 = 200), and so on.
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

Node where the arrow HEAD is pointed to, will always appear first. Like how HEAD is at the top of our body.

### Tree
A tree is a special type of graph, where no edges ever point back.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/4fe22e05-a49e-4046-9ec2-1ae275fe8b08">

## Dijkstra's algorithm (finds the path with smallest total weight)
Compare it to BFS (which finds the path with fewest segments)

| Use Dijkstra's algorithm | Use Breadth first search algorithm |
|---|---|
| <img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/346ada37-1a62-4be0-919e-2405b9a21b1e"> | <img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/21cd612c-9672-43f0-826d-2258888c9308"> |

### Weighted graphs vs Unweighted graphs
<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/37df2b0d-7667-4ecc-a28d-40d5a9618254">

To calculate the **shortest path** in an **unweighted** graph, use **breadth-first search**. To calculate the **shortest path** in a **weighted** graph, use **Dijkstra’s algorithm**.

### Directed graphs vs undirected graphs
<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d2416cb5-f3c0-4675-b4cf-d13e30840e19">

An undirected graph means that both nodes point to each other. That’s a cycle!

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/ecc65ddf-407c-4bde-aa93-6e0345182525">

With an undirected graph, each edge adds another cycle. Dijkstra's algorithm works even if there is a cycle, as long as it is a positive weight cycle.

### Example
Dijkstra’s algorithm has four steps:
1. Find the cheapest node. This is the node you can get to in the least amount of time.
2. Check whether there’s a cheaper path to the neighbors of this node. If so, update their costs.
3. Repeat until you’ve done this for every node in the graph.
4. Calculate the final path.

For eg:

Imagine you have a book, and you want trade it for a piano. Your friends Alex, Amy and Beethoven are willing to trade various items.

How are you going to figure out the path from the book to the piano where you spend the least amount of money? 

<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/551768fa-2e4f-4388-836d-15086d6524ed">

| Parent<br>(When cost<br>updates, you<br>get a parent) | Node | Standing at Book<br>(only neighbors<br>of Book updated)<br><br>Cost 1 | Standing at Poster<br>(only neighbors<br>of Poster updated)<br><br>Cost 2 | Standing at LP<br>(only neighbors<br>of LP updated)<br><br>Cost 3 | Standing at Guitar<br>(only neighbors<br>of Guitar updated)<br><br>Cost 4 | Standing at Drumset<br>(only neighbors<br>of Drumset updated)<br><br>Cost 5 |
|---|---|---|---|---|---|---|
| Book | LP | $5$<br>💥 Updated | $5$<br>^^^^ C2W 🏆 | $5$ | $5$ | $5$ |
| Book | Poster | $0$<br>💥 Updated<br>^^^^ C1W 🏆 | $0$ | $0$ | $0$ | $0$ |
| Poster -> LP | Guitar | $∞$ | C1W + $30$ = $30$<br>💥 Updated | C2W + $15$ = $20$<br>💥 Updated<br>^^^^ C3W 🏆 | $20$ | $20$ |
| Poster -> LP | Drumset | $∞$ | C1W + $35$ = $35$<br>💥 Updated | C2W + $20$ = $25$<br>💥 Updated | $25$<br>^^^^ C4W 🏆 | $25$ |
| Guitar -> Drumset | Piano | $∞$ | $∞$ | $∞$ | C3W + $20$ = $40$<br>💥 Updated | C4W + $10$ = $35$<br>💥 Updated<br>^^^^ C5W 🏆 |
|  |  | At this point:<br>✅ Book | At this point:<br>✅ Book<br>✅ Poster | At this point:<br>✅ Book<br>✅ Poster<br>✅ LP | At this point:<br>✅ Book<br>✅ Poster<br>✅ LP<br>✅ Guitar | At this point:<br>✅ Book<br>✅ Poster<br>✅ LP<br>✅ Guitar<br>✅ Drumset |

At this point, you've run Dijkstra's algorithm for every node (you don't need to run it for the finish node).

Now you know that the shortest/ cheapest path costs $35. Let's figure out the path.

Piano has Drumset as parent, so you trade Drumset for Piano. And Drumset has LP as parent. And LP has Book as parent.

So here's the series of trades you'll need to make:

<img width="275" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/154a3381-7820-49ea-99f6-8739c740a3c1">

### Negative weight edges
<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a1e6eb83-ce94-4bb9-a46c-359ccf51efa1">

Imagine that Rama wants to get Drums.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/c29c54df-96b1-49b6-8599-91dd9656a3f6">

The second path costs him $2 less, so he should take that path, right?  
Well, guess what? If you run Dijkstra’s algorithm on this graph, Rama will take the wrong path. He’ll take the longer path. 

You can’t use Dijkstra’s algorithm if you have negative-weight edges. Negative-weight edges break the algorithm.

If you want to find the shortest path in a graph that has negative-weight edges, there’s an algorithm for that! It’s called the **Bellman-Ford** algorithm.

### Implementation
<img width="250" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d33784cd-5900-45da-a109-6e6be8270068">

To code this example, you’ll need three hash tables: Graph, costs and parents.

<img width="500" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/569b896c-4c01-4d4b-8de8-8bb0705c83f3">

To implement the **graph**, store the **neighbors** and the **cost** for getting to that neighbor.
For eg:
https://github.com/akhanalcs/algorithms/blob/733e35e9c503a99c2f3c89b06a7518a01f2395f9/tests/Algorithms.UnitTests/Greedy/DijkstraAlgorithmTests.cs#L19-L26

Next you need a hash table to store the **costs** for each node. For example.
https://github.com/akhanalcs/algorithms/blob/733e35e9c503a99c2f3c89b06a7518a01f2395f9/tests/Algorithms.UnitTests/Greedy/DijkstraAlgorithmTests.cs#L11-L17

You also need another hash table for the **parents**.
https://github.com/akhanalcs/algorithms/blob/733e35e9c503a99c2f3c89b06a7518a01f2395f9/tests/Algorithms.UnitTests/Greedy/DijkstraAlgorithmTests.cs#L28-L34

Finally, you need an array to keep track of all the nodes you’ve already **processed**, because you don’t need to process a node more than once
https://github.com/akhanalcs/algorithms/blob/733e35e9c503a99c2f3c89b06a7518a01f2395f9/src/Algorithms/Greedy/DijkstraAlgorithm.cs#L9-L10

The algorithm looks like this

<img width="350" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/16e39a00-c18f-4dd8-97cf-1951f1f5aed1">

Check out the code to see how I've implemented it in `.NET 8`.

## Greedy Algorithms
### Set covering problem
Given a set of elements ${1, 2, …, n}$ (called the universe) and a collection $S$ of $m$ subsets whose union equals the universe, the set cover problem is to identify the smallest sub-collection of $S$ whose union equals the universe. For example, consider the universe $U = {1, 2, 3, 4, 5}$ and the collection of sets $S = { {1, 2, 3}, {2, 4}, {3, 4}, {4, 5} }$. Clearly the union of $S$ is $U$. However, we can cover all elements with only two sets: ${ {1, 2, 3}, {4, 5} }$. Therefore, the solution to the [set cover problem](https://en.wikipedia.org/wiki/Set_cover_problem) has size 2.

**Example:**

Suppose you’re starting a radio show. You want to reach listeners in all 8 states. You have to decide what stations to play on to reach all those listeners. It costs money to be on each station, so you’re trying to minimize the number of stations you play on. 

<p align="left">
  <img width="210" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a0c9184e-e923-48d6-89a1-340b779b18bd">
&nbsp;
  <img width="234" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/605f8b67-6df2-467f-903e-ac13b49c4f0a">
</p>

Check out the code to see how I've implemented it in `.NET 8`.

### NP Complete (Page 159)
Some problems are famously hard to solve. The traveling salesperson and the set-covering problem are two examples. A lot of smart people think that it’s not possible to write an algorithm that will solve these problems quickly.

That's why we solve them by approximating using Greedy algorithms.

There’s no easy way to tell if the problem you’re working on is NP-complete. 

Here are some giveaways:
- Your algorithm runs quickly with a handful of items but really slows down with more items.
- “All combinations of X” usually point to an NP-complete problem.
- Do you have to calculate “every possible version” of X because you can’t break it down into smaller sub-problems? Might be NP-complete.
- If your problem involves a sequence (such as a sequence of cities, like traveling salesperson), and it’s hard to solve, it might be NP-complete.
- If your problem involves a set (like a set of radio stations) and it’s hard to solve, it might be NP-complete.
- Can you restate your problem as the set-covering problem or the traveling-salesperson problem? Then your problem is definitely 
NP-complete.

## Dynamic Programming (Page 161)
Dynamic programming starts by solving subproblems and builds up to solving the big problem.

- Dynamic programming is useful when you’re trying to optimize something given a constraint. 
- You can use dynamic programming when the problem can be broken into discrete subproblems.
- Every dynamic-programming solution involves a grid.
- The values in the cells are usually what you’re trying to optimize.
- Each cell is a subproblem, so think about how you can divide your problem into subproblems.
- There’s no single formula for calculating a dynamic-programming solution.

### Knapsack problem
#### Example: Optimizing your travel itinerary
Suppose you’re going to London for a nice vacation. You have two days there and a lot of things you want to do. You can’t do everything, so you make a list.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/5295a8e0-d804-42c7-926d-69bda3dae5d3">

Can you figure out what you should see, based on this list? 

Draw the dynamic-programming grid for this list.

Note: The formula looks intimidating, but it's quite intuitive, which I've explained in the grid below.

$cell[i][j] = \max(\text{Previous Max: Value at } cell[i-1][j], \text{Value of current item + value of remaining space: }cell[i-1][j-\text{item's weight}])$

| <br>_________________ | 1/2 day<br>________ | 1 day<br>___________________________ | 1 1/2 day<br>___________________________ | 2 days<br>___________________________ |
|---|---|---|---|---|
| Westminster Abbey<br>Time: 1/2 day<br>Rating: 7 | $7$ _(0,0)_<br><br>W | $7$ _(0,1)_<br><br>W | $7$ _(0,2)_<br><br>W | $7$ _(0,3)_<br><br>W |
| Globe Theater<br>Time: 1/2 day<br>Rating: 6 | $7$ _(1,0)_<br><br><br><br><br><br><br><br><br><br><br>W | $13$ _(1,1)_<br><br>= MAX (Prev Max:Right above it,<br>Current rating + Remaining day<br>rating)<br>= MAX (7, 6 + (1 day - 1/2 day))<br>= MAX (7, 6 + value at (0,0))<br>= MAX (7, 6 + 7)<br>= MAX (7, 13)<br>= 13<br><br>GW | $13$ _(1,2)_<br><br><br><br><br><br><br><br><br><br><br>GW | $13$ _(1,3)_<br><br><br><br><br><br><br><br><br><br><br>GW |
| National Gallery<br>Time: 1 day<br>Rating: 9 | $7$ _(2,0)_<br><br><br><br><br><br><br><br><br><br><br>W | $13$ _(2,1)_<br><br>= MAX (Prev Max:Right above it,<br>Current rating + Remaining day<br>rating)<br>= MAX (13, 9 + 0)<br>= 13<br><br><br><br><br>GW | $16$ _(2,2)_<br><br>= MAX (Prev Max:Right above it,<br>Current rating + Remaining day<br>rating)<br>= MAX (13, 9 + (1.5 day - 1 day))<br>= MAX (13, 9 + value at (1,0))<br>= MAX (13, 9 + 7)<br>= MAX (13, 16)<br>= 16<br><br>NW | $22$ _(2,3)_<br><br>= MAX (Prev Max:Right above it,<br>Current rating + Remaining day<br>rating)<br>= MAX (13, 9 + (2 days - 1 day))<br>= MAX (13, 9 + value at (1,1))<br>= MAX (13, 9 + 13)<br>= MAX (13, 22)<br>= 22<br><br>NGW |
| British Museum<br>Time: 2 days<br>Rating: 9 | $7$ _(3,0)_<br><br>W | $13$ _(3,1)_<br><br>GW | $16$ _(3,2)_<br><br>NW | $22$ _(3,3)_<br><br>NGW |
| St. Paul's Cathedral<br>Time: 1/2 day<br>Rating: 8 | $8$ _(4,0)_<br><br>S | $15$ _(4,1)_<br><br>SW | $21$ _(4,2)_<br><br>SGW | $24$ _(4,3)_<br><br>SNW |

Final answer:
- St. Paul's Cathedral
- National Gallery
- Westminster Abbey

#### Example: Optimizing your travel packing
Check out [my answer on StackOverflow](https://stackoverflow.com/a/77933874/8644294).

### Longest common substring
Suppose you run dictionary.com. Someone types in a word, and you give them the definition. 
But if someone misspells a word, you want to be able to guess what word they meant. Alex is searching for _fish_, but he accidentally put in _hish_. That’s not a word in your dictionary, but you have a list of words that are similar, like: _fish_, _vista_ etc.

Which word did Alex mean to type: _fish_ or _vista_? 

Start with the grids: 
- Fish  
  <img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a7345283-212c-4a7a-8c35-9ffd33b80c85">
- Vista
  <img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/034d03c4-3db1-4049-bf12-141b5158d20d">

_hish_ and _fish_ have a substring of three letters in common. _hish_ and _vista_ have a substring of two letters in common.  
Alex probably meant to type _fish_.

#### Formula
<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/d364aa2c-2635-44bf-a8f2-751597c09dfa">

```py
if word_a[i] == word_b[j]:           # The letters match
 cell[i][j] = cell[i-1][j-1] + 1
else:                                # The letters don’t match
 cell[i][j] = 0 
```

#### C# Implementation
Example of this in C# is well documented [here](https://stackoverflow.com/a/77942555/8644294).

### Longest common subsequence
Is the number of letters in a sequence that the two words have in common.

Suppose Alex accidentally searched for _fosh_. Which word did he mean: _fish_ or _fort_?

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/1af6353f-2bbe-42e2-be17-d0906fe8a1cc">

Alex probably meant to type _fish_.
#### Formula
<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/6e300ccd-eea8-4850-b12c-b1327a294127">

```py
if word_a[i] == word_b[j]:                      # The letters match.
 cell[i][j] = cell[i-1][j-1] + 1
else:                                           # The letters don’t match.
 cell[i][j] = max(cell[i-1][j], cell[i][j-1])
```

#### C# Implementation
Example of this in C# is well documented [here](https://stackoverflow.com/a/77944515/8644294).

## k-nearest neighbors (page 187)
### Classifying oranges vs grapefruit
How would you classify this fruit? 

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a432779c-dcce-401d-91c4-0968afd098bd">

One way is to look at the neighbors of this spot. Take a look at the three closest neighbors of this spot.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/a460dd99-1a42-4522-b2fb-8f4b81a4954c">

More neighbors are oranges than grapefruit. So this fruit is probably an orange. 
Congratulations: You just used the k-nearest neighbors (KNN) algorithm for classification!

The KNN algorithm is simple but useful! If you’re trying to **classify** something, you might want to try KNN first.

### Recommender System
Suppose you’re Netflix, and you want to build a movie recommendations system for your users.

You can plot every user on a graph.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/5166f670-89e0-4859-b5cf-b0ec2f66cbd9">

These users are plotted by similarity, so users with similar taste are plotted closer together.

Suppose you want to recommend movies for Priyanka. Find the five users closest to her.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/2f4e118f-7d34-469e-b32a-d3a518127a93">

Justin, JC, Joey, Lance, and Chris all have similar taste in movies. So whatever movies they like, Priyanka will probably like too! 

Once you have this graph, building a recommendations system is easy. If Justin likes a movie, recommend it to Priyanka.

<img width="650" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/88ea3901-e102-4e38-806d-dea25a601492">

You graphed the users by similarity. How do you figure out how similar two users are?

#### Feature extraction
Here’s how you can convert users into a set of numbers. When users sign up for Netflix, have them rate some categories of movies based on 
how much they like those categories. For each user, you now have a set of ratings.

<img width="550" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/8a424ffc-570f-4ae5-83ca-2a06d7c73a83">

Now each user is represented by a set of five numbers.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/0c4af2f9-d078-42ff-90fd-23c7bce7bf6a">

What's the distance between Priyanka and Justin?

Let's use the distance formula to find it:

```math
\begin{align}
& \sqrt{(a_1-a_2)^2 + (b_1-b_2)^2 + (c_1-c_2)^2 + (d_1-d_2)^2 + (e_1-e_2)^2} \\
= & \sqrt{(3-4)^2 + (4-3)^2 + (4-5)^2 + (1-1)^2 + (4-5)^2} \\
= & \sqrt{1 + 1 + 1 + 0 + 1} \\
= & \sqrt{4} \\
= & 2 
\end{align}
```

Priyanka and Justin are pretty similar.

What’s the difference between Priyanka and Morpheus? Priyanka and Morpheus are 24 apart.

The distance tells you that Priyanka’s tastes are more like Justin’s than Morpheus’s.

If you’re a Netflix user, Netflix will keep telling you, “Please rate more movies. The more movies you rate, the better your recommendations will be.” Now you know why. The more movies you rate, the more accurately Netflix can see what other users you’re similar to.

#### Regression
These are the two basic things you’ll do with KNN—classification and regression:
- Classification = categorization into a group
- Regression = predicting a response (like a number)

## Where to go next (page 202)
### Binary search tree
Allows you to insert into the array without having to sort the array afterward.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/3eeaf2a0-01a8-44d7-953c-999a3e7a41fc">

For every node, the nodes to its left are smaller in value, and the nodes to the right are larger in value.

Searching for an element in a binary search tree takes $O(\log n)$ time on average and $O(n)$ time in the worst case.

Running times:

|  | Sorted Array | Binary Search Tree |
|---|---|---|
| Search | $O(\log n)$ | $O(\log n)$ |
| Insert | $O(n)$ | $O(\log n)$ |
| Delete | $O(n)$ | $O(\log n)$ |

Binary search trees don’t get random access like you get with array.

Those performance times are also on average and rely on the tree being balanced. Suppose you have an imbalanced tree like the one shown below.

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/28639e71-9558-4e6f-915d-ebdf85ff7fd5">

This tree doesn’t have very good performance, because it isn’t balanced. There are special binary search trees that balance themselves. One example is the red-black tree. 

Built in implementation of red-black tree in .NET: `SortedSet<T>` class or `SortedDictionary<TKey,TValue>` class.
https://github.com/akhanalcs/algorithms/blob/e3e1ddd0cd745ad5a29f4080b651a63acbebff6b/tests/Algorithms.UnitTests/Trees/BinarySearchTreeTests.cs#L40-L48

### [Heap](https://en.wikipedia.org/wiki/Heap_(data_structure))
The heap is one maximally efficient implementation of an abstract data type called a priority queue and in fact, priority queues are often referred to as "heaps", regardless of how they may be implemented.

Built in min-heap implementation in .NET: `PriorityQueue<TElement,TPriority>` class.
https://github.com/akhanalcs/algorithms/blob/2dca3267d1adc9e77f9dcff99c7af6e4f9c8d1f4/tests/Algorithms.UnitTests/Trees/BinaryHeapTests.cs#L6-L20

### Inverted Indexes
It’s commonly used to build search engines.

Suppose you have three web pages with this simple content.

<img width="400" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/881d73d2-1837-4a27-8eaf-93deeceac981">

Let’s build a hash table from this content. The keys of the hash table are the words, and the values tell you what pages each word appears on.

Now suppose a user searches for "adit". Below code shows how it's implemented.
https://github.com/akhanalcs/algorithms/blob/54f26bc4479d131862ca098b428f1153cfd798c0/tests/Algorithms.UnitTests/Search/InvertedIndexTests.cs#L5-L25

### Fourier transform
Given a smoothie, the Fourier transform will tell you the ingredients in the smoothie. 

Or, to put it another way, given a song, the transform can separate it into individual frequencies.  
The Fourier transform tells you exactly how much each note contributes to the overall song. So you can just get rid of the notes that aren’t important. That’s how the MP3 format works!

People use the Fourier transform to try to predict upcoming earthquakes and analyze DNA.  
You can use it to build an app like Shazam, which guesses what song is playing.

### MapReduce (Parallel algorithm)
It’s fine to run a parallel algorithm on your laptop if you need two to four cores, but what if you need hundreds of cores? Then you can write your algorithm to run across multiple machines. 

The MapReduce algorithm is a popular **distributed algorithm**. You can use it through the popular open source tool Apache Hadoop.

`MapReduce` is built up from two simple ideas: the `map` function and the `reduce` function.

The `map` function is simple: it takes an array and applies the same function to each item in the array.
```py
>>> arr1 = [1, 2, 3, 4, 5]
>>> arr2 = map(lambda x: 2 * x, arr1)
[2, 4, 6, 8, 10]
# OR
>>> arr1 = # A list of URLs
>>> arr2 = map(download_page, arr1) # Imagine doing this for thousands of urls across 100s of machine. This is the idea behind "map" in MapReduce.
```

The `reduce` function confuses people sometimes "reduces” a whole list of items down to one item. 

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/562c055e-8ba4-4ac3-8852-05e38c6df1e0">
```py
>>> arr1 = [1, 2, 3, 4, 5]
>>> reduce(lambda x,y: x+y, arr1)
15
```

MapReduce uses these two simple concepts to run queries about data across multiple machines. When you have a large dataset (billions 
of rows), MapReduce can give you an answer in minutes where a traditional database might take hours. 

### Bloom filters and HyperLogLog
Just read Page 211.

They are probabilistic algorithms which are useful when you have a lot of data and are satisfied with approximate answers.

### SHA algorithms
 SHA is a hash function. It generates a hash, which is just a short string.

#### Usage: Comparing files
The hash function for hash tables went from string to array index, whereas SHA goes from string to string.

<img width="300" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/911e0930-6687-4cb8-9635-5c3a892bb5ce">

You can use SHA to tell whether two files are the same. This is useful when you have very large files. Suppose you have a 4 GB file. You want to check whether your friend has the same large file. You don’t have to try to email them your large file. Instead, you can both calculate the SHA hash and compare it.

<img width="450" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/6e405279-eb27-4d84-8640-5a35c73db025">

#### Usage: Checking passwords
SHA is also useful when you want to compare strings without revealing what the original string was.

For example, suppose Gmail gets hacked, and the attacker steals all the passwords! Is your password out in the open? No, it isn’t. Google doesn’t store the original password, only the SHA hash of the password! When you type in your password, Google hashes it and checks it against the hash in its database.

<img width="750" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/829985ae-ef0e-4bd2-8e42-2eb3aedbad6c">

It’s a one-way hash. But you can’t get the original string from the hash.

<img width="275" alt="image" src="https://github.com/akhanalcs/algorithms/assets/30603497/ccc5727a-dd82-43ae-84bb-7ae0e361a3b8">

#### Locality-sensitive hashing (Simhash)
SHA has another important feature: it’s locality **insensitive**. Suppose you have a string, and you generate a hash for it.
```
dog --> cd6357
```

If you change just one character of the string and regenerate the hash, it’s totally different!
```
dot --> e392da
```

This is good because an attacker can’t compare hashes to see whether they’re close to cracking a password. 

Sometimes, you want the opposite: you want a locality-sensitive hash function. That’s where **Simhash** comes in.

If you make a small change to a string, Simhash generates a hash that’s only a little different. This allows you to compare hashes and see how similar two strings are, which is pretty useful!
- A teacher could use Simhash to see whether a student was copying an essay from the web.
- Google uses Simhash to detect duplicates while crawling the web.

Simhash is useful when you want to check for similar items!

### Diffie-Hellman key exchange
How do you encrypt a message so it can only be read by the person you sent the message to? 

The easiest way is to come up with a **cipher**, like `a = 1`, `b = 2`, and so on. Then if I send you the message `“4,15,7”`, you can translate it to `“d,o,g”`. 

Issues with this:
- Both parties need to know the cipher. This could be leaked.
- Cipher could be guessed and easily broken. The Germans used a much more complicated cipher in WWII, but it was still cracked.

Diffie-Hellman solves both of the above issues.
- Both parties don’t need to know the cipher. So we don’t have to meet and agree to what the cipher should be.
- The encrypted messages are extremely hard to decode.

Diffie-Hellman has two keys: a public key and a private key. The public key is exactly that: public. You can post it on your website, email it to friends, or do anything you want with it. You don’t have to hide it.  
When someone wants to send you a message, they encrypt it using the public key. An encrypted message can only be decrypted using the 
private key. As long as you’re the only person with the private key, only you will be able to decrypt this message!  
The Diffie-Hellman algorithm is still used in practice, along with its successor, RSA. 

### Linear programming
Linear programming is used to maximize something given some constraints. 

For example, suppose your company makes two products, shirts and totes. Shirts need 1 meter of fabric and 5 buttons. Totes need 
2 meters of fabric and 2 buttons. You have 11 meters of fabric and 20 buttons. You make $2 per shirt and $3 per tote. How many shirts and 
totes should you make to maximize your profit?  
Here you’re trying to maximize profit, and you’re constrained by the amount of materials you have.

**All the graph algorithms can be done through linear programming instead.**

Linear programming is a much more general framework, and graph problems are a subset of that. 🤯
