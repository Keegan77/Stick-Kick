using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    public BoxCollider2D rink;
    void Start()
    {
        float orthoSize = rink.size.x * Screen.height / Screen.width;

        Camera.main.orthographicSize = orthoSize;
    }
}
