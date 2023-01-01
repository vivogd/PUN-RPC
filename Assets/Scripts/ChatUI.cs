using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class ChatUI : MonoBehaviourPun
{
    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    TextMeshProUGUI msgText;
  


    public void OnSendPressed()
    {
        {
            string msg1 = PhotonNetwork.NickName;
            string msg2 = inputField.text;
            
            photonView.RPC("SetChatMsg", RpcTarget.AllBuffered, msg1, msg2);
        }
     
    }

    [PunRPC]
    void SetChatMsg(string nickname, string msg)
    {
        msgText.text += nickname + ": " + msg + "\n";
    }

}
