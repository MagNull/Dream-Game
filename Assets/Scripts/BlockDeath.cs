using Source.Slime_Components;
using UnityEngine;

class BlockDeath : MonoBehaviour
{
        //private AudioSource _damageSound;
        public GroundChecking ground;

        private void Awake()
        {
            //_damageSound = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Slime slime) && ground.IsGrounded)
            {
                print("Damage");
                //_damageSound.Play();
                slime.TakeDamage(1, this);
                print("the player got into a dangerous substance");
            }
        }
    }

