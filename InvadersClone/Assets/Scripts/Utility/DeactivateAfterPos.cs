using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterPos : MonoBehaviour
{
    public float BulletDeactivatePos;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > BulletDeactivatePos || transform.position.y < -BulletDeactivatePos)
        {
            gameObject.SetActive(false);
        }
    }
}
