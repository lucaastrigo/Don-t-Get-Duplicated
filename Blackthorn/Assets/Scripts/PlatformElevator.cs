using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformElevator : MonoBehaviour
{
    public float speed;
    public Transform topPos, bottomPos;

    float top, bottom;
    bool goingUp;

    private void Start()
    {
        top = topPos.position.y;
        bottom = bottomPos.position.y;
    }

    void Update()
    {
        if(transform.position.y >= top)
        {
            goingUp = false;
        }

        if(transform.position.y <= bottom)
        {
            goingUp = true;
        }

        if (goingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.collider.transform.SetParent(null);
    }
}
