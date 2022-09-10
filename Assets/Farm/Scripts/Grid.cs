using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newGrid", menuName = "Grid")]
public class Grid : ScriptableObject
{
    public readonly List<Vector3Int> Points = new List<Vector3Int>() {
        new Vector3Int(-1,0,-1),  new Vector3Int(-3,0,-1),  new Vector3Int(-5,0,-1),  new Vector3Int(-7,0,-1), new Vector3Int(-9,0,-1), 
        new Vector3Int(-1,0,-3),  new Vector3Int(-3,0,-3),  new Vector3Int(-5,0,-3),  new Vector3Int(-7,0,-3), new Vector3Int(-9,0,-3), 
        new Vector3Int(-1,0,-5),  new Vector3Int(-3,0,-5),  new Vector3Int(-5,0,-5),  new Vector3Int(-7,0,-5), new Vector3Int(-9,0,-5), 
        new Vector3Int(-1,0,-7),  new Vector3Int(-3,0,-7),  new Vector3Int(-5,0,-7),  new Vector3Int(-7,0,-7), new Vector3Int(-9,0,-7), 
        new Vector3Int(-1,0,-9),  new Vector3Int(-3,0,-9),  new Vector3Int(-5,0,-9),  new Vector3Int(-7,0,-9), new Vector3Int(-9,0,-9)
        };
}
