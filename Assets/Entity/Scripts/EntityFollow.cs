using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(Rigidbody))]
public class EntityFollow : MonoBehaviour
{
    [SerializeField] private EntityFollowData _followData;

    private Rigidbody _body;
    private Vector3 _velocity = Vector3.zero;
    private float _multiplySpeed = 100;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _body.useGravity = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetVelocity = (_followData.Target.position + _followData.Distance - transform.position) * _followData.SpeedFollow * _multiplySpeed * Time.fixedDeltaTime;
        _body.velocity = Vector3.SmoothDamp(_body.velocity, targetVelocity, ref _velocity, _followData.SmoothSpeed);
    }
}

[System.Serializable]
public struct EntityFollowData
{
    public Transform Target;
    public Vector3 Distance;
    public float SpeedFollow;
    [Range(0f, 0.1f)] public float SmoothSpeed;
}