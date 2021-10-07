using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    public float time = 1f;

    void Awake()
    {
        Destroy(gameObject, time);
    }
}
