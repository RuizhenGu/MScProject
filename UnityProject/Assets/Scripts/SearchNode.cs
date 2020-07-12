using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeType { walkable, unwalkable };
public class SearchNode 
{
    public Grid<SearchNode> grid;
    public int x;
    public int y;

    

    public int gScore;
    public int hScore;
    public int fScore;

    public SearchNode PreviousNode;
    public NodeType type;

    public SearchNode(int x, int y, NodeType type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }

    public void ReturnF()
    {
        fScore = gScore + hScore;
    }
}
