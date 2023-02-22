using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [HideInInspector] public bool pressed;
    Animator anim;
    public GameObject boulder;
    StickKicker kicker;
    public Transform boulderSpawnPoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        kicker = FindObjectOfType<StickKicker>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("head") || collision.gameObject.CompareTag("Limb"))
        {
            if (!pressed)
            {
                StartCoroutine(PressButton());
            }
        }
    }

    private IEnumerator PressButton()
    {
        anim.SetTrigger("pressed");
        kicker.DestroyAllStickmen();
        pressed = true;
        yield return new WaitForSeconds(1);
        pressed = false;
        SpawnBoulder();
    }

    private void SpawnBoulder()
    {
        Instantiate(boulder, boulderSpawnPoint.position, transform.rotation);
    }
}
