using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float JumpForce;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((Vector2.up * JumpForce) * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
