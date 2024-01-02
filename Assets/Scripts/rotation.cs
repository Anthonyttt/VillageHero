using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    private Transform player;

    private Vector3 rotationAxis = Vector3.up;

    public float rotationSpeed = 150f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.position,rotationAxis,rotationSpeed*Time.deltaTime);
        transform.LookAt(player);

    }
}
