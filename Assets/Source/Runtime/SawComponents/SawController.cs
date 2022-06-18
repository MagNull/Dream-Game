using Source.Slime_Components;
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 1f;
    [SerializeField] private float _distance = 1f;
    [SerializeField]
    private float _spinSpeed;
    private bool _isMovingRight;
    private Vector2 _nextPoint;
    private Vector2 _leftBoundPos;
    private Vector2 _rightBoundPos;
    private Rigidbody2D _rigidbody;
    private AudioSource _damageSound;

    void Awake()
    {
        _isMovingRight = true;
        _leftBoundPos = gameObject.transform.position;
        _rightBoundPos = _leftBoundPos + Vector2.right * _distance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _damageSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _nextPoint = Vector2.right * _movingSpeed * Time.fixedDeltaTime * TimeShiftConstants.Constants["OtherConstant"];
        if (IsOutOfBounders())
        {
            DoFlip();
        }
        _nextPoint.x *= (_isMovingRight) ? 1 : -1;
        _rigidbody.MovePosition((Vector2)transform.position + _nextPoint);
        transform.Rotate(Vector3.forward, _spinSpeed * TimeShiftConstants.Constants["OtherConstant"]);
        _rigidbody.gravityScale = 0;
    }

    private void DoFlip()
    {
        _isMovingRight = !_isMovingRight;
        var newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private bool IsOutOfBounders()
    {
        return (!_isMovingRight && transform.position.x <= _leftBoundPos.x)
               || (_isMovingRight && transform.position.x >= _rightBoundPos.x);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime damageable))
        {
            _damageSound.Play();
            damageable.TakeDamage(1, this);
            print("the player got was injured by a saw");
        }
    }
}
