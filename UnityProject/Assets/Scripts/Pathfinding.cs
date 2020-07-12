using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Assertions.Must;

public class Pathfinding 
{
    private static Pathfinding instance;
    public static Pathfinding Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Pathfinding();
            }
            return instance;
        }
    }

    private LayerMask wallMask;
    private const int CostStright = 10;
    private const int CostDiagonal = 14;

    SearchNode[,] nodes;
    private List<SearchNode> openList;
    private List<SearchNode> closedList;

    public int height;
    public int width;

    public void InitGrid(int width, int height)
    {
        wallMask = GameObject.Find("LevelGen").GetComponent<LevelGen>().wallMask;
        nodes = new SearchNode[width, height];

        this.height = height;
        this.width = width;
        //Debug.Log(height);
        //Debug.Log(width);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SearchNode node = new SearchNode(x, y, Physics2D.OverlapCircle(new Vector3(x, y) + Vector3.one / 2, 0.2f, wallMask) ? NodeType.unwalkable : NodeType.walkable);
                nodes[x, y] = node;
            }
        }
    }

    public List<SearchNode> FindPath(int startX, int startY, int endX, int endY)
    {
        SearchNode startNode = nodes[startX, startY];
        SearchNode endNode = nodes[endX, endY];


        if (startX < 0 || startX >= width || startY < 0 || startY > height ||
            endX < 0 || endX >= width || endY < 0 || endY > height)
        {
            return null;
        }

        if (startNode.type == NodeType.unwalkable || endNode.type == NodeType.unwalkable)
        {
            return null;
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                SearchNode node = nodes[i, j];
                node.gScore = int.MaxValue;
                node.ReturnF();
                node.PreviousNode = null;
            }
        }

        closedList = new List<SearchNode>();
        openList = new List<SearchNode>();

        startNode.PreviousNode = null;
        startNode.fScore = 0;
        startNode.gScore = 0;
        startNode.hScore = 0;

        openList.Add(startNode);

        while (openList.Count > 0)
        {
            SearchNode CurrentNode = GetLowestFNode(openList);
            if (CurrentNode == endNode)
            {
                List<SearchNode> list = ReturnPath(endNode);
                return GetTilePath(list);
            }

            openList.Remove(CurrentNode);
            closedList.Add(CurrentNode);

            foreach (SearchNode neighbourNode in NeighbourList(CurrentNode))
            {
                //Vector3 NodePosition = new Vector3(neighbourNode.x, neighbourNode.y);
                //Debug.Log(NodePosition);
                if (closedList.Contains(neighbourNode) || neighbourNode.type == NodeType.unwalkable)
                {
                    continue;
                }
                int tentative_gScore = CurrentNode.gScore + GetDistance(CurrentNode, neighbourNode);
                if (tentative_gScore < neighbourNode.gScore)
                {
                    neighbourNode.PreviousNode = CurrentNode;
                    neighbourNode.gScore = tentative_gScore;
                    neighbourNode.hScore = GetDistance(neighbourNode, endNode);
                    neighbourNode.ReturnF();
                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
        return null;
    }

    private List<SearchNode> GetTilePath(List<SearchNode> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i + 1].x - list[i].x ==1 && list[i + 1].y - list[i].y == 1 && nodes[list[i].x + 1, list[i].y].type == NodeType.unwalkable)
            {
                list.Insert(i + 1, new SearchNode(list[i].x, list[i].y + 1, NodeType.walkable));
            }
            if (list[i + 1].x - list[i].x == -1 && list[i + 1].y - list[i].y == 1 && nodes[list[i].x, list[i].y + 1].type == NodeType.unwalkable)
            {
                list.Insert(i + 1, new SearchNode(list[i].x - 1, list[i].y, NodeType.walkable));
            }
            if (list[i + 1].x - list[i].x == 1 && list[i + 1].y - list[i].y == 1 && nodes[list[i].x - 1, list[i].y].type == NodeType.unwalkable)
            {
                list.Insert(i + 1, new SearchNode(list[i].x, list[i].y - 1, NodeType.walkable));
            }
            if (list[i + 1].x - list[i].x == -1 && list[i + 1].y - list[i].y == 1 && nodes[list[i].x, list[i].y - 1].type == NodeType.unwalkable)
            {
                list.Insert(i + 1, new SearchNode(list[i].x + 1, list[i].y, NodeType.walkable));
            }
        }
        return list;
    }

    private List<SearchNode> NeighbourList(SearchNode CurrentNode)
    {
        List<SearchNode> neighbourList = new List<SearchNode>();

        if (CurrentNode.y - 1 >= 0)
        {
            neighbourList.Add(nodes[CurrentNode.x, CurrentNode.y - 1]);
        }
        if (CurrentNode.y + 1 < height)
        {
            neighbourList.Add(nodes[CurrentNode.x, CurrentNode.y + 1]);
        }
        if (CurrentNode.x - 1 >= 0)
        {
            neighbourList.Add(nodes[CurrentNode.x - 1, CurrentNode.y]);
            if (CurrentNode.y + 1 < height)
            {
                neighbourList.Add(nodes[CurrentNode.x - 1, CurrentNode.y + 1]);
            }
            if (CurrentNode.y - 1 >= 0)
            {
                neighbourList.Add(nodes[CurrentNode.x - 1, CurrentNode.y - 1]);
            }
        }
        if (CurrentNode.x + 1 < width)
        {
            neighbourList.Add(nodes[CurrentNode.x + 1, CurrentNode.y]);
            if (CurrentNode.y + 1 < height)
            {
                neighbourList.Add(nodes[CurrentNode.x + 1, CurrentNode.y + 1]);
            }
            if (CurrentNode.y - 1 >= 0)
            {
                neighbourList.Add(nodes[CurrentNode.x + 1, CurrentNode.y - 1]);
            }
        }
        return neighbourList;
    }

    private List<SearchNode> ReturnPath(SearchNode endNode)
    {
        List<SearchNode> path = new List<SearchNode>();
        path.Add(endNode);
        SearchNode currentNode = endNode;
        while (currentNode.PreviousNode != null)
        {
            path.Add(currentNode.PreviousNode);
            currentNode = currentNode.PreviousNode;
        }
        path.Reverse();
        return path;
    }

    private SearchNode GetLowestFNode(List<SearchNode> NodeList)
    {
        SearchNode LowestFNode = NodeList[0];
        for (int i = 0; i < NodeList.Count; i++)
        {
            if (NodeList[i].fScore < LowestFNode.fScore)
            {
                LowestFNode = NodeList[i];
            }
        }
        return LowestFNode;
    }

    private int GetDistance(SearchNode node_1, SearchNode node_2)
    {
        int xDis = Mathf.Abs(node_1.x - node_2.x);
        int yDis = Mathf.Abs(node_1.y - node_2.y);
        int reamaining = Mathf.Abs(xDis - yDis);
        return CostDiagonal * Mathf.Min(xDis, yDis) + CostStright * reamaining;
    }
}
