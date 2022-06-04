using Source.Slime_Components;
using UnityEngine;

public class Buttin : MonoBehaviour
{
    public GameObject _gameObject;
    public Slime slime_object;
    private bool _isTurnOn;
    private bool _isNear;

    void Awake()
    {
        _isTurnOn = false;
        _isNear = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            _isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            _isNear = false;
        }
    }

    private void Update()
    {   
        float weight = slime_object.GetWeight();
        if (_isNear && !_isTurnOn && weight > 1)
        {
            _isTurnOn = !_isTurnOn;
            _gameObject.gameObject.SetActive(!_gameObject.activeSelf);
        }
    }
}
