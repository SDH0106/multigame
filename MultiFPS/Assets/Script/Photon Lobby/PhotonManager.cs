using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public Button connect;
    public Text currentRegion;
    public Text currentLobby;

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        currentRegion.text = PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion;

        Debug.Log(Data.count);
        Debug.Log(currentLobby.text);
        switch (Data.count)
        {
            case 0:
                currentLobby.text = "First Lobby";
                break;
            case 1:
                currentLobby.text = "Second Lobby";
                break;
            case 2:
                currentLobby.text = "Third Lobby";
                break;
        }
    }

    // 포톤 서버 접속 후 호출되는 콜백함수
    // 로비 접속 여부 확인 가능
    public override void OnConnectedToMaster()
    {
        // 특정 로비를 생성하여 진입
        switch(Data.count)
        {
            case 0:
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 1", LobbyType.Default));
                break;
            case 1:
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 2", LobbyType.Default));
                break;
            case 2:
                PhotonNetwork.JoinLobby(new TypedLobby("Lobby 3", LobbyType.Default));
                break;
        }
    }

    // 로비 접속 후 호출되는 콜백함수    
    public override void OnJoinedLobby()
    {
        // PhotonNetwork.LoadLevel: scene 동기화
        // 일반 LoadLevel은 scene 동기화 불가능
        PhotonNetwork.LoadLevel("Photon Room");
    }
}
