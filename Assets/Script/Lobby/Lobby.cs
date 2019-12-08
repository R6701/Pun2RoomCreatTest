using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby: MonoBehaviourPunCallbacks {
    private void Start() {
        //Photonにつなげるために初めに実装する→MonoBehaviourPunCallbacksの中にあるメソッドを使える
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    //部屋が作られていた場合入室する
    public override void OnJoinedRoom() {
        //メッセージの送信をいったん止める
        PhotonNetwork.IsMessageQueueRunning = false;

        SceneManager.LoadScene("Game");
    }


}
