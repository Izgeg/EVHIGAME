using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GunScript : MonoBehaviour
{

	public float damage = 1f;
	public float range = 100f;
	public float fireRate = 3f;

	public int maxAmmo = 12;
	private int currentAmmo;
	public float reloadTime = 2f;
    public float timerReload;
	private bool isReloading = false;
	public Text ammoDisplay;
	public Camera fpsCam;
	public ParticleSystem shootingEffect;
	public GameObject impactEffect;
    
	private float nextTimeToFire;
    // Update is called once per frame
    
	
    void Start()
    {
   		currentAmmo = maxAmmo;
    }
    void Update()
    {
    	/*if(isReloading)
    	{
    		return;
    	}

    	if(currentAmmo <= 0)
    	{
    		StartCoroutine(Reload());
    		return;
    	}*/

    	if(currentAmmo == 0 && !isReloading)
    	{
            timerReload = 0f;
            isReloading = true;
    	}
        if(currentAmmo == 0 && isReloading)
        {
            timerReload += Time.deltaTime;
            if(timerReload >= reloadTime)
            {
                Reload();
                isReloading = false;
            }

        }
    	ammoDisplay.text = currentAmmo.ToString();
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
        	nextTimeToFire = Time.time + 1f/fireRate;
        	Shoot();
        }
    }

    void Shoot()
    {
    	shootingEffect.Play();

    	currentAmmo--;
    	RaycastHit hit;
    	if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    	{
    		//Debug.Log(hit.transform.name);

    		Target target = hit.transform.GetComponent<Target>();
    		TriggerDoors cible = hit.transform.GetComponent<TriggerDoors>();
            TriggerDoorUnderground cible_g = hit.transform.GetComponent<TriggerDoorUnderground>();
            TargetBoss target_b = hit.transform.GetComponent<TargetBoss>();
            TriggerLights target_l = hit.transform.GetComponent<TriggerLights>();
    		if(target != null)
    		{
    			target.TakeDamage(damage);
    		}
    		if(cible != null)
    		{
    			cible.OpenDoor();
    		}
            if(cible_g != null)
            {
                cible_g.OpenDoor();
            }
            if(target_b != null)
            {
                target_b.TakeDamage(damage);
            }
            if(target_l != null)
            {
                target_l.TurnOnLights();
            }


    		GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    		Destroy(impactGO, 1f);
    	}
    }

    void Reload()
    {
    	currentAmmo = maxAmmo;
    }
    /*
    IEnumerator Reload()
    {
    	isReloading = true;
    	Debug.Log("Reloading...");

    	yield return new WaitForSeconds(reloadTime);
    	currentAmmo = maxAmmo;
    	isReloading = false;
    }*/


    
}
