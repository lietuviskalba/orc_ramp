using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;
    [Range(-5f, 50f)]
    public float camHeight;
    [Range(-55f, 50f)]
    public float camDepth;

    void Update()
    {
        CamFollowPlayer();
    }

    private void CamFollowPlayer()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.z += camDepth;
        playerPos.y += camHeight;
        transform.position = playerPos;
    }
}
