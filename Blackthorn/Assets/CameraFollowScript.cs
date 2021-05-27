using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowScript : MonoBehaviour
{
    public float verticalOffset;
    public float smoothTime;

    Vector3 target, refVel;
    GameObject player;


    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private Vector3 vel = Vector3.zero;
    private Vector3 targetPos;
    public Vector3 offset;

    private void Start()
    {
    }
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        target = UpdateTargetPos();
        UpdateCameraPos();
        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa


        targetPos = player.transform.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothTime);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 ret = player.transform.position;
        ret.y += verticalOffset;
        ret.z = transform.position.z;
        return ret;
    }

    void UpdateCameraPos()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
        transform.position = tempPos;
    }

}
