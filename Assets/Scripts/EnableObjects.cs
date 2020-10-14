using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    [SerializeField] private Transform enablePoint;
    [SerializeField] private GameObject[] parts;
    private int index = 0;
    private void Update()
    {
        if(index < parts.Length)
            if (parts[index].transform.position.x <= enablePoint.position.x)
            {
                parts[index].SetActive(true);
                index++;
            }
    }
}
