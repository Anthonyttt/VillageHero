using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class LoginPlayfab : MonoBehaviour
{
    [Header("UI")] public Text messageText;
    public InputField userName;
    public InputField password;
    public InputField nameInput;
    public GameObject nameBox;
    public GameObject rankButton;

    public void RegisterButton()
    {
        if (password.text.Length < 6)
        {
            messageText.text = "密码长度至少为6位";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = userName.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterSuccess,OnError);
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest()
        {
            Email = userName.text,
            Password = password.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request,OnLoginSuccess,OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = userName.text,
            TitleId = "1EDC8"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,OnPasswordReset,OnError);
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request,OnDisplayNameUpdate,OnError);
        
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "注册并登入";
        rankButton.SetActive(true);
        nameBox.SetActive(true);
        ClosePanel();
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "登入成功";
        rankButton.SetActive(true);
        ClosePanel();
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "密码已重置";
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        nameBox.SetActive(false);
        Debug.Log("Update display name");
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    
    
    
}
