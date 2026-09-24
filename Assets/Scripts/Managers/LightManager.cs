using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [Header("Manager Settings")]
    [SerializeField] private GameObject LightInstance;
    public static LightManager  Instance { get; private set; }
    [SerializeField] private float WaitTime;

    private void Awake()
    {
        Instance = this;
    }
    public void SnapEffected()
    {
      
        var light = Instantiate(LightInstance,transform.position,Quaternion.identity);
        StartCoroutine(CloseAfter(WaitTime,light));
        
    }
    IEnumerator CloseAfter(float time,GameObject obj) { yield return new WaitForSecondsRealtime(time); Destroy(obj, 0.01f); }
}
