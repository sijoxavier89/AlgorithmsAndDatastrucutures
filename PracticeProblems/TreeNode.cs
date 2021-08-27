using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class TreeNode
    {
        public int key;

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int key)
        {
            this.key = key;
        }
    }
}
