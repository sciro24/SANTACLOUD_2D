using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class LoginPagePlayFab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TopText;
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordlLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField UsernameRegisterInput;
    [SerializeField] TMP_InputField PasswordlRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] TMP_InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoverPage;

    [SerializeField]
    private GameObject WelcomeObject;

    [SerializeField]
    private TextMeshProUGUI WelcomeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Buttom Functions

    public void RegisterUser() {
  
        var request = new RegisterPlayFabUserRequest {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordlRegisterInput.text,
            
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSuccess, OnError);
    } 

    public void Login() {
        var request = new LoginWithEmailAddressRequest {
            Email = EmailLoginInput.text,
            Password = PasswordlLoginInput.text,

            InfoRequestParameters =  new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult Result) {
            string name = null;
            
            if(Result.InfoResultPayload != null) {
                name = Result.InfoResultPayload.PlayerProfile.DisplayName;
            }
            WelcomeObject.SetActive(true);
            WelcomeText.text = "Welcome " + name;
            StartCoroutine(LoadNextScene());
    }
    
    public void RecoverUser() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = EmailRecoveryInput.text,
            TitleId = "EF74A",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnErrorRecovery);
    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult Result) {
        OpenLoginPage();
        MessageText.text = "Recovery Mail Sent";
    }

    private void OnErrorRecovery(PlayFabError result) {
        MessageText.text = "No Email Found!";
    }

    private void OnError(PlayFabError Error) {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport()); 
    }

    private void OnregisterSuccess(RegisterPlayFabUserResult Result) {
            MessageText.text = "New Account Is Created";
            OpenLoginPage();
    }

    public void OpenLoginPage() {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoverPage.SetActive(false);
        TopText.text = "Login";
    }

    public void OpenRegisterPage() {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoverPage.SetActive(false);
        TopText.text = "Register";
    }

    public void OpenRecoveryPage() {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoverPage.SetActive(true);
        TopText.text = "Recovery";
    }
    #endregion

    IEnumerator LoadNextScene() {
        yield return new WaitForSeconds(2);
        MessageText.text = "Loggin in";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

/*
    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest {
                Statistics = new List<StatisticUpdate>{
                    new StatisticUpdate {
                        StatisticName = "GiftsScore",
                        Value = score
                    }
                }
        };
    PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdaetPlayerStatisticsResult result){
        Debug.Log("Successfull leaderboard sent !");
    }
*/
}
