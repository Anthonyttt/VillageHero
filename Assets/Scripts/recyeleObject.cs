using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recyeleObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "scene")
        {
            Destroy(other);
        }
    }
}
