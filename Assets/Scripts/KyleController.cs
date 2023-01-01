using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class KyleController : MonoBehaviourPun
{
    Animator anim;
    Vector2 dir;

    float angularSpeed=100f;
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetFloat("Speed", dir.y );
        anim.SetFloat("Direction", dir.x );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
}
