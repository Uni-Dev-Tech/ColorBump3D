using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public float resultX, resultY;
    public GameObject ball;
    public GameObject target;
    static public SwipeDetector instance;
    public float speed;
    public float sens;
    private float resX = 0f;
    private float resZ = 0f;
    public Transform transformBall;
    private void Awake()
    {
        if(SwipeDetector.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        SwipeDetector.instance = this;
    }
    private void Update()
    {
        if (Input.touchCount < 1)
        {
            resultX = 0;
            resultY = 0;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        resX = ball.transform.position.x - eventData.pointerCurrentRaycast.worldPosition.x;
        resZ = ball.transform.position.z - eventData.pointerCurrentRaycast.worldPosition.z;
        if (eventData.delta.x > 0)
            resultX = eventData.delta.x * sens;
        else
            resultX = eventData.delta.x * sens;

        if (eventData.delta.y > 0)
            resultY = eventData.delta.y * sens;
        else
            resultY = eventData.delta.y * sens;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 move = new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, ball.transform.position.y, eventData.pointerCurrentRaycast.worldPosition.z);
        target.transform.position = new Vector3(move.x + resX, move.y, move.z + resZ);
        ball.transform.position = Vector3.MoveTowards(ball.transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        resX = 0;
        resZ = 0;
    }
}
