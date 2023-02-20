using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFigure : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("winTrigger"))
        {
            gameManager.levelWon = true;
        }
        if (collision.CompareTag("killTrigger"))
        {
            Destroy(GetComponent<Transform>().root.gameObject);
        }
    }
}
