using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    Rigidbody2D rb;
    StickKicker kicker;
    public float restingAngle;
    float force = 750f;
    private bool thrown;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        kicker = FindObjectOfType<StickKicker>();
    }

    private void FixedUpdate()
    {
        if (!kicker.throwing && !thrown)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, restingAngle, force * Time.deltaTime));
        }
        if (kicker.throwing)
        {
            thrown = true;
        }
    }
}
