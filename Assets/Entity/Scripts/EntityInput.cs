using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private EntityMovementData _entityMovementData;

    private EntityMovement _entityMovement;

    private void Start()
    {
        _entityMovement = new EntityMovement(_entityMovementData);
    }

    private void FixedUpdate()
    {
        Vector2 direction = _joystick.Direction;
        _entityMovement.Move(direction);
        _entityMovement.Rotation(direction, transform);
    }
}
