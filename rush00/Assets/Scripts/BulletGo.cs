using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGo : MonoBehaviour
{
	public string Tag;
	Vector3 mouse;
	Ray2D ray;
	RaycastHit hit;
	void Start()
    {
		hit = new RaycastHit();
		mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg + 180;
        gameObject.GetComponent<Rigidbody2D>().rotation = angle;
		mouse = new Vector3(mouse.x, mouse.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.left * Time.deltaTime * 20);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag(Tag) || col.gameObject.CompareTag("Wall"))
		{
			if (col.gameObject.CompareTag(Tag))
			{
				if (col.gameObject.CompareTag("Player"))
				{
					Time.timeScale = 0;
					Camera.main.GetComponent<EndMenu>().EnableMenu();
				}
				Debug.Log("ENEMY KILLED");
				Destroy(col.gameObject);
			}	//col.gameObject.PlayDeath();
			Destroy(gameObject);
		}
	}
}
