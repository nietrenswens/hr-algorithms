IStack<char> stk = new Solution.Stack<char>(4);
stk.Push('a');
stk.Push('b');
Console.WriteLine(stk.Pop());
stk.Push('c');
stk.Push('d');
Console.WriteLine(stk.Pop());
System.Console.WriteLine(stk.Peek());