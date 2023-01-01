using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;
    PhotonView photonView; 
    float health = 1;
    private void Start()
    {
    
        photonView = GetComponent<PhotonView>();
        UpdateBar();
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                ApplyDamage();
            };  
        }
    }
    public void ApplyDamage()
    {
        if(health > 0)
        {
            health -= 0.1f;
            photonView.RPC("SetNewHealth", RpcTarget.AllBuffered, health);
        }
        

    }

    [PunRPC]
    private void SetNewHealth(float _health)
    {
        health = _health; ;
        UpdateBar();
    }


    private void UpdateBar()
    {
        healthBar.value = health;
    }

}
