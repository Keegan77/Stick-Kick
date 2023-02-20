using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool levelWon;

    private void Awake()
    {
        levelWon = false;
    }
}
