using System;
using UnityEngine;

namespace AGDDPlatformer
{
    public class Spike : MonoBehaviour
    {
        public AudioSource source;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                var rb = other.GetComponent<PlayerController>();
                if (rb.velocity.y > 5 || rb.velocity.y < -5){
                    other.GetComponent<PlayerController>().ResetPlayer();
                    source.Play();
                }
            }
        }
    }
}
