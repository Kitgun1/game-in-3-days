using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plough : MonoBehaviour
{
    [SerializeField] private GameObject _cell;

    public List<PloughCell> PloughCells { get; private set; } = new List<PloughCell>();
    public Grid Grid { get; private set; }

    private void Start()
    {
        Grid = Resources.Load<Grid>("Plough");
    }

    public void CreatingCells(int count)
    {
        if (count <= 0) return;
        if (Grid.Points.Count == PloughCells.Count) return;

        var points = Grid.Points.GetRange(PloughCells.Count, count);

        foreach (var point in points)
        {
            var obj = Instantiate(_cell, new Vector3(transform.position.x + point.x, 0, transform.position.z + point.z), transform.rotation, transform);
            PloughCells.Add(obj.GetComponent<PloughCell>());
        }
    }
}