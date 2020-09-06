using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 cameraOffset;
    Vector3 smoothedPosition;
    float smoothAmount = 1f;
    Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("player").transform;
        cameraOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        smoothedPosition = Vector3.Lerp(transform.position, playerTransform.position + cameraOffset, smoothAmount);
        if (playerTransform.position.y < 3.5f)
        {
            smoothedPosition = new Vector3(0f, transform.position.y, smoothedPosition.z);
        }
        transform.position = smoothedPosition;
    }
}
