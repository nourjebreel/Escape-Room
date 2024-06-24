using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room2 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
}
