using UnityEngine;

public class DangerArea : MonoBehaviour
{
    private AudioSource _damageSound;

    private void Start()
    { 
        _damageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _damageSound.Play();
            print("the player got into a dangerous substance");
        }
    }
}
