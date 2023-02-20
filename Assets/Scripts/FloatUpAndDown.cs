using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    float initY;
    public float sinMagnitude;
    private void Start()
    {
        initY = transform.position.y;
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.time * sinMagnitude) + initY));
    }
}
