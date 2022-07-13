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
        // �������� �ʾƵ� �ڵ����� false�� ������ ����
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.NickName = username.text;

        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.text;

        // scene �̸��Է�
        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void LoginFailure(PlayFabError error)
    {
        Debug.Log("�α��� ����");
    }
    
    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("ȸ�� ���� ����");
    }

    public void SignUpFailure(PlayFabError error)
    {
        Debug.Log("ȸ�� ���� ����");
    }

    public void SignUp()
    {
        var reguest = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = passward.text,
            Username = username.text
        };

        // PlayFabClientAPI.RegisterPlayFabUser(ȸ�����Կ� ���� ����, ȸ�������� �������� ���� �Լ�, ȸ�������� �������� ���� �Լ�)
        PlayFabClientAPI.RegisterPlayFabUser(reguest, SignUpSuccess, SignUpFailure);
    }

    public void Login()
    {
        var reguest = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = passward.text,
        };

        // PlayFabClientAPI.LoginWithEmailAddress(�α��ο� ���� ����, �α����� �������� ���� �Լ�, �α����� �������� ���� �Լ�)
        PlayFabClientAPI.LoginWithEmailAddress(reguest, LoginSuccess, LoginFailure);
    }
}
