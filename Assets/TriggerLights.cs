using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
	

    public void TurnOnLights()
    {
    	GameObject.Find("Niveau5").transform.GetChild(12).gameObject.SetActive(true);
    	GameObject.Find("Niveau5").transform.GetChild(13).gameObject.SetActive(true);
    	GameObject.Find("Niveau5").transform.GetChild(14).gameObject.SetActive(true);
    	GameObject.Find("Niveau5").transform.GetChild(15).gameObject.SetActive(true);
    }
}
