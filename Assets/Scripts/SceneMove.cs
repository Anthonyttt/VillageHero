using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public float moveSpeed = 50f;
    
    void Update()
    {
        transform.Translate((moveSpeed/10)*Time.deltaTime,0,0);
    }
}
