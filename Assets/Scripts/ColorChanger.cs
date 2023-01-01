using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
 
public class ColorChanger : MonoBehaviourPun
{
 
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null) return;
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SetRandomColor();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                photonView.RPC("ChangeRandomColor", RpcTarget.All);
            }
        }
       
    }

    [PunRPC]
    private void ChangeRandomColor()
    {
        Color color = Random.ColorHSV();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    [PunRPC]
    private void ChangeColor(float r, float g,float b,PhotonMessageInfo info)
    {
        Debug.Log(info.Sender);
        Debug.Log(info.photonView);
        Color color = new Color(r, g, b);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    private void SetRandomColor()
    {
        Color color = Random.ColorHSV();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        
        photonView.RPC("ChangeColor", RpcTarget.All, color.r,color.g,color.b);
    }





}
