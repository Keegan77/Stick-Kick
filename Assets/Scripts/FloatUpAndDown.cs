using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    Vector2 initPos;
    public float sinMagnitude;
    public bool upDown;
    private void Start()
    {
        initPos = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(upDown ? transform.position.x : (Mathf.Cos(Time.time * sinMagnitude) + initPos.x), 
            upDown ? (Mathf.Sin(Time.time * sinMagnitude) + initPos.y) : transform.position.y);
    }
}
