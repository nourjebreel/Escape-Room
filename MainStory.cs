using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    
}
