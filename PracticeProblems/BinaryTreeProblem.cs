using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProblems
{
    public class BinaryTreeProblem
    {
        /// <summary>
        /// Problem: Given a binary tree , design an algorithm to create 
        /// LinkedList for nodes at each Depth
        /// BFS approach to check nodes at each depth 
        /// if depth is i, add children of nodes at i-1;
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public ArrayList CreateLinkedListByDepth(TreeNode root)
        {
            LinkedList<TreeNode> current = new LinkedList<TreeNode>(); ;
            ArrayList result = new ArrayList();

            if(root != null)
            {
                current.AddLast(root);
            }

            while(current.Count() > 0)
            {
                result.Add(current);
                LinkedList<TreeNode> parents = current;

                current = new LinkedList<TreeNode>();

                foreach(var node in parents)
                {
                    if(node.Left != null)
                    {
                        current.AddLast(node.Left);
                    }

                    if(node.Right != null)
                    {
                        current.AddLast(node.Right);
                    }
                }
            }

            return result;
        }

    }
}
