using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Dereck;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;
      
    void Update()
    {
        if (Dereck != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x,
                Dereck.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y,
                Dereck.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);
        }
    }
}
