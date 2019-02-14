using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int Health;
    PhotonView view;
    Text TxtHealth;
    Text TxtHealthOther;
    Image healthBar;
    Image healthBarOther;

	// Use this for initialization
	void Start () 
    {
        view = GetComponent<PhotonView>();
        TxtHealth = GameObject.Find("TxtHealth").GetComponent<Text>();
        TxtHealthOther = GameObject.Find("TxtHealthOther").GetComponent<Text>();

        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        healthBarOther = GameObject.Find("HealthBarOther").GetComponent<Image>();

        healthBar.fillAmount = Health / 100f;
        healthBarOther.fillAmount = Health / 100f;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && view.isMine)
        {
            Health -= 10;
            TxtHealth.text = "Player 1 : " + Health + "%";
            view.RPC("DemageOther",PhotonTargets.Others,Health);
            healthBar.fillAmount = Health / 100f;
        }    
    }

    // Update is called once per frame
    void Update ()
    {
        if(Health <= 0)
        {
            view.RPC("DestroyGA", PhotonTargets.All);
        }
	}

    [PunRPC]
    void DemageOther(int health)
    {
        TxtHealthOther.text = "Player 2 : " + health + "%";
        healthBarOther.fillAmount = Health / 100f;
    }

    [PunRPC]
    void DestroyGA()
    {
        Destroy(gameObject);
    }
}
