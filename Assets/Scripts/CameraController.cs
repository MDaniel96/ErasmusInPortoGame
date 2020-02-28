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
        Vector3 position = transform.position;
        position.y = (player.transform.position + offset).y;
        transform.position = position;
    }
}
