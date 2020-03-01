using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        TrackPlayer();
    }

    /* Tracks player vertically if it jumps higher */
    private void TrackPlayer()
    {
        Vector3 position = transform.position;
        float newPositionY = (player.transform.position + offset).y;
        if (newPositionY > position.y)
        {
            position.y = newPositionY;
            transform.position = position;
        }
    }
}
