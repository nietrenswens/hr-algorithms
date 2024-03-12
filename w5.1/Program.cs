
using System.Runtime.InteropServices;
using Solution;

var bst = new BST<int>();
bst.Insert(3);
bst.Insert(2);
bst.Insert(5);

Console.WriteLine(bst.InOrderTraversal());
Console.WriteLine(bst.Remove(3));
Console.WriteLine(bst.InOrderTraversal());
System.Console.WriteLine(bst.PostOrderTraversal());