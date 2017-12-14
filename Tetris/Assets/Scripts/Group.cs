using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{

    public float blockSize = 0.65f;

    float mostRecentFall = 0f;

    float lastDrop = 0f;

    public float dropTime = 0.75f;

    public string gameOverString = "Game over!";

    public GameObject test;

    public GameObject[] toDestroy;

    void Start()
    {
        //    if (!checkForValidGridPosition())
        //    {
        //        Debug.Log(gameOverString);
        //        Destroy(gameObject);
        //    }
        //}

        //bool checkForValidGridPosition()
        //{
        //    foreach (Transform block in transform)
        //    {
        //        Vector2 vector = Grid.roundOff(block.position);
        //        if (!Grid.inGrid(vector))
        //        {
        //            return false;
        //        }

        //        if (Grid.grid[(int)vector.x, (int)vector.y] != null && Grid.grid[(int)vector.x, (int)vector.y].parent != transform)
        //        {
        //            return false;
        //        } 
        //    }
        //    return true;
    }

    void drawGrid()
    {
        //for (int y = 0; y < Grid.height; ++y)
        //{
        //    for (int x = 0; x < Grid.width; ++x)
        //    {
        //        if (Grid.grid[x, y] != null)
        //        {
        //            if (Grid.grid[x, y].parent == transform)
        //            {
        //                Grid.grid[x, y] = null;
        //            }

        //        }
        //    }
        //}

        //foreach (Transform block in transform)
        //{

        //    foreach (GameObject erase in toDestroy)
        //    {
        //        Destroy(erase);
        //    }
        //    toDestroy = GameObject.FindGameObjectsWithTag("test");
        //    Vector2 vector = Grid.roundOff(block.position);
        //    Grid.grid[(int)vector.x, (int)vector.y] = block;
        //    Instantiate(test, block.position, Quaternion.identity);

        //}
    }

    private bool inGrid() //Checks for each child of a tetromino whether it is still in the grid
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = child.position;
            if (!inBorder(pos))
            {
                return false;
            }
        }
        return true;
    }

    private static bool inBorder(Vector2 posGroup) //Checks whether block is in grid
    {
        return ((float)posGroup.x >= -3.6 && (float)posGroup.x <=3.6 && (float)posGroup.y >= -4.2);
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
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(blockSize, 0, 0);
            if (!inGrid())
            {
                transform.position += new Vector3(-blockSize, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            transform.Rotate(0, 0, -90);
            if (!inGrid())
            {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(0, 0, 90);
            if (!inGrid())
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Time.time - lastDrop >= dropTime)
        {
            transform.position += new Vector3(0, -blockSize, 0);
            if (!inGrid())
            {
                transform.position += new Vector3(0, blockSize, 0);
            }
            lastDrop = Time.time;
        }
        //       if (Input.GetKeyDown(KeyCode.A))
        //       {
        //           transform.position += new Vector3(-blockSize, 0, 0);
        //           if (checkForValidGridPosition())
        //           {
        //               drawGrid();
        //           }
        //           else
        //           {
        //               transform.position += new Vector3(blockSize, 0, 0);
        //           }
        //       }
        //       else if (Input.GetKeyDown(KeyCode.D))
        //       {
        //           transform.position += new Vector3(blockSize, 0, 0);
        //           if (checkForValidGridPosition())
        //           {
        //               drawGrid();
        //           }
        //           else
        //           {
        //               transform.position += new Vector3(-blockSize, 0, 0);
        //           }
        //       }
        //       else if (Input.GetKeyDown(KeyCode.O))
        //       {
        //           transform.Rotate(0, 0, -90);
        //           if (checkForValidGridPosition())
        //           {
        //               drawGrid();
        //           }
        //           else
        //           {
        //               transform.Rotate(0, 0, 90);
        //           }

        //       }
        //       else if (Input.GetKeyDown(KeyCode.P))
        //       {
        //           transform.Rotate(0, 0, 90);
        //           if (checkForValidGridPosition())
        //           {
        //               drawGrid();
        //           }
        //           else
        //           {
        //               transform.Rotate(0, 0, -90);
        //           }
        //       }
        //       else if (Input.GetKeyDown(KeyCode.S) || Time.time - lastDrop >= dropTime)
        //       {
        //           transform.position += new Vector3(0, -blockSize, 0);
        //           if (checkForValidGridPosition())
        //           {
        //               drawGrid();
        //           }
        //           else
        //           {
        //               transform.position += new Vector3(0, blockSize, 0);
        //               Grid.removeFullRows();
        //               GameObject.FindObjectOfType<Generator>().generateNextTetromino();
        //               enabled = false;
        //           }
        //           lastDrop = Time.time;
        //       }
        //}


    }
}
