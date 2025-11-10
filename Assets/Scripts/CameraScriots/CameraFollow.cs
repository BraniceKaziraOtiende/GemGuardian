using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;
    public Bounds cameraBounds;

    private Transform target;
    private float offsetZ;
    private Vector3 currentVelocity;
    private bool followsPlayer;

    void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        if (myCol == null)
        {
            myCol = gameObject.AddComponent<BoxCollider2D>();
            myCol.isTrigger = true;
        }

        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
        cameraBounds = myCol.bounds;
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
            offsetZ = (transform.position - target.position).z;
            followsPlayer = true;
            Debug.Log("Camera locked on Player!");
        }
        else
        {
            Debug.LogError("Player not found! Make sure your player is tagged 'Player'.");
            followsPlayer = false;
        }
    }

    void FixedUpdate()
    {
        if (followsPlayer && target != null)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;

            // Only follow if player is moving forward (optional - remove the if to always follow)
            if (aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos,
                    ref currentVelocity, cameraSpeed);

                // Only follow horizontally — keep Y & Z steady
                transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);
            }
        }
    }
}