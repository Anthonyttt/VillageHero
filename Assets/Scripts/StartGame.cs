using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform point;
    void Start()
    {
        Instantiate(player, point.position, point.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
