using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Settings")]
    public int width = 10;             // Maze width (number of cells)
    public int height = 10;            // Maze height (number of cells)
    public float cellSize = 10f;       // Size of each cell
    public float wallHeight = 100f;    // Height of the walls

    [Header("Wall Prefab")]
    public GameObject wallPrefab;      // Prefab for wall sections

    private bool[,] visited;           // Tracks visited cells
    private GameObject[,] horizontalWalls; // Horizontal walls
    private GameObject[,] verticalWalls;   // Vertical walls

    private System.Random rand;

    void Start()
    {
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        rand = new System.Random();

        // Initialize the visited array
        visited = new bool[width, height];

        // Initialize wall arrays
        horizontalWalls = new GameObject[width, height + 1]; // Extra row for bottom walls
        verticalWalls = new GameObject[width + 1, height];   // Extra column for right walls

        // Create the walls for the maze
        CreateWalls();

        // Start maze generation using DFS from the top-left corner
        BuildMazeRecursive(0, 0);
    }

    private void CreateWalls()
    {
        // Create horizontal and vertical walls
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y <= height; y++)
            {
                // Horizontal walls
                Vector3 hPosition = new Vector3(x * cellSize, wallHeight / 2f, y * cellSize - cellSize / 2);
                horizontalWalls[x, y] = Instantiate(wallPrefab, hPosition, Quaternion.identity);
                horizontalWalls[x, y].transform.localScale = new Vector3(cellSize, wallHeight, 1);
            }
        }

        for (int x = 0; x <= width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Vertical walls
                Vector3 vPosition = new Vector3(x * cellSize - cellSize / 2, wallHeight / 2f, y * cellSize);
                verticalWalls[x, y] = Instantiate(wallPrefab, vPosition, Quaternion.Euler(0, 90, 0));
                verticalWalls[x, y].transform.localScale = new Vector3(cellSize, wallHeight, 1);
            }
        }
    }

    private void BuildMazeRecursive(int x, int y)
    {
        visited[x, y] = true;

        // Possible directions (Up, Down, Left, Right)
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        Shuffle(directions);

        foreach (var dir in directions)
        {
            int nx = x + dir.x;
            int ny = y + dir.y;

            // Check if the next cell is within bounds and unvisited
            if (nx >= 0 && nx < width && ny >= 0 && ny < height && !visited[nx, ny])
            {
                // Remove the wall between the current cell and the next cell
                if (dir == Vector2Int.up)
                    Destroy(horizontalWalls[x, y + 1]); // Remove top wall
                else if (dir == Vector2Int.down)
                    Destroy(horizontalWalls[x, y]);    // Remove bottom wall
                else if (dir == Vector2Int.left)
                    Destroy(verticalWalls[x, y]);      // Remove left wall
                else if (dir == Vector2Int.right)
                    Destroy(verticalWalls[x + 1, y]);  // Remove right wall

                // Recurse into the next cell
                BuildMazeRecursive(nx, ny);
            }
        }
    }

    private void Shuffle(Vector2Int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = rand.Next(i, array.Length);
            Vector2Int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}



