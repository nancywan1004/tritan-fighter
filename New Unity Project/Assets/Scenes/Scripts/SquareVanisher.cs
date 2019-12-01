using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareVanisher : MonoBehaviour
{
    private static int gridWidth = SquareGenerator.gridWidth;
    private static int gridHeight = SquareGenerator.gridHeight;
    private int[,] grid = new int[gridWidth, gridHeight];
    // Use this for initialization
    void Start () {
        for (int i = 0; i < gridWidth; i++) {
            for (int j = 0; j < gridHeight; j++) {
                grid[i, j] = 0;
        }
    }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        destroyNeighbours(this.gameObject, this.gameObject.GetComponent<SpriteRenderer>().color);
    }

    // List<GameObject> populateNeighbours()
    // {
    //     List<GameObject> list = new List<GameObject>();
    //     //If we're at x, y.
    //     //Left one is at x-1,y
    //     GameObject tempObj = GameObject.Find("Tile_" + (x - 1) + "_" + y);
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + (x - 1) + "_" + y + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     //Right one is at x+1,y
    //     tempObj = GameObject.Find("Tile_" + (x + 1) + "_" + y);
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + (x + 1) + "_" + y + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     //Bottom ones are at x,y-1 and x+1,y-1
    //     tempObj = GameObject.Find("Tile_" + x + "_" + (y - 1));
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + x + "_" + (y - 1) + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     tempObj = GameObject.Find("Tile_" + (x + 1) + "_" + (y - 1));
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + (x + 1) + "_" + (y - 1) + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     //Top ones are at x,y+1 and x+1,y+1
    //     tempObj = GameObject.Find("Tile_" + x + "_" + (y + 1));
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + x + "_" + (y + 1) + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     tempObj = GameObject.Find("Tile_" + (x + 1) + "_" + (y + 1));
    //     if (tempObj == null)
    //         Debug.Log("Tile_" + (x + 1) + "_" + (y + 1) + " Does NOT exist");
    //     else
    //         list.Add(tempObj);

    //     return list;
    // }

    private void destroyNeighbours(GameObject curr, Color color)
    {
        string name = curr.name;
        int row = 0, col = 0;

        string string_row = name.Substring(name.IndexOf('[') + 1, 1);
        int.TryParse(string_row, out row);
        string string_col = name.Substring(name.IndexOf(',') + 2, 1);
        int.TryParse(string_col, out col);
        
        int left_col = col - 1;
        int right_col = col + 1;
        int up_row = row - 1;
        int down_row = row + 1;
        
        string left = "Square [" + string_row + ", " + left_col.ToString() + "]";
        string right = "Square [" + string_row + ", " + right_col.ToString() + "]";
        string up = "Square [" + up_row.ToString() + ", " + string_col + "]";
        string down = "Square [" + down_row.ToString() + ", " + string_col + "]";
        Debug.Log("left: " + left + "; right: " + right + "; up: " + up + "; down: " + down);
        List<GameObject> neighbours = new List<GameObject>();
        if (GameObject.Find(left) != null && GameObject.Find(left).GetComponent<SpriteRenderer>().color == color)
        {
            if (grid[row, left_col] == 0 && row >= 0 && left_col >= 0) {
                neighbours.Add(GameObject.Find(left));
                grid[row, left_col] = 1;
            } else {
                return;
            }
            destroyNeighbours(GameObject.Find(left), color);
        }
        if (GameObject.Find(right) != null && GameObject.Find(right).GetComponent<SpriteRenderer>().color == color)
        {
           if (grid[row, right_col] == 0 && row >= 0 && right_col >= 0) {
                neighbours.Add(GameObject.Find(right));
               grid[row, right_col] = 1;
            } else {
                return;
            }
            destroyNeighbours(GameObject.Find(right), color);
        }
        if (GameObject.Find(up) != null && GameObject.Find(up).GetComponent<SpriteRenderer>().color == color)
        {
           if (grid[up_row, col] == 0 && up_row >= 0 && col >= 0) {
                neighbours.Add(GameObject.Find(up));
                grid[up_row, col] = 1;
            } else {
                return;
            }
            destroyNeighbours(GameObject.Find(up), color);
        }
        if (GameObject.Find(down) != null && GameObject.Find(down).GetComponent<SpriteRenderer>().color == color)
        {
           if (grid[down_row, col] == 0 && down_row >= 0 && col >= 0) {
                neighbours.Add(GameObject.Find(down));
               grid[down_row, col] = 1;
            } else {
                return;
            }
           destroyNeighbours(GameObject.Find(down), color);
        }
        Debug.Log(neighbours[0].GetComponent<SpriteRenderer>().color);
        Destroy(this.gameObject);
        Debug.Log("left: " + left + "; neighbour: " + neighbours[0].name);
        foreach (GameObject g in neighbours)
        {
            if (g.GetComponent<SpriteRenderer>().color == color)
            {
                Destroy(g);
            }
        }
        // foreach (GameObject g in neighbours)
        // {
        //     Debug.Log(g.name);
        //     string_row = g.name.Substring(name.IndexOf('[') + 1, 1);
        //     int.TryParse(string_row, out row);
        //     string_col = g.name.Substring(name.IndexOf(',') + 2, 1);
        //     int.TryParse(string_col, out col);
        //     if (grid[row, col] == 1)
        //         return;
        //     grid[row, col] = 1;
        //     if (g.GetComponent<SpriteRenderer>().color == color)
        //     {
        //         Destroy(g);
        //         destroyNeighbours(g, color);
        //     }
        // }        
    }

    // private List<GameObject> getBFS(Graph<GameObject> graph, GameObject start) {
    //     List<GameObject> visited = new List<GameObject>();

    //     if (!graph.AdjacencyList.ContainsKey(start))
    //         return visited;

    //     var queue = new Queue<GameObject>();
    //     queue.Enqueue(start);

    //     while (queue.Count > 0) {
    //         var vertex = queue.Dequeue();

    //         if (visited.Contains(vertex))
    //             continue;

    //             visited.Add(vertex);

    //             foreach(var neighbor in graph.AdjacencyList[vertex])
    //                 if (!visited.Contains(neighbor))
    //                     queue.Enqueue(neighbor);
    //     }

    //     return visited;
    // }


}
