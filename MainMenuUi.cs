using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    GameObject prevObject;

    [SerializeField]
    GameObject loginPanel, SignUpPanel, mainMenuPanel;

    [SerializeField]
    Button loginBtn, signupBtn, createAccountBtn;
    [SerializeField]
    Button exitBtn, startBtn;

    [SerializeField]
    TMP_InputField userNameLoginInput, passwordLoginInput;
    [SerializeField]
    TMP_InputField userNameSignupInput, passwordSignupInput, confirmPasswordSignupInput;

    [SerializeField]
    TMP_Text errorLogin, errorSignup;

    [SerializeField]
    TMP_Text mainMenuUserName;

    PlayersData getoutPlayers;
    
    private void Start()
    {
        //SaveManager.DeleteData();

        getoutPlayers = SaveManager.LoadData();
        if (SaveManager.currentPlayer != null)
        {
            mainMenuUserName.text = SaveManager.currentPlayer.playerName;
        }
    }
    private void OnEnable()
    {
        loginBtn.onClick.AddListener(Login);
        signupBtn.onClick.AddListener(delegate { SetObjectActive(SignUpPanel); });
        createAccountBtn.onClick.AddListener(CreateAccount);
        exitBtn.onClick.AddListener(ExitGame);
        startBtn.onClick.AddListener(StartGame);
    }
    void Login()
    {
        if (PlayerExist(userNameLoginInput.text) && passwordLoginInput.text == SaveManager.currentPlayer.playerPassword)
        {
            SetObjectActive(mainMenuPanel);
            loginPanel.SetActive(false);
            mainMenuUserName.text = SaveManager.currentPlayer.playerName;
        }
        else
        {
            errorLogin.text = "Wrong name or password!";
            errorLogin.gameObject.SetActive(true);
        }
    }
    void CreateAccount()
    {
        if (passwordSignupInput.text != confirmPasswordSignupInput.text)
        {
            errorSignup.text = "Password Mismatch!";
            errorSignup.gameObject.SetActive(true);
        }
        else if (!CorrentInputLength(new TMP_InputField[] { userNameSignupInput, passwordSignupInput, confirmPasswordSignupInput }))
        {
            errorSignup.text = "Short name or a Password!";
            errorSignup.gameObject.SetActive(true);
        }
        else if (PlayerExist(userNameSignupInput.text))
        {
            errorSignup.text = "Player Already Exist!";
            errorSignup.gameObject.SetActive(true);
        }
        else
        {
            player newPlayer = new player();
            newPlayer.playerName = userNameSignupInput.text;
            newPlayer.playerPassword = passwordSignupInput.text;
            newPlayer.playerScore = 0;

            getoutPlayers.myPlayers.Add(newPlayer);
            SaveManager.SaveData(getoutPlayers);

            SetObjectActive(loginPanel);
            errorSignup.gameObject.SetActive(false);
        }
    }
    bool CorrentInputLength(TMP_InputField[] inputFields)
    {
        foreach(TMP_InputField input in inputFields)
        {
            if (input.text.Length < 3)
            {
                return false;
            }
        }
        return true;
    }
    bool PlayerExist(string newPlayerName)
    {
        foreach(player player in getoutPlayers.myPlayers)
        {
            if (player.playerName == newPlayerName)
            {
                SaveManager.currentPlayer = player;
                return true;
            }
        }
        return false;
    }
    void SetObjectActive(GameObject newGameObject)
    {
        if (prevObject != null) 
        {
            prevObject.SetActive(false);
        }

        newGameObject.SetActive(true);
        prevObject = newGameObject;
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainStory");
    }
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
