using System;
using UnityEngine;

namespace AGDDPlatformer
{
    public class Spike : MonoBehaviour
    {
        public string playerTag;
        public bool isSatisfied;

        public GameObject satisfactionIndicator;
        public AudioSource source;

        void Start()
        {
            // satisfactionIndicator.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                if (other.GetComponent<Rigidbody2D>().velocity.y < 0){
                    other.GetComponent<PlayerController>().ResetPlayer();
                }

                // satisfactionIndicator.SetActive(true);
                // source.Play();
            }
        }
    }
}
