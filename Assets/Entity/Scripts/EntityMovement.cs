using UnityEngine;

public class EntityMovement
{
    private EntityMovementData _data;
    private Vector3 _velocity = Vector3.zero;
    private float _multiplySpeed = 100;

    public EntityMovement(EntityMovementData data)
    {
        _data = data;
    }

    public void Move(Vector2 direction)
    {
        Vector3 targetVelocity = new Vector3(direction.x, 0f, direction.y) * _data.MovementSpeed * _multiplySpeed * Time.fixedDeltaTime;
        _data.Rigidbody.velocity = Vector3.SmoothDamp(_data.Rigidbody.velocity, targetVelocity, ref _velocity, _data.MovementSmooth);

        if(_data.Animator == null) return;
        Animation(_data.Animator);    
    }

    public void Rotation(Vector2 direction, Transform transform)
    {
        if (direction != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _data.RotationSpeed * Time.fixedDeltaTime);
        }
    }

    public void Animation(Animator animator)
    {
        animator.SetFloat("Speed", _data.Rigidbody.velocity.magnitude);
    }
}

[System.Serializable]
public struct EntityMovementData
{
    public Animator Animator;
    public Rigidbody Rigidbody;

    public float MovementSpeed;
    [Range(0f, 0.1f)] public float MovementSmooth;

    public float RotationSpeed;
}