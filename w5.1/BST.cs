
namespace Solution;

public class BST<T> : IBST<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    public void InsertIterative(T value)
    {
        TreeNode<T>? current = Root;
        if (current == null)
        {
            Root = new TreeNode<T>(value);
        }
        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(value, current);
                    return;
                }
                current = current.Left;
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value, current);
                    return;
                }
                current = current.Right;
            }
        }
    }

    private void Insert(T value, TreeNode<T>? node)
    {
        // case Root is null
        if (Root == null)
        {
            Root = new TreeNode<T>(value);
            return;
        }
        if (node == null) return;
        // right child
        if (value.CompareTo(node.Value) > 0)
        {
            if (node.Right != null)
                Insert(value, node.Right);
            else
            {
                node.Right = new TreeNode<T>(value, node);
                return;
            }
        }
        else
        {
            if (node.Left != null)
                Insert(value, node.Left);
            else
            {
                node.Left = new TreeNode<T>(value, node);
                return;
            }
        }
        // left child

    }

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null)
            return string.Empty;
        return $"{currNode.Value} {PreOrderTraversal(currNode.Left)}{PreOrderTraversal(currNode.Right)}";
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null)
            return string.Empty;
        return $"{InOrderTraversal(currNode.Left)}{currNode.Value} {InOrderTraversal(currNode.Right)}";
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null)
            return string.Empty;
        return $"{PostOrderTraversal(currNode.Left)}{PostOrderTraversal(currNode.Right)}{currNode.Value} ";
    }
    #endregion

    public bool Contains(T value) => Search(Root, value) != null;

    private TreeNode<T>? Search(TreeNode<T>? node, T value)
    {
        // node does not exist
        if (node == null)
            return default;
        // value in the node is the same we are looking for
        if (node.Value.CompareTo(value) == 0)
            return node;
        // value in the node is smaller than the one we are looking for
        if (node.Value.CompareTo(value) < 0)
            return Search(node.Right, value);
        else
            // value in the node is bigger than the one we are looking for
            return Search(node.Left, value);

    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(BST<T>? tree, T value)
    {
        // Find the node to delete
        if (tree == null || tree.Root == null)
            return false;
        TreeNode<T>? nodeToDelete = Search(tree.Root, value);
        if (nodeToDelete == null)
            return false;
        
        // Node is root, and has no children
        if (nodeToDelete == tree.Root)
        {
            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                tree.Root = null;
                return true;
            }
        }

        return delete(tree.Root, nodeToDelete);
    }

    private bool delete(TreeNode<T>? root, TreeNode<T> nodeToDelete)
    {
        // CASE 1 : LEAF
        if (nodeToDelete.Left == null && nodeToDelete.Right == null)
        {
            if (nodeToDelete.Parent?.Left == nodeToDelete)
                nodeToDelete.Parent.Left = null;
            else if (nodeToDelete.Parent?.Right == nodeToDelete)
                nodeToDelete.Parent.Right = null;
            else
                return false;
            return true;
        }

        // CASE 2 : ONE CHILD
        if (nodeToDelete.Left == null || nodeToDelete.Right == null)
        {
            var child = nodeToDelete.Left == null ? nodeToDelete.Right : nodeToDelete.Left;
            var parent = nodeToDelete.Parent;
            if (nodeToDelete == root)
            {
                child.Parent = default;
                Root = child;
                return true;
            }
            child.Parent = nodeToDelete.Parent;
            if (parent.Left == nodeToDelete)
                parent.Left = child;
            else
                parent.Right = child;
            return true;
        }
        // CASE 3 : TWO CHILDREN

        // find inordersucc == smallest element of right subtree
        var soonToBeParent = findInOrderSucc(nodeToDelete);

        // copy value to nodeToDelete
        nodeToDelete.Value = soonToBeParent.Value;
        // call recursively delete on inordersucc 
        return delete(root, soonToBeParent);
    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? findInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }

    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> parent)
    {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        throw new NotImplementedException();
    }
    #endregion
}

