using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class CubeSpawner : MonoBehaviourPun
{
    [SerializeField]
    GameObject cubePrefab;
    void Update()
    {

        if (photonView.IsMine==false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        PhotonNetwork.Instantiate(cubePrefab.name, transform.position, Quaternion.identity);
    }
}
