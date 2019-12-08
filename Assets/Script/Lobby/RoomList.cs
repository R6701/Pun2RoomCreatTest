using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(ScrollRect))]
public class RoomList : MonoBehaviourPunCallbacks {

    [SerializeField] private RoomListEntry roomListEntryPrefab = default;
    private ScrollRect scrollRect;
    private Dictionary<string, RoomListEntry> activeEntries = new Dictionary<string, RoomListEntry>();
    private Stack<RoomListEntry> inactiveEntries = new Stack<RoomListEntry>();

    private void Awake() {
        scrollRect = GetComponent<ScrollRect>();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        foreach(var info in roomList) {
            RoomListEntry entry;
            if(activeEntries .TryGetValue(info.Name, out entry)) {
                if (!info.RemovedFromList) {
                    entry.Activate(info);
                } else {
                    activeEntries.Remove(info.Name);
                    entry.Deactivate();
                    inactiveEntries.Push(entry);
                }
            }else if (!info.RemovedFromList) {
                entry = (inactiveEntries.Count > 0)
                    ? inactiveEntries.Pop().SetAsLastSibling()
                    : Instantiate(roomListEntryPrefab, scrollRect.content);
                entry.Activate(info);
                activeEntries.Add(info.Name, entry);
            }
        }
    }

    public void CreatePrivateRoom(string roomName) {
        PhotonNetwork.CreateRoom(
            roomName,
            new RoomOptions() {
                MaxPlayers = 4,
                IsVisible = false
        }); 
    }
}
