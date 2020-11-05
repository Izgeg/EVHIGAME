using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortailTrigger : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {   
    }
    private void OnTriggerEnter(Collider player)
    {
    	if(player.gameObject.tag == "Player")
    	{
    		//Debug.Log("Yemek");
    		player.gameObject.GetComponent<PlayerScript>().goingToBoss = true;
            
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
