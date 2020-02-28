using System;
using UnityEngine;

namespace AGDDPlatformer
{
    public class Spike : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                var rb = other.GetComponent<PlayerController>();
                if (rb.velocity.y > 3 || rb.velocity.y < -3){
                    other.GetComponent<PlayerController>().ResetPlayer();
                }

            }
        }
    }
}
