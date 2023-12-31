﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] rings;

    public int noOfRings;
    public float ringDistance;
    float yPoss;


    private void Start()
    {
        noOfRings = GameManager.CurrentLevelIndex + 5;
        for(int i = 0; i < noOfRings; i++)
        {
            if(i == 0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1, rings.Length - 1));
            }
        }
        SpawnRings(rings.Length - 1);
    }


    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPoss, transform.position.z), Quaternion.identity);
        yPoss -= ringDistance;
        newRing.transform.parent = transform;
    }
}
