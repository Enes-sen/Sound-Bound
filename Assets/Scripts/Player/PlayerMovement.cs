using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]float Speed;
    [SerializeField] Animator _animator;
    [SerializeField] Image Awakes;
    [SerializeField] GameObject pvisual;
    bool isstarted = false;
    Vector2 Movement;
    [SerializeField] AudioSource _Asource;
    private bool _canSnap;


    void OnEnable()
    {
        StartCoroutine(Awaked());
        _rb = GetComponent<Rigidbody2D>();
        _canSnap = true;
    }

    public void Disableit()
    {
        _animator.enabled = false;
        _Asource.Stop();
    }

    IEnumerator Awaked()
    {
        pvisual.GetComponent<SpriteRenderer>().enabled = true;
        yield return  new WaitForSeconds(2);
        yield return  new WaitForSeconds(1);
        Awakes.gameObject.SetActive(false);
        isstarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isstarted)
        {
            GetInput();
        }
    }

    void FixedUpdate() => Move();
    void Move()
    {
        if (isstarted)
        {
            _rb.MovePosition(_rb.position + Speed * Time.fixedDeltaTime * Movement.normalized);
        }

    }
    void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
        if (Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)
        {
            if (!_Asource.isPlaying)
            {
                _Asource.Play();
            }
        }
        else
        {
            _Asource.Stop();
        }
            Movement = new Vector2(horizontal, vertical);
        _animator.SetFloat("Speed", Movement.sqrMagnitude);

        if (Input.GetKeyDown(key: KeyCode.F) && _canSnap)
        {
            StartCoroutine(Snapper(0.3f));
        }
        if (Input.GetKeyDown(key:KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator Snapper(float timer)
    {
        LightManager.Instance.SnapEffected();
        _canSnap = false;
        yield return new WaitForSeconds(timer);
        _canSnap = true;
    }
}
