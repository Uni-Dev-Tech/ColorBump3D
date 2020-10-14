using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Material material;
    public GameObject target;
    private Rigidbody rb;
    private float motX, motZ;
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        motX = SwipeDetector.instance.resultY;
        motZ = SwipeDetector.instance.resultX;
    }
    private void FixedUpdate()
    {
        Touch touch;
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
                rb.AddForce(motX * Time.fixedDeltaTime, 0, -motZ * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objects"))
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name != material.name)
                StartCoroutine(DestroyBall());
    }
    IEnumerator DestroyBall()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
