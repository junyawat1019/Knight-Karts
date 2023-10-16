using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using QuantumTek.QuantumUI;

namespace DarylProductions
{
    public class PlayfabManager : MonoBehaviour
    {
        public static PlayfabManager Instance;
        void Awake()
        {
            Instance = this;
        }

        [Header("UI")]
        public Text messageText;

        [SerializeField] public string username, emailAddress, password;
        #region Unity Methods
        void Start()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            {
                PlayFabSettings.TitleId = "4252C";
            }
        }
        #endregion
        #region Login
        /*
        private void LoginWithCustomId()
        {
            Debug.Log($"Login to Playfab as {username}");
            var request = new LoginWithCustomIDRequest { CustomId = username, CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginCustomIdSuccess, OnFailure);
        }
        private void UpdateDisplayName(string displayname)
        {
            Debug.Log($"Updating Playfab account's Display name to: {displayname}");
            var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayname };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSuccess, OnFailure);
        }
        */
        public void Login()
        {
            var request = new LoginWithPlayFabRequest
            {
                Username = username,
                Password = password,
            };
            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
        }
        #endregion
        #region Register
        private bool IsValidUsername()
        {
            bool isValidU = false;

            if (username.Length >= 3 && username.Length <= 24)
            {
                isValidU = true;
            }
            else { messageText.text = "Username not valid!"; }
            return isValidU;
        }
        private bool IsValidPassword()
        {
            bool isValidP = false;

            if (password.Length > 6)
            {
                isValidP = true;
            }
            else { messageText.text = "Password too short!"; }
            return isValidP;
        }
        public void RegisterAccount()
        {
            if (!IsValidUsername()) return;
            if (!IsValidPassword()) return;
            var request = new RegisterPlayFabUserRequest
            {
                Username = username,
                Email = emailAddress,
                Password = password,
                RequireBothUsernameAndEmail = true
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        }
        #endregion
        #region ResetPassword
        public void SendRecovery()
        {
            var request = new SendAccountRecoveryEmailRequest
            {
                Email = emailAddress,
                TitleId = "4252C"
            };
            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
        }
        #endregion
        #region Playfab Callbacks
        private void OnLoginSuccess(LoginResult result)
        {
            messageText.text = "Login Seccessful!";
            QUI_SceneTransition.Instance.LoadScene("Launch");
        }
        private void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            messageText.text = "Register and logged in!";
            QUI_SceneTransition.Instance.LoadScene("Launch");
        }
        private void OnPasswordReset(SendAccountRecoveryEmailResult result)
        {
            messageText.text = "Password reset mail sent!";
        }
        private void OnError(PlayFabError error)
        {
            messageText.text = error.ErrorMessage;
            Debug.Log(error.GenerateErrorReport());
        }
        /*
        private void OnLoginCustomIdSuccess(LoginResult result)
        {
            messageText.text = "You have logged into Playfab using custom id ";
            UpdateDisplayName(username);
        }
        private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
        {
            Debug.Log($"You have updated the displayname of the playfab account!");
            SceneController.LoadScene("MainMenu");
        }
        */
        #endregion
    }
}