using Source.Slime_Components;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 _endPosition;

    [SerializeField] 
    private float _velocity;

    public GameObject _gameObject;

    private bool _isSomethingInside;

    private Vector3 _upPosition;

    private bool _activationAvailable;

    private void Awake()
    {
        _upPosition = transform.position;
        _activationAvailable = true;
    }

    void Update()
    {
        if (!_isSomethingInside)
            MovePlate(_upPosition);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime) && (_isSomethingInside))
        {
            Vector3 targetPosition;
            targetPosition = _endPosition;
            MovePlate(targetPosition);
            UpdateActivationStatus();
        }
    }

    private void MovePlate(Vector3 targetPosition) => transform.position =
        Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _velocity);

    private void UpdateActivationStatus()
    {
        if (transform.position == _endPosition && _activationAvailable)
        {
            print("Activation");
            _activationAvailable = false;
            _gameObject.gameObject.SetActive(!_gameObject.activeSelf);
        }

        if (transform.position == _upPosition)
        {
            _activationAvailable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            if (slime.GetCurrentSlimeState().Name == "StoneState")
            {
                _isSomethingInside = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            _isSomethingInside = false;
            _activationAvailable = true;
        }
    }
}
