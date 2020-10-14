using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMotion : MonoBehaviour
{
    public Transform lineLeft;
    public Transform lineRight;
    public Transform backLimit;
    private void Update()
    {
        if (transform.position.z >= lineLeft.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, lineLeft.position.z - 0.5f);
        if (transform.position.z <= lineRight.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, lineRight.position.z + 0.5f);
        if (transform.position.x <= backLimit.position.x)
            transform.position = new Vector3(backLimit.position.x + 0.5f, transform.position.y, transform.position.z);
    }
}
