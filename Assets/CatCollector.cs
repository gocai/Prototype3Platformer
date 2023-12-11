using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCollector : MonoBehaviour
{
    private int cats = 0;

    [SerializeField] private Text scoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Destroy(collision.gameObject);
            cats++;
            scoreText.text = cats >= 35 ? "You Got Them All!" : "Cats Remaining: " + (35 - cats);
        }
    }
}