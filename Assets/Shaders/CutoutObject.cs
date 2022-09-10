using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;
    [SerializeField] private LayerMask _wallMask;

    [SerializeField] private float _cutoutSize;
    [SerializeField] private float _falloffSize;
    [SerializeField] private float _offsetY;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector2 cutoutPosition = _mainCamera.WorldToViewportPoint(_targetObject.position);
        cutoutPosition.y /= (Screen.height / Screen.width) - _offsetY;

        Vector3 offset = _targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, _wallMask);

        for (int i = 0; i < hitObjects.Length; i++)
        {
            Material[] materials = hitObjects[i].transform.GetComponent<Renderer>().materials;
            foreach (var material in materials)
            {
                material.SetVector("_PositionCutout", cutoutPosition);
                material.SetFloat("_CutoutSize", _cutoutSize);
                material.SetFloat("_FalloffSize", _falloffSize);
            }
        }
    }
}
