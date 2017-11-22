using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

    private const float blockSize = 0.65f;

    bool checkForValidGridPosition()
    {
        foreach (Transform block in transform)
        {
            Vector2 vector = Grid.roundOff(block.position);
            if (!Grid.inGrid(vector))
            {
                return false;
            }

            if (Grid.grid[(int)vector.x, (int)vector.y] != null && Grid.grid[(int)vector.x, (int)vector.y].parent != transform)
            {
                return false;
            } 
        }
        return true;
    }

    void drawGrid()
    {
        for (int y = 0; y < Grid.height; ++y)
        {
            for (int x = 0; x < Grid.width; ++x)
            {
                if (Grid.grid[x, y] != null)
                {
                    if (Grid.grid[x, y].parent == transform)
                    {
                        Grid.grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform block in transform)
        {
            Vector2 vector = Grid.roundOff(block.position);
            Grid.grid[(int)vector.x, (int)vector.y] = block;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-blockSize, 0, 0);
            if (checkForValidGridPosition())
            {
                drawGrid();
            }
            else
            {
                transform.position += new Vector3(blockSize, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(blockSize, 0, 0);
            if (checkForValidGridPosition())
            {
                drawGrid();
            }
            else
            {
                transform.position += new Vector3(-blockSize, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            transform.Rotate(0, 0, -90);
            if (checkForValidGridPosition())
            {
                drawGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }

        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(0, 0, 90);
            if (checkForValidGridPosition())
            {
                drawGrid();
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -blockSize, 0);
            if (checkForValidGridPosition())
            {
                drawGrid();
            }
            else
            {
                transform.position += new Vector3(0, blockSize, 0);
                Grid.removeFullRows();
                GameObject.FindObjectOfType<Generator>().generateNextTetromino();
                enabled = false;
            }
        }
	}
}
