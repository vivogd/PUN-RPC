using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MasterTag : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject cube;
    void Start()
    {

        SetIsMasterTag();
    }

    private void SetIsMasterTag()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                cube.SetActive(true);
            }
            else
            {
                cube.SetActive(false);
            }

        }
        else
        {
            cube.SetActive(false);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {

        SetIsMasterTag();
    }

}
