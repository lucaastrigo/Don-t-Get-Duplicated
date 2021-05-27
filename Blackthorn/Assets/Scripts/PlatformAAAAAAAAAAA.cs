using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAAAAAAAAAAA : MonoBehaviour
{
    public float speed;
    public Transform rightMax, LeftMax;

    float right, left;
    bool goingRight;

    private void Start()
    {
        right = rightMax.position.x;
        left = LeftMax.position.x;
    }

    void Update()
    {
        if (transform.position.x >= right)
        {
            goingRight = false;
        }

        if (transform.position.x <= left)
        {
            goingRight = true;
        }

        if (goingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
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
