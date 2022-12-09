class Tree<T> 
{
    private TreeNode<T> root = null;
    private int length = 0;

    public void AddSibling(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        this.length++;
    }

    public void AddChild(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    private TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;

        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Next(), ref traverseStep);
        }

        return ptr;
    }
   
    public TreeNode<string> searcher(TreeNode<string> currentTreeNode, string StackIndex,ref Stack<string> stack)
    {
        TreeNode<string> ptr = currentTreeNode;
        if(ptr.GetValue().Equals(StackIndex) )
        {
            for(int num = 0; num<stack.GetLength();num++)
            {
                Console.WriteLine(stack.Get(num));
            }
        }
        if(currentTreeNode.Child() != null)
        {
                stack.Push(ptr.GetValue()); 
                ptr = this.searcher(currentTreeNode.Child(),StackIndex,ref stack);
                if(stack.GetLength() > 0 )
                {
                    stack.Pop();
                }
        }

        if(currentTreeNode.Next() != null)
        {
            ptr = this.searcher(currentTreeNode.Next(),StackIndex,ref stack);
        }

        return ptr;
    }

}