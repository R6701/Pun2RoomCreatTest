using Photon.Pun;
using UnityEngine;

public class ChatSystem : MonoBehaviourPunCallbacks {

    public Access access;
    public GameObject content;
    public GameObject chatNode;

    public void CreateChatNode() {
        photonView.RPC(nameof(CreateNode), RpcTarget.All);
    }

    [PunRPC]
    private void CreateNode() {
        Instantiate(chatNode, content.transform, false);
    }

    //???

    public void test() {
        Debug.Log(access.allPlayers[0].ToString());
    }
}
