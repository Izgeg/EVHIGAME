using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckPointLv4 : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider player)
    {
    	if(player.gameObject.tag == "Player")
    	{
    		//Debug.Log("CheckPoint");
    		player.gameObject.GetComponent<PlayerScript>().checkPointedLevel4 = true;
    	}
    }

    

}
