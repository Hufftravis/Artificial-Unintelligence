using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : NetworkBehaviour {
    public GameObject bulletPrefab;
    public Transform launchPosition;
	private AudioSource audioSource;

	private float currentTime;


	private Rigidbody2D createBullet(){
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;

        //Put in NetworkSurver.spoon
		bullet.transform.position = launchPosition.position;
		NetworkServer.Spawn (bullet);
		return bullet.GetComponent<Rigidbody2D>();

	}
	[Command]
    void Cmdfirebullet()
    {
		Rigidbody2D bullet = createBullet ();
		bullet.velocity = this.transform.right * 20;


    }


	void Start () {
		//audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
             if (!IsInvoking("Cmdfirebullet"))
              {
                  InvokeRepeating("Cmdfirebullet", 0f, 0.1f);

              }
            Cmdfirebullet();

        }
		if (Input.GetMouseButtonUp(0) )
                {
                    CancelInvoke("Cmdfirebullet");
                }
        

	}
	/*private void processHit(GameObject hitObject) {
		if (hitObject.GetComponent<PlayerController>() != null) {
			hitObject.GetComponent<PlayerController>().TakeDamage(damage);
		}

		if (hitObject.GetComponent<Enemy>() != null) {
			hitObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}*/

}
