using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
    	if(player.gameObject.tag == "Player")
    	{
    		
    		player.gameObject.GetComponent<PlayerScript>().haveFallenLvl4 = true;
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
