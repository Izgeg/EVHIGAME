using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCubeTrigger : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0.0f, 45.0f, 0.0f);
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
    	if(player.gameObject.tag == "Player")
    	{
    		player.gameObject.GetComponent<PlayerScript>().tookAHealing = true;
    		Destroy(transform.gameObject);
    	}
    }
    // Update is called once per frame
    void Update()
    {
    	
        transform.Rotate(rotation*Time.deltaTime);
    }
}
