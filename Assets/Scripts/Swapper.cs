using System;
using UnityEngine;

namespace AGDDPlatformer
{
    public class Swapper : MonoBehaviour
    {
        public GameObject satisfactionIndicator;
        public AudioSource source;
        string lastPlayer;
        bool active = true;
        public BoxCollider2D boxCollider;

        void Start()
        {
            satisfactionIndicator.SetActive(true);
            boxCollider = GetComponent<BoxCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Time.timeScale = 0.01f;
            if (other.CompareTag("Player1") && active)
            {
                var player2 = GameObject.FindWithTag("Player2");
                var tempPos = other.transform.position;
                other.transform.position = player2.transform.position;
                player2.transform.position = tempPos;
                lastPlayer = player2.tag;
                boxCollider.size *= 2;
                active = false;
            }
            else if (other.CompareTag("Player2") && active)
            {
                var player1 = GameObject.FindWithTag("Player1");
                var tempPos = player1.transform.position;
                player1.transform.position = other.transform.position;
                other.transform.position = tempPos;
                lastPlayer = player1.tag;
                boxCollider.size *= 2;
                active = false;
            }
            Debug.Log("get owned");
            satisfactionIndicator.SetActive(false);
            // source.Play();
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(lastPlayer) && !active)
            {
                boxCollider.size /= 2;
                satisfactionIndicator.SetActive(true);
                active = true;
            }
        }
    }
}