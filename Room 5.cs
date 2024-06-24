using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room5 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 5", LoadSceneMode.Single);
    }
}
