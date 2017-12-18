using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridClass : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];

    public static void printArray()
    {
        string arrayOutput = "";

        int iMax = width - 1;
        int jMax = height - 1;
        for (int j = jMax; j >= 0; j--)
        {
            for (int i = 0; i <= iMax; i++)
            {
                if (grid[i, j] == null)
                {
                    arrayOutput += "N";
                }
                else
                {
                    arrayOutput += "X";
                }
                
            }
            arrayOutput += "\n";
        }
        GameObject.Find("MyArray").GetComponent<Text>().text = arrayOutput;
    }
}
