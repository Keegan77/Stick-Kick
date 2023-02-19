using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickKicker : MonoBehaviour
{
    //refs
    Rigidbody2D stickRb;
    public GameObject stickman;
    GameObject currentStickman;
    //internals
    Transform stickSpawnPoint;
    Touch touch;
    Vector3 touchPos;
    Vector2 throwDir;
    public GameObject[] stickmenOnScreen;
    float distance;

    [Header ("Vars")]
    public float ThrowForce;
    public float maxNumOfStickmen;

    //bools
    bool throwing;
    bool distLessThanThree;
    private void Awake()
    {
        stickSpawnPoint = GameObject.FindGameObjectWithTag("stickSpawn").GetComponent<Transform>();
        CreateNewStickman();
        stickRb = GameObject.FindGameObjectWithTag("head").GetComponent<Rigidbody2D>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            if (touch.phase == TouchPhase.Began && !throwing)
            {
                StartCoroutine(ThrowStickman());
            }
        }
    }
    private void CreateNewStickman()
    {
        Instantiate(stickman, stickSpawnPoint.position, stickman.transform.rotation);
        stickmenOnScreen = GameObject.FindGameObjectsWithTag("head");
        currentStickman = stickmenOnScreen[stickmenOnScreen.Length - 1];
        stickRb = currentStickman.GetComponent<Rigidbody2D>();

        if (stickmenOnScreen.Length > maxNumOfStickmen)
        {
            Destroy(stickmenOnScreen[0].GetComponent<Transform>().root.gameObject);
        }
    }
    private IEnumerator ThrowStickman()
    {
        throwDir = touchPos - currentStickman.transform.position;
        distance = Vector3.Distance(currentStickman.transform.position, touchPos);

        if (distance < 3) distLessThanThree = true;
        else distLessThanThree = false;

        stickRb.AddForce(distLessThanThree ? new Vector2(throwDir.x, (throwDir.y * 2)) * (ThrowForce * 2)
            : new Vector2(throwDir.x, (throwDir.y * 2)) * ThrowForce, ForceMode2D.Impulse);
        throwing = true;
        yield return new WaitForSeconds(1);
        throwing = false;
        CreateNewStickman();
    }
}
