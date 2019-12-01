using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SquareVanisher : MonoBehaviour
{
    private static int gridWidth = SquareGenerator.gridWidth;
    private static int gridHeight = SquareGenerator.gridHeight;
    private int[,] grid = new int[gridWidth, gridHeight];
    private static Color[] colors = ColorGenerator.Colors;
    private GameObject start;
    private static Color color;
    public static List<GameObject> notSameColor = new List<GameObject>();

    // Use this for initialization
    void Start () {
        for (int i = 0; i < gridHeight; i++) {
            for (int j = 0; j < gridWidth; j++) {
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
        start = this.gameObject;
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
        destroyNeighbours(this.gameObject, color);
        foreach (GameObject g in notSameColor) {
            if (g != null) {
                changeColor(g);
            }
        }
        notSameColor.Clear();
    }

    private List<GameObject> neighbourCell(string loc, int row, int col, List<GameObject> neighbours)
    {
        if (GameObject.Find(loc) != null && GameObject.Find(loc).GetComponent<SpriteRenderer>().color == color && grid[row, col] == 0)
        {
            grid[row, col] = 1;
            neighbours.Add(GameObject.Find(loc));
        }
        else {
            notSameColor.Add(GameObject.Find(loc));
        }

        return neighbours;
    }

    private void changeColor(GameObject g) {
        int index = System.Array.IndexOf(colors, g.GetComponent<SpriteRenderer>().color);
        int[] values = Enumerable.Range(0, colors.Length).Where(item => item != index).ToArray();
        System.Random random = new System.Random();
        int r = values[random.Next(values.Length)];
        g.GetComponent<SpriteRenderer>().color = colors[r];
    }
 

    private void destroyNeighbours(GameObject curr, Color color)
    {
        string name = curr.name;

       // get row and col of curr cell from curr name
        string string_row = name.Substring(name.IndexOf('[') + 1, name.Length - name.Substring(name.IndexOf(',')).Length - name.Substring(0, name.IndexOf('[') + 1).Length);
        int.TryParse(string_row, out int row);

        string string_col = name.Substring(name.IndexOf(',') + 1, name.Length - 1 - name.Substring(0, name.IndexOf(',') + 1).Length);
        int.TryParse(string_col, out int col);

        grid[row, col] = 1;
        
        int left_col = col - 1;
        int right_col = col + 1;
        int up_row = row - 1;
        int down_row = row + 1;
        
        string left = "Square [" + string_row + ", " + left_col.ToString() + "]";
        string right = "Square [" + string_row + ", " + right_col.ToString() + "]";
        string up = "Square [" + up_row.ToString() + ", " + string_col + "]";
        string down = "Square [" + down_row.ToString() + ", " + string_col + "]";
        
        List<GameObject> neighbours = new List<GameObject>();

        neighbours = neighbourCell(left, row, left_col, neighbours);
        neighbours = neighbourCell(right, row, right_col, neighbours);
        neighbours = neighbourCell(up, up_row, col, neighbours);
        neighbours = neighbourCell(down, down_row, col, neighbours);

        if (neighbours.ToArray().Length == 0)
        {
            if (curr != start) {
                Destroy(curr);
            } else {
                notSameColor.Clear();
            }
            return;
        }

        foreach (GameObject g in neighbours)
        {
            string_row = g.name.Substring(name.IndexOf('[') + 1, 1);
            int.TryParse(string_row, out row);

            string_col = g.name.Substring(name.IndexOf(',') + 2, 1);
            int.TryParse(string_col, out col);

            destroyNeighbours(g, color);

            if (grid[row, col] == 1)
                Destroy(g);
        }

        Destroy(curr);

        // foreach (GameObject g in neighbours)
        // {
        //     string_row = g.name.Substring(name.IndexOf('[') + 1, 1);
        //     int.TryParse(string_row, out row);
        //     string_col = g.name.Substring(name.IndexOf(',') + 2, 1);
        //     int.TryParse(string_col, out col);
        //     if (grid[row, col] == 1) {
        //         return;
        //     }
        //     grid[row, col] = 1;
            
        //     if (g.GetComponent<SpriteRenderer>().color == color)
        //     {
        //         destroyNeighbours(g, color);
        //         Destroy(g);
        //     } else {
        //         int index = System.Array.IndexOf(colors, g.GetComponent<SpriteRenderer>().color);
        //         int[] values = Enumerable.Range(0, colors.Length).Where(item => item != index).ToArray();
        //         System.Random random = new System.Random();
        //         int r = values[random.Next(values.Length)];
        //         g.GetComponent<SpriteRenderer>().color = colors[r];
        //     }

        // }
       
    }

}
