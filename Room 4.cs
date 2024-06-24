using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room4 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 4", LoadSceneMode.Single);
    }
}
