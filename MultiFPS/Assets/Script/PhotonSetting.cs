using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    public InputField email;
    public InputField passward;
    public InputField username;
    public InputField region;

    public void LoginSuccess(LoginResult result)
    {
        // 선언하지 않아도 자동으로 false로 설정돼 있음
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.NickName = username.text;

        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.text;

        // scene 이름입력
        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void LoginFailure(PlayFabError error)
    {
        Debug.Log("로그인 실패");
    }
    
    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원 가입 성공");
    }

    public void SignUpFailure(PlayFabError error)
    {
        Debug.Log("회원 가입 실패");
    }

    public void SignUp()
    {
        var reguest = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = passward.text,
            Username = username.text
        };

        // PlayFabClientAPI.RegisterPlayFabUser(회원가입에 대한 정보, 회원가입이 성공했을 때의 함수, 회원가입이 실패했을 때의 함수)
        PlayFabClientAPI.RegisterPlayFabUser(reguest, SignUpSuccess, SignUpFailure);
    }

    public void Login()
    {
        var reguest = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = passward.text,
        };

        // PlayFabClientAPI.LoginWithEmailAddress(로그인에 대한 정보, 로그인이 성공했을 때의 함수, 로그인이 실패했을 때의 함수)
        PlayFabClientAPI.LoginWithEmailAddress(reguest, LoginSuccess, LoginFailure);
    }
}
