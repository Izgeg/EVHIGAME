using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorUnderground : MonoBehaviour
{
	public Transform Door;
	public bool doorOpening = false;
	public bool doorOpened = false;
	public SpriteRenderer sprite;
	public MeshRenderer mesh;
	public EnemyAI enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpening && !doorOpened)
        {
        	Door.Translate(Vector3.up * 3.0f * Time.deltaTime);
        }

        if(Door.localPosition.y >= 1.2f)
        {
        	enemy.sightRange = 0.0f;
        	if(Door.localPosition.y >= 2.85f)
        	{
        		doorOpened = true;
        		//mesh.enabled = false;
        	}
        }
        
    }

    public void OpenDoor()
    {
    	sprite.enabled = false;
    	doorOpening = true;
    	mesh.material.color = Color.green;
    }
}
