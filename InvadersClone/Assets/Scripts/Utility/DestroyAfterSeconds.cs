using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y > 6f)
        {
            gameObject.SetActive(false);
        }
    }
}
