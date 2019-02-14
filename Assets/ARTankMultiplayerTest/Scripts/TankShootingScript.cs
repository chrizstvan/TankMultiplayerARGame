using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShootingScript : MonoBehaviour 
{
    PhotonView view;
    public GameObject Bullet;
    public int Force = 30;
    bool ShootTiming = true;

	// Use this for initialization
	void Start () 
    {
        view = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (view.isMine && Input.GetKeyDown(KeyCode.Space) && ShootTiming)
        {
            view.RPC("ShootBullet",PhotonTargets.All,transform.Find("ShootPosition").transform.position,transform.Find("ShootPosition").transform.rotation);

            ShootTiming = false;
            StartCoroutine(SetShootTiming());
        }
	}

    IEnumerator SetShootTiming()
    {
        yield return new WaitForSeconds(1f);
        ShootTiming = true;
    }

    [PunRPC]
    void ShootBullet(Vector3 pos,Quaternion rot)
    {
        GameObject GO = Instantiate(Bullet, pos,rot) as GameObject;
        GO.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Force);
    }
}
