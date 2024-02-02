using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    public static Fortress instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
