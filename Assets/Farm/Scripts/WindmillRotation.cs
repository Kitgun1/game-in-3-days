using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindmillRotation : MonoBehaviour
{
    [SerializeField] private WindmillRotationData _data;
    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotationAxis();
    }

    private void RotationAxis()
    {
        float rotation = Time.deltaTime * _data.Speed;
        if (_data.Axis[0])
            _body.AddRelativeTorque(rotation, _body.rotation.y, _body.rotation.z);
        if (_data.Axis[1])
            _body.AddRelativeTorque(_body.rotation.x, rotation, _body.rotation.z);
        if (_data.Axis[2])
            _body.AddRelativeTorque(_body.rotation.x, _body.rotation.y, rotation);
    }
}

[System.Serializable]
public struct WindmillRotationData
{
    public List<bool> Axis;
    [Min(0)] public float Speed;
}
