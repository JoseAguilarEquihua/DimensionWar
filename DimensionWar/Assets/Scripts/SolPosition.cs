using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolPosition : MonoBehaviour
{

    public GameObject Dereck;
    public float posy;
    public float posz;
    public float distance;

    private Vector2 velocity;
    void Update()
    {
        if (Dereck != null)
        {
            float posX = Dereck.transform.position.x;
            //float posY = Dereck.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(posX + distance, posy, posz);
        }
    }
}
