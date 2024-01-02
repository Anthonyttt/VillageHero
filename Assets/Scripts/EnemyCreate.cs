using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyCreate : MonoBehaviour
{
    public Transform[] createPoint_1=new Transform[2];
    public Transform[] createPoint_2=new Transform[2];
    public GameObject enemy;
    private GameObject father;
    void Start()
    {
        father = GameObject.FindGameObjectWithTag("scene");
        createEnemy();
    }

    private void createEnemy()
    {
        int n, m;
        n = Random.Range(0, 2);
        m = Random.Range(0, 2);
        Instantiate(enemy, createPoint_1[n].position, createPoint_1[n].rotation,father.transform);
        Instantiate(enemy, createPoint_2[m].position, createPoint_2[m].rotation,father.transform);
    }
    
}
