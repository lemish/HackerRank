using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Search
{
    /// <summary>
    /// Swap Nodes in Binary Tree
    /// <see href="https://www.hackerrank.com/challenges/swap-nodes-algo/"/>
    /// </summary>
    public class SwapNodes
    {
        public static int[][] GetSwapNodes(int[][] treeNodes, int[] queries)
        {
            var isTreeNodesEmpty = treeNodes == null || !treeNodes.Any();
            var isQueriesEmpty = queries == null || !queries.Any();
            if (isTreeNodesEmpty || isQueriesEmpty)
            {
                return new int[0][];
            }

            var treeNodesPerDepth = GetTreeNodesPerDepth(treeNodes);
            var nodesPerQuery = new int[queries.Length][];

            var index = 0;
            foreach (var depthSwapLevel in queries)
            {
                var depthsForSwap = treeNodesPerDepth.Keys.Where(x => x % depthSwapLevel == 0);

                foreach (var depth in depthsForSwap)
                {
                    treeNodesPerDepth[depth].ForEach(x => x.SwapLeftAndRightNodes());
                }

                var rootNode = treeNodesPerDepth.First().Value.First();
                var nodes = GetNodesInTraversalOrder(rootNode);
                nodesPerQuery[index] = nodes;
                index++;
            }

            return nodesPerQuery;
        }

        private static int[] GetNodesInTraversalOrder(TreeNode rootNode)
        {
            var listOfNumbers = new List<int>();

            var canMove = true;
            var parentNodeStack = new Stack<TreeNode>();
            var visitedNodes = new HashSet<TreeNode>();

            var node = rootNode;

            while (canMove)
            {
                if (node.LeftNode != null && !visitedNodes.Contains(node.LeftNode))
                {
                    parentNodeStack.Push(node);

                    node = node.LeftNode;
                    continue;
                }
                else if (!visitedNodes.Contains(node))
                {
                    visitedNodes.Add(node);

                    listOfNumbers.Add(node.Value);
                }

                if (node.RightNode != null && !visitedNodes.Contains(node.RightNode))
                {
                    parentNodeStack.Push(node);

                    node = node.RightNode;
                    continue;
                }
                else if (parentNodeStack.Any())
                {
                    node = parentNodeStack.Pop();
                }
                else
                {
                    canMove = false;
                }
            }

            return listOfNumbers.ToArray();
        }

        private static Dictionary<int, List<TreeNode>> GetTreeNodesPerDepth(int[][] treeNodes)
        {
            const int depthRoot = 1;
            const int rootValue = 1;
            var nodesPerDepth = new Dictionary<int, List<TreeNode>>
            {
                { depthRoot, new List<TreeNode> { new TreeNode { Value = rootValue } } }
            };

            var treeNodeIndex = 0;
            for (var depth = depthRoot + 1; treeNodeIndex < treeNodes.Length; depth++)
            {
                nodesPerDepth.Add(depth, new List<TreeNode>());

                var parentDepth = depth - 1;
                var parentNodes = nodesPerDepth[parentDepth];
                for (var parentNodeIndex = 0; parentNodeIndex < parentNodes.Count; parentNodeIndex++)
                {
                    var parentNode = parentNodes[parentNodeIndex];

                    const int isEmptyFlag = -1;
                    if (parentNode.Value == isEmptyFlag)
                    {
                        continue;
                    }

                    const int leftNodeIndex = 0;
                    const int rightNodeIndex = 1;

                    var treeNode = treeNodes[treeNodeIndex];

                    if (treeNode[leftNodeIndex] != isEmptyFlag)
                    {
                        parentNode.LeftNode = new TreeNode { Value = treeNode[leftNodeIndex] };
                        nodesPerDepth[depth].Add(parentNode.LeftNode);
                    }

                    if (treeNode[rightNodeIndex] != isEmptyFlag)
                    {
                        parentNode.RightNode = new TreeNode { Value = treeNode[rightNodeIndex] };
                        nodesPerDepth[depth].Add(parentNode.RightNode);
                    }

                    treeNodeIndex++;
                }
            }

            return nodesPerDepth;
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode LeftNode { get; set; }
            public TreeNode RightNode { get; set; }

            public void SwapLeftAndRightNodes()
            {
                if (LeftNode == RightNode)
                {
                    return;
                }

                var rightNode = RightNode;
                RightNode = LeftNode;
                LeftNode = rightNode;
            }
        }
    }
}