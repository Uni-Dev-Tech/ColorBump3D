using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMotion : MonoBehaviour
{
    [Header("Скорость движения карты")] [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
