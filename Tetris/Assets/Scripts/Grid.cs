using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];

    //public static Vector2 roundOff(Vector2 vector)
    //{
    //    return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    //}

    //public static bool inGrid(Vector2 pos)
    //{
    //    return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    //}

    //public static void removeRow(int y)
    //{
    //    for (int x = 0; x < width; ++x)
    //    {
    //        Destroy(grid[x, y].gameObject);
    //        grid[x, y] = null;
    //    }
    //}

    //public static void lowerRow(int y)
    //{
    //    for (int x = 0; x < width; ++x)
    //    {
    //        if (grid[x,y] = null)
    //        {
    //            grid[x, y - 1] = grid[x, y];
    //            grid[x, y] = null;

    //            grid[x, y - 1].position += new Vector3(0, -1, 0);
    //        }
    //    }
    //}
    
    //public static void repeatLowerRow(int y)
    //{
    //    for (int i = y; i < height; ++i)
    //    {
    //        lowerRow(i);
    //    }
    //}

    //public static bool checkFullRow(int y)
    //{
    //    for (int x = 0; x < width; ++x)
    //    {
    //        if (grid[x,y] == null)
    //        {
    //            return false;
    //        }
           
    //    }
    //    return true;
    //}

    //public static void removeFullRows()
    //{
    //    for (int y = 0; y < height; ++y)
    //    {
    //        if (checkFullRow(y))
    //        {
    //            removeRow(y);
    //            repeatLowerRow(y + 1);
    //            --y;
    //        }
    //    }
    //}
}
