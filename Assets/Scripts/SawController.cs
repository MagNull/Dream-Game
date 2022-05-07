using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 1f;
    [SerializeField] private float distance = 1f;
    private bool _isMovingRight;
    private Vector2 _nextPoint;
    private Vector2 _leftBoundPos;
    private Vector2 _rightBoundPos;
    private Rigidbody2D _rigidbody;
    private AudioSource _damageSound;

    void Start()
    {
        _isMovingRight = true;
        _leftBoundPos = gameObject.transform.position;
        _rightBoundPos = _leftBoundPos + Vector2.right * distance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _damageSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _nextPoint = Vector2.right * movingSpeed * Time.fixedDeltaTime;
        if (IsOutOfBounders())
        {
            DoFlip();
        }
        _nextPoint.x *= (_isMovingRight) ? 1 : -1;
        _rigidbody.MovePosition((Vector2)transform.position + _nextPoint);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _damageSound.Play();
            print("the player got was injured by a saw");
        }
    }
}
