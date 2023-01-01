using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NameTag : MonoBehaviourPun
{
    [SerializeField] TextMeshPro nameTag;
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {

            nameTag.text = photonView.Owner.NickName;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
