using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollsions : MonoBehaviour
{
    [SerializeField] Image End,EndText,FadeIn;
    PlayerMovement pMove;
    Vector3 baseForm;

    private void Awake()
    {
        pMove = GetComponent<PlayerMovement>();
        baseForm = transform.localScale;

    }
    private void OnEnable()
    {
        transform.localScale = baseForm;
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.transform.CompareTag("PassToLevel"))
        {
            pMove.enabled = false;
            StartCoroutine(Fader(cls.transform.gameObject));
        }
        else if (cls.transform.CompareTag("Restarter"))
        {
            pMove.Disableit();
            pMove.enabled = false;
            transform.localScale -= Vector3.Slerp(transform.localScale, Vector3.zero,12f*Time.deltaTime);
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
        pMove.enabled = false;
        pMove.gameObject.GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(3);
        EndText.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Menu");
        
    }
}
