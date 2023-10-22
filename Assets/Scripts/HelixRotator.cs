using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float rotationSpeedAndroid = 50f;
    public AudioSource bounce;
    public bool isPlaying = false;
    private void Start()
    {
        bounce.Stop();
    }

    public void Playing()
    {
        isPlaying = true;
    }
    private void Update()
    {
    #if UNITY_EDITOR
        if (Input.GetMouseButton(0) && isPlaying)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(transform.position.x, -mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
            bounce.Play();
        }

#elif UNITY_ANDROID
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && isPlaying)
        {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(transform.position.x, -xDeltaPos * rotationSpeedAndroid * Time.deltaTime, transform.position.z);
            bounce.Play();

        }
        
#endif

        
    }
}
