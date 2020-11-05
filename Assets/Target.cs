using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 5f;

	public Color defaut = Color.black;
	public Color degat = Color.red;
	private Renderer rend; 
	private float timer;
	
	void Start()
	{
		rend = transform.GetComponent<Renderer>();
	}
	void Update()
	{
		if(timer >= 0)
		{	
			//Debug.Log("BG");
			rend.material.color = degat;
			timer -= Time.deltaTime;
		}
		else
		{
			rend.material.color = defaut;
		}
	}

	public void TakeDamage(float amount)
	{
		timer = 0.5f;
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}


	}

	void Die()
	{
		if(transform.parent != null)
		{
			Destroy(transform.parent.gameObject);
		}
	}


}