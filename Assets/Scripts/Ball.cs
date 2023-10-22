using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 400f;
    public AudioSource Land;
    public GameObject splitPrefabs;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Land.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        Land.Play();
        GameObject newSplit = Instantiate(splitPrefabs, new Vector3(transform.position.x, other.transform.position.y + 0.19f, transform.position.z), transform.rotation);
        newSplit.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
        newSplit.transform.parent = other.transform;

        string materialName = other.transform.GetComponent<MeshRenderer> ().material.name;

        if(materialName == "Safe (Instance)")
        {
            Debug.Log("Safe");
        }
        if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver = true;
        }
        if (materialName == "LastRing (Instance)")
        {
            GameManager.levelWin = true;
        }

    }
}
