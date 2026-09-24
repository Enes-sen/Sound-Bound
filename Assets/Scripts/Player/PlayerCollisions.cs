using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollsions : MonoBehaviour
{
    [SerializeField] Image End,EndText,FadeIn;
    PlayerMovement pmove;

    private void Awake() => pmove = GetComponent<PlayerMovement>();
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.transform.CompareTag("PassToLevel"))
        {
            pmove.enabled = false;
            StartCoroutine(Fader(cls.transform.gameObject));
        }
        else if (cls.transform.CompareTag("Restarter"))
        {
            pmove.Disableit();
            pmove.enabled = false;
            StartCoroutine(Fader(cls.transform.gameObject));
            
        }
        else if (cls.transform.CompareTag("End"))
        {
            StartCoroutine(EndActive());
        }
    }

    IEnumerator Fader(GameObject obj)
    {
        FadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        obj.GetComponent<SceneChangeManager>().SceneChange(obj.GetComponent<SceneChangeManager>().Scene);
    }

    IEnumerator EndActive()
    {
        End.gameObject.SetActive(true);
        pmove.enabled = false;
        pmove.gameObject.GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(3);
        EndText.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Menu");
        
    }
}
