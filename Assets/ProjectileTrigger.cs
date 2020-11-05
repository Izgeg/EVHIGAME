using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
    	if(player.gameObject.tag == "Player")
    	{
    		//Debug.Log("Yemek");
    		player.gameObject.GetComponent<PlayerScript>().tookAHit = true;
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
