using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];
}
