using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        button = FindObjectOfType<Button>();
    }
    private void Update()
    {
        if (button.pressed)
        {
            Destroy(gameObject);
        }
    }
}
