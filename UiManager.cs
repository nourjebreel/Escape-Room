using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject inputPanel, wonPanel;

    public TMP_InputField wordInput;

    public TMP_Text currentWordTxt;
    public TMP_Text scoreTxt, usernameTxt;

    public static UiManager instance;

    [SerializeField]
    Button doneBtn, exitBtn;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        doneBtn.onClick.AddListener(CheckWordDone);
        exitBtn.onClick.AddListener(ExitGame);
        if (SaveManager.currentPlayer != null)
        {
            SetTextValue(usernameTxt, SaveManager.currentPlayer.playerName);
            SetTextValue(scoreTxt, SaveManager.currentPlayer.playerScore.ToString());
        }
    }

    void CheckWordDone()
    {
        currentWordTxt.text = wordInput.text;

        FindObjectOfType<PlayerController>().enabled = true;
        SetCurser(false);

        if (currentWordTxt.text.ToLower() == GetComponent<LevelManager>().currentLevelEncryptionKeyl.ToLower())
        {
            //win level
            GetComponent<LevelManager>().FinishLevel();
            Debug.Log("you Win");
        }
    }

    public void SetCurser(bool visible)
    {
        if (!visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Cursor.visible = visible;
    }

    public void SetTextValue(TMP_Text text,string value)
    {
        text.text = value;
    }
     void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
