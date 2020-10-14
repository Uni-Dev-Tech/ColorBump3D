using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [Header("Задержка перед перезагрузкой в секундах")] [SerializeField] private float time;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0.5f;
            StartCoroutine(WaitBeforeReload());
        }
    }
    IEnumerator WaitBeforeReload()
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
