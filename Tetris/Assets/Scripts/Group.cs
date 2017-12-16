using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid = UnityEngine.Grid;

public class Group : MonoBehaviour
{

    public float blockSize = 0.65f;

    float mostRecentFall = 0f;

    float lastDrop = 0f;

    public float dropTime = 1000000f;

    public string gameOverString = "Game over!";

    public GameObject test;

    public GameObject[] toDestroy;

    private int posx, posy;

    private bool inGrid() //Checks for each child of a tetromino whether it is still in the grid
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = child.position;
            if (!inBorder(pos))
            {
                return false;
            }

            //Formula for position (-1.85 -> 1.85, 4 -> -3.8)
            //x: pos = (10/3.7)x + (10 - 18.5/3.7)
            //y: pos = -(80/7.8)x + (20 - 80/7.8)
            //TODO: FIX FORMULA OF Y
            int posx = (int)((10 / 3.7) * pos.x + (10 - 18.5 / 3.7));
            int posy = (int)((-7.8 / 80) * pos.y + (20 - 80 / 7.8));
            Debug.Log(posx + ", " + posy);

            if (GridClass.grid[posx, posy] != null && GridClass.grid[posx, posy].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    private static bool inBorder(Vector2 posGroup) //Checks whether block is in grid
    {
        return ((float)posGroup.x >= -1.85 && (float)posGroup.x <=1.85 && (float)posGroup.y >= -4.2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-blockSize, 0, 0);
            if (!inGrid())
            {
                transform.position += new Vector3(blockSize, 0, 0);
            }
            else
            {
                //updateGrid();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(blockSize, 0, 0);
            if (!inGrid())
            {
                transform.position += new Vector3(-blockSize, 0, 0);
            }
            else
            {
                //updateGrid();
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            transform.Rotate(0, 0, -90);
            if (!inGrid())
            {
                transform.Rotate(0, 0, 90);
            }
            else
            {
                //updateGrid();
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(0, 0, 90);
            if (!inGrid())
            {
                transform.Rotate(0, 0, -90);
            }
            else
            {
                //updateGrid();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Time.time - lastDrop >= dropTime)
        {
            transform.position += new Vector3(0, -blockSize, 0);
            if (!inGrid())
            {
                transform.position += new Vector3(0, blockSize, 0);
                enabled = false;
                FindObjectOfType<Generator>().generateNextTetromino();
            }
            else
            {
                //updateGrid();
            }
            lastDrop = Time.time;
            Debug.Log("Dropped!");
        }

    }

    private void updateGrid()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (GridClass.grid[j, i] != null && GridClass.grid[j, i].parent == transform)
                {
                    GridClass.grid[j, i] = null;
                }
            }
        }

        foreach (Transform child in transform)
        {
            Vector2 pos = child.position;
            if (pos.y < 5)
            {
                GridClass.grid[posx, posy] = child;
            }
        }
    }
}
