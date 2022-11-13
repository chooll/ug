using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string level; 

    public void OnClick () { 
        SceneManager.LoadScene(level);
    }
}
