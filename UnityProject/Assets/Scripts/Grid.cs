using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<GridObject> 
{
    private int width;
    private int height;
    private Vector3 offset;
    //private GridObject[,] gridList;
    private int[,] gridList;
    public TextMesh[,] showText;

    public Grid(int width, int height, Vector3 offset)
    {
        this.width = width;
        this.height = height;
        this.offset = offset;
        gridList = new int[width, height];
        showText = new TextMesh[width, height];

        for (int x = 0; x < gridList.GetLength(0); x++)
        {
            for (int y = 0; y < gridList.GetLength(1); y++)
            {
                showText[x, y] = TextGen((x + "," + y).ToString(), new Vector3(x + 0.5f, y + 0.5f) + offset);
                Debug.DrawLine(new Vector3(x, y) + offset, new Vector3(x, y + 1) + offset, Color.red, 10f);
                Debug.DrawLine(new Vector3(x, y) + offset, new Vector3(x + 1, y) + offset, Color.red, 10f);
            }
        }
        Debug.DrawLine(new Vector3(0, height) + offset, new Vector3(width, height) + offset, Color.red, 50f);
        Debug.DrawLine(new Vector3(width, 0) + offset, new Vector3(width, height) + offset, Color.red, 50f);
    }

    //public Grid(int width, int height, Vector3 offset, Func<Grid<GridObject>, int, int , GridObject> newGridObject)
    //{
    //    this.width = width;
    //    this.height = height;
    //    this.offset = offset;
    //    gridList = new GridObject[width, height];
    //    showText = new TextMesh[width, height];

    //    for (int i = 0; i < gridList.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < gridList.GetLength(1); j++)
    //        {
    //            gridList[i, j] = newGridObject(this, i, j);

    //            showText[i,j] = TextGen(gridList[i, j]?.ToString(), new Vector3(i + 0.5f, j + 0.5f) + offset);
    //            Debug.DrawLine(new Vector3(i, j) + offset, new Vector3(i, j + 1) + offset, Color.red, 10f);
    //            Debug.DrawLine(new Vector3(i, j) + offset, new Vector3(i + 1, j) + offset, Color.red, 10f);
    //        }
    //    }
    //    Debug.DrawLine(new Vector3(0, height) + offset, new Vector3(width, height) + offset, Color.red, 50f);
    //    Debug.DrawLine(new Vector3(width, 0) + offset, new Vector3(width, height) + offset, Color.red, 50f);

    //}

    public static TextMesh TextGen(string text, Vector3 position)
    {
        GameObject gameObject = new GameObject("Grid Num", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.position = position;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.fontSize = 5;
        textMesh.color = Color.red;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = 2;
        return textMesh;
    }

    //public GridObject GetObject(int x, int y)
    //{
    //    if (x >= 0 && y >= 0 && x < width && y < height)
    //    {
    //        return gridList[x, y];
    //    }
    //    else
    //    {
    //        Debug.Log("test");
    //        return default(GridObject);
    //    }
    //}

    public void GetValue(int x, int y, out int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
             value = gridList[x, y];
        }
        else
        {
            value = 0;
        }
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x);
        y = Mathf.FloorToInt(worldPosition.y);
    }

    public int ReturnWidth()
    {
        return width;
    }

    public int ReturnHeight()
    {
        return height;
    }
}