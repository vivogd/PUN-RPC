using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    
    [SerializeField] UIManager uiManager;
    bool isFirstTime = true;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
        
        PhotonNetwork.NickName = "Player_" + Random.Range(0, 1000);
        
        uiManager.AddTitle(PhotonNetwork.NickName + " is connecting ");
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void CreateRandomRoom()
    {
     
        //No random room available, so we create one
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 10;

        string roomName = "Room_" + Random.Range(0, 1000);

        PhotonNetwork.CreateRoom(null, roomOptions); // we can also put null in room name and photon will alocate a radom room
    }

    #region Photon Callbacks

    public override void OnConnected()
    {
        Debug.Log("Connected to internet");
    }

    public override void OnConnectedToMaster()
    {

        //The first we try to do is to join a potential existing room.
        PhotonNetwork.JoinRandomRoom();
        uiManager.AddTitle(PhotonNetwork.NickName + " is trying to join room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        uiManager.AddTitle("Joining room failed. Creating a room");
        CreateRandomRoom();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        CreateRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        uiManager.AddTitle("Room "+PhotonNetwork.CurrentRoom.Name + " created");
    }


    public override void OnJoinedRoom()
    {

        uiManager.AddTitle(PhotonNetwork.NickName + " has joined a room" + PhotonNetwork.CurrentRoom.Name);
         
        if (PhotonNetwork.IsMasterClient)
        {
             PhotonNetwork.LoadLevel("Level1");
        }
      

    }

   





    



    #endregion

}
