using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room6 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 6", LoadSceneMode.Single);
    }
}
