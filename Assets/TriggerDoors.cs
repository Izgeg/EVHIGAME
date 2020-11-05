using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoors : MonoBehaviour
{
	public Transform Door;
	public bool doorOpening = false;
	public bool doorOpened = false;
	public SpriteRenderer sprite;
	public MeshRenderer mesh;
	public Vector3 positionBase;
	//public Vector3 localPos;
    // Start is called before the first frame update
    void Start()
    {
        positionBase = Door.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
    	//localPos = Door.localPosition;
        if (doorOpening && !doorOpened)
        {
        	Door.Translate(Vector3.right * Time.deltaTime);
        }
        if(Vector3.Distance(Door.localPosition, positionBase) >= 5.0f)
        {
        	doorOpened = true;
        	mesh.enabled = false;
        }
    }

    public void OpenDoor()
    {
    	sprite.enabled = false;
    	doorOpening = true;
    	mesh.material.color = Color.green;
    }
}
