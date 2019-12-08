using Photon.Pun;
using UnityEngine;

public class SetUp: MonoBehaviourPunCallbacks {

    public GameObject content;
    public GameObject gamePlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
            PhotonNetwork.IsMessageQueueRunning = true;

        //var v = new Vector3(content.transform.position.x, content.transform.position.y);

        //    PhotonNetwork.Instantiate("GamePlayer",v, Quaternion.identity);

        photonView.RPC(nameof(SetUpGamePlayer), RpcTarget.All);
    }

    [PunRPC]
    private void SetUpGamePlayer() {
        Instantiate(gamePlayerPrefab, content.transform, false) ;
    }
}
