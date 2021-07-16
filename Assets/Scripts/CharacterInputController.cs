using System.Collections;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Vector2 _destinationPoint;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Camera _camera;
    private Transform _transform;
    private bool _isStunned = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _transform = transform;
    }

    public IEnumerator StunFor(float seconds)
    {
        _isStunned = true;
        _destinationPoint = new Vector2(0, 0);
        yield return new WaitForSeconds(seconds);
        _isStunned = false;
    }

    private void Update()
    {
        if (!_isStunned)
        {
            var direction = Vector2.zero;
            direction = ClickToMove(direction);
            direction = KeyboardInput(direction);
            SetAnimation(direction);
            _rigidBody.velocity = Speed * direction;
        }
    }

    private Vector2 ClickToMove(Vector2 direction)
    {
        if (Input.GetMouseButtonUp(0))
        {
            _destinationPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (_destinationPoint != new Vector2(0, 0))
        {
            direction += (_destinationPoint - (Vector2)_transform.position);
            if (Vector2.Distance(_transform.position, _destinationPoint) < 0.5)
            {
                direction = new Vector2(0, 0);
                _destinationPoint = new Vector3(0, 0, 0);
            }
        }
        return direction.normalized;
    }

    private Vector2 KeyboardInput(Vector2 direction)
    {
        direction.x += Input.GetAxis("Horizontal");
        direction.y += Input.GetAxis("Vertical");
        return direction.normalized;
    }

    private void SetAnimation(Vector2 direction)
    {
        if (direction.x <= -0.5f)
            _animator.SetInteger("Direction", 3);
        if (direction.x >= 0.5f)
            _animator.SetInteger("Direction", 2);
        if (direction.y >= 0.5f)
            _animator.SetInteger("Direction", 1);
        if (direction.y <= -0.5f)
            _animator.SetInteger("Direction", 0);

        _animator.SetBool("IsMoving", direction.magnitude > 0);
    }
}