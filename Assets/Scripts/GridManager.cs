using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField]
    int x = 0;
    [SerializeField]
    int y = 0;
    [SerializeField]
    float spacing = 1f;

    public GameObject gridPart;

    public GameObject[,] grid;
    private List<Point> points = new List<Point>();

    public List<GameObject> gridPoints;

    public GameObject gridParent;
    private List<GameObject> neighbours;

    public float animSpeed;

    private void Awake()
    {
        Instance = this;
        InitializeGrid();
    }

    void InitializeGrid()
    {
        grid = new GameObject[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Point newPoint = new Point(i, j);
                points.Add(newPoint);

                GameObject newGridPoint = Instantiate(gridPart, new Vector3(newPoint.X * spacing, 0f, newPoint.Y * spacing), gridPart.transform.rotation, gridParent.transform);
                newGridPoint.GetComponent<GridCell>().gridPos = newPoint;
                gridPoints.Add(newGridPoint);

                //grid[i, j] = Instantiate(gridPart, new Vector3(i * spacing, 0f, j * spacing), gridPart.transform.rotation);
            }
        }
    }

    public List<GameObject> GetNeighbours(GridCell currentCell)
    {
        neighbours = new List<GameObject>();

        for (int i = 0; i < gridPoints.Count; i++)
        {
            if (gridPoints[i].GetComponent<GridCell>().gridPos.X == currentCell.gridPos.X + spacing * 2)
                neighbours.Add(gridPoints[i]);
            if (gridPoints[i].GetComponent<GridCell>().gridPos.X == currentCell.gridPos.X - spacing * 2)
                neighbours.Add(gridPoints[i]);
            if (gridPoints[i].GetComponent<GridCell>().gridPos.Y == currentCell.gridPos.Y + spacing * 2)
                neighbours.Add(gridPoints[i]);
            if (gridPoints[i].GetComponent<GridCell>().gridPos.Y == currentCell.gridPos.Y - spacing * 2)
                neighbours.Add(gridPoints[i]);
        }

        Debug.Log(neighbours.Count);
        return neighbours;
    }
}
