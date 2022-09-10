using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GameObject[] Levels;
    public int CurrentLevel { get; private set; }

    private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
    private List<BoxCollider[]> _colliders = new List<BoxCollider[]>();


    private void Start()
    {
        foreach (var obj in Levels)
        {
            _meshRenderers.Add(obj.GetComponent<MeshRenderer>());
            _colliders.Add(obj.GetComponents<BoxCollider>());
        }
        LevelUp(true);
    }

    public void LevelUp(bool clear = false)
    {
        if (clear) CurrentLevel = 0;
        else CurrentLevel++;
        UpdateStructures();
    }

    private void UpdateStructures()
    {
        for (int i = 0; i < Levels.Length; i++)
            if (i != CurrentLevel - 1)
            {
                _meshRenderers[i].enabled = false;
                foreach (var collider in _colliders[i])
                    collider.enabled = false;
            }
            else
            {
                _meshRenderers[i].enabled = true;
                foreach (var collider in _colliders[i])
                    collider.enabled = true;
            }
    }
}