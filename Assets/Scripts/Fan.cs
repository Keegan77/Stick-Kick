using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [Tooltip("If unticked, assume down")]
    [SerializeField] bool fanUp; // if not up, going down
    [Tooltip("If unticked, assume left")]
    [SerializeField] bool fanRight; // if not right, going left

    [SerializeField] bool verticalFan;

    public float fanSpeed = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            ConstantForce2D fanForce;
            if (collision.gameObject.GetComponent<ConstantForce2D>() != null)
            {
                Destroy(collision.gameObject.GetComponent<ConstantForce2D>());
            }
            collision.gameObject.AddComponent<ConstantForce2D>();
            fanForce = collision.gameObject.GetComponent<ConstantForce2D>();

            if (verticalFan)
            {
                fanForce.force = new Vector2(0, fanUp ? fanSpeed * 3 : -fanSpeed * 3);
            } else fanForce.force = new Vector2(fanRight ? fanSpeed : -fanSpeed, 0);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            if (collision.gameObject.GetComponent<ConstantForce2D>() != null)
            {
                Destroy(collision.gameObject.GetComponent<ConstantForce2D>());
            }
        }
    }
}
