using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day12
    {
        //Unfinished
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day12.txt";

            string[] input = File.ReadAllLines(path);

            FindCaves(input);
        }

        private void FindCaves(string[] input)
        {
            Graph caveTree = new Graph();
            var myDict = new Dictionary<string,int>();
            foreach(string line in input)
            {
                string[] caves = line.Split("-");

                if (!myDict.ContainsKey(caves[0]))
                {
                    caveTree.AddNode(new GraphNode(caves[0]));
                    myDict.Add(caves[0], 0);
                }

                if (!myDict.ContainsKey(caves[1]))
                {
                    caveTree.AddNode(new GraphNode(caves[1]));
                    myDict.Add(caves[1], 0);
                }

                caveTree.AddEdges(caves[0], caves[1]);
            }

            GraphNode start = null;
            GraphNode end = null;
;
            foreach (GraphNode i in caveTree.nodes)
            {
                if (i.nodeName == "start")
                {
                    start = i;
                }

                if (i.nodeName == "end")
                {
                    end = i;
                }
            }
            PrintAllPath(caveTree, start, end);
        }

        private void PrintAllPath(Graph graph,GraphNode start, GraphNode end)
        {
            var myDict = new Dictionary<string, bool>();

            List<string> pathList = new List<string>();

            pathList.Add(start.nodeName);
            bool isPartOne = true;
            PrintAllPathsUtil(start, end, myDict, pathList,isPartOne);
        }
        private void PrintAllPathsUtil(GraphNode start, GraphNode end,Dictionary<string,bool> myDict, List<string> currentPath,bool checker)
        {
            bool beenToSmallCave = checker;
            if (start == end)
            {
                Console.WriteLine(string.Join(" ", currentPath));
                return;
            }

            if (!myDict.ContainsKey(start.nodeName))
            {
                myDict.Add(start.nodeName, false);
            }

            if (start.caveType != "bigCave")
            {
                myDict[start.nodeName] = true;
            }

            if (start.caveType == "smallCave" && beenToSmallCave == false)
            {
                myDict[start.nodeName] = false;
                beenToSmallCave = true;
            }

            foreach(GraphNode p in start.neighbors)
            {
                if (!myDict.ContainsKey(p.nodeName))
                {
                    currentPath.Add(p.nodeName);
                    PrintAllPathsUtil(p, end, myDict, currentPath,beenToSmallCave);

                    currentPath.Remove(p.nodeName);
                }
                else if (myDict[p.nodeName] == false)
                {
                    currentPath.Add(p.nodeName);
                    PrintAllPathsUtil(p, end, myDict, currentPath,beenToSmallCave);

                    currentPath.Remove(p.nodeName);
                }

            }

            myDict[start.nodeName] = false;
        }

        private class GraphNode
        {
            //New Node add neighbors
            public string nodeName;
            public string caveType = null;
            public bool hasBeen = false;
            public List<GraphNode> neighbors = new List<GraphNode>();


            public GraphNode(string value)
            {
                nodeName = value;
                neighbors = new List<GraphNode>();

                if (value == "start" || value == "end")
                {
                    caveType = value;
                }
                else if (Char.IsUpper(value, 0))
                {
                    caveType = "bigCave";
                }
                else if (Char.IsLower(value, 0))
                {
                    caveType = "smallCave";
                }
            }

            public bool AddNeighbor(GraphNode neighbor)
            {
                if (neighbors.Contains(neighbor))
                {
                    return false;
                }
                else
                {
                    neighbors.Add(neighbor);
                    return true;
                }
            }

            public GraphNode ReturnNode(string name)
            {
                if (nodeName == name)
                {
                    return this;
                }

                return null;
            }
        }

        private class Graph
        {
            public List<GraphNode> nodes = new List<GraphNode>();

            public Graph()
            {

            }

            public bool AddNode(GraphNode node)
            {
                if (nodes.Contains(node))
                {
                    return false;
                }
                else
                {
                    nodes.Add(node);
                    return true;
                }
            }

            public bool AddEdges(string value1, string value2)
            {
                GraphNode node1 = null;
                GraphNode node2 = null;
                foreach(GraphNode i in nodes)
                {
                    if (i.nodeName == value1)
                    {
                        node1 = i;
                    }

                    if (i.nodeName == value2)
                    {
                        node2 = i;
                    }
                }

                if (node1 == null || node2 == null)
                {
                    return false;
                }
                else if (node1.neighbors.Contains(node2))
                {
                    return false;
                }
                else
                {
                    node1.AddNeighbor(node2);
                    node2.AddNeighbor(node1);
                    return true;
                }
            }
        }
    }
}
