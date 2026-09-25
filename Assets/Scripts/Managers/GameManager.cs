using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image cover;
    [SerializeField] Button Start,Exit;
    [SerializeField] AudioClip snap;
    [SerializeField] AudioSource Asource;
    private void Awake()
    {
        Asource.clip = snap;
    }


    public void ONStart() => StartCoroutine(OnStarter());
    public void QuitGame ()  => StartCoroutine(Exits());

    IEnumerator Exits()
    {
        
        Asource.Play();
        yield return new WaitForSeconds(.03f);
        Application.Quit();
    }
    IEnumerator OnStarter()
    {
        Asource.Play();
        cover.gameObject.SetActive(true);
        cover.gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
