using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject tapToStart;
    private bool tap = false;
    public Slider progress;
    public Transform finishPoint;
    public Transform ball;

    private void Start()
    {
        Time.timeScale = 0f;
        progress.minValue = ball.position.x;
        progress.maxValue = finishPoint.position.x;
    }
    private void Update()
    {
        progress.value = ball.position.x;
        if (!tap)
            if (Input.touchCount > 0)
            {
                tap = true;
                tapToStart.SetActive(false);
                Time.timeScale = 1f;
            }
    }
}
