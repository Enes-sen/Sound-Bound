using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public int Scene;
    public void SceneChange(int scene) => SceneManager.LoadScene(scene);
}
