using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Button3D : MonoBehaviour
{
    [SerializeField] private bool _isPlough;

    [ShowIf("_isPlough")]
    [SerializeField] private Plough _plough;
    [HideIf("_isPlough")]
    [SerializeField] private Structure _structure;

    private void OnTriggerEnter(Collider other)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z), 0.7f);

        if (_isPlough)
            _plough.CreatingCells(1);
        else _structure.LevelUp();

        if (_plough)
        {
            if (_plough.PloughCells.Count == _plough.Grid.Points.Count)
                gameObject.SetActive(false);
        }
        else
        {
            if (_structure.CurrentLevel == _structure.Levels.Length)
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), 0.7f);
    }
}
