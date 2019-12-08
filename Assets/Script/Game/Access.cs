using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


/// <summary>
/// 出入りを制御
/// </summary>
public class Access : MonoBehaviourPunCallbacks {


    public Player[] allPlayers = PhotonNetwork.PlayerList;
    public Player[] otherPlayers = PhotonNetwork.PlayerListOthers;
    public PhotonView[] photonViews = PhotonNetwork.PhotonViews;
    //GMチャットに使える？
    public override void OnPlayerEnteredRoom(Player player) {
        Debug.Log(player.NickName + "が参加しました");
    }

    public override void OnPlayerLeftRoom(Player player) {

        Debug.Log(player.NickName + "が退出しました");
    }
}
