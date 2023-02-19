using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float ThrowForce;
    Touch touch;
    Vector3 touchPos;
    Vector2 throwDir;
    private void Awake()
    {
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            if (touch.phase == TouchPhase.Began)
            {
                throwDir = touchPos - transform.position;
                rb.AddForce(new Vector2(throwDir.x, throwDir.y) * ThrowForce, ForceMode2D.Impulse);
            }
        }
    }
}
