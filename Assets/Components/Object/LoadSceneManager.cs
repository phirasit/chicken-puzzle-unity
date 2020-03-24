using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadSceneManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
