using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;
    // Start is called before the first frame update
    private void Start()
    {   //offset target dan camera
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {   //posisi camera
        Vector3 targetCamPos = target.position + offset;
        //camera dengan smoothing
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
