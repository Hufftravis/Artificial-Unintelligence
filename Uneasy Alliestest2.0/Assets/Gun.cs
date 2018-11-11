using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform launchPosition;
	private AudioSource audioSource;

	private float currentTime;


	private Rigidbody2D createBullet(){
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;

        //Put in NetworkSurver.spoon
		bullet.transform.position = launchPosition.position;
		return bullet.GetComponent<Rigidbody2D>();

	}
    void firebullet()
    {
		Rigidbody2D bullet = createBullet ();
		bullet.velocity = this.transform.right * 20;
		NetworkServer.Spawn (bullet);

    }


	void Start () {
		//audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
             if (!IsInvoking("firebullet"))
              {
                  InvokeRepeating("firebullet", 0f, 0.1f);

              }
            firebullet();

        }
		if (Input.GetMouseButtonUp(0) )
                {
                    CancelInvoke("firebullet");
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
