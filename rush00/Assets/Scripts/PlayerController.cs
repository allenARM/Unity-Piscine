using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
	public bool	HasGun;
	public GameObject Gun;
    public float direction;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update

    public Camera cc;
    [HideInInspector]public Transform my;
    private Rigidbody2D body;
	private GameObject tmp;
	private Animator animator;
	public PlayerAudioController audioController;
    void Start()	{ }
    void Awake()
    {
		Gun.SetActive(false);
		HasGun = false;
        cc = GameObject.Find("Main Camera").GetComponent<Camera>();
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
		animator = transform.Find("legs").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
		//movement
		horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
		diff = new Vector3(horizontal * speed, vertical * speed, 0);
        body.velocity = diff;
		//set leg animation parameter
		if (horizontal != 0 || vertical != 0)
			animator.SetBool("isMoving", true);
		else
			animator.SetBool("isMoving", false);
        //move cam
        cc.transform.position = new Vector3(my.position.x, my.position.y, -10);
		MakeDmg();
		DropGun();
    }
	void MakeDmg()
	{
		if (Input.GetMouseButtonDown(0) && Gun.GetComponent<GunManager>().NumOfBullets > 0)
		{
			GetComponent<PlayerAudioController>().playSound("shoot");
			Gun.GetComponent<GunManager>().Shoot();
		}
		if (Input.GetMouseButtonDown(0) && Gun.GetComponent<GunManager>().IsMelee)
			Gun.GetComponent<GunManager>().CheckForEnemy = true;
		if (Input.GetMouseButtonUp(0))
			Gun.GetComponent<GunManager>().CheckForEnemy = false;
	}
	void DropGun()
	{
		if (Input.GetMouseButtonDown(1) && HasGun)
		{
			audioController.playSound("drop");
			GunManager gm = Gun.GetComponent<GunManager>();
			HasGun = false;
			Gun.SetActive(false);
			gm.CurrentGun.GetComponent<GunPickUp>().NumOfBullets = gm.NumOfBullets;
			gm.NumOfBullets = 0;
			gm.CurrentGun.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
			gm.CurrentGun.SetActive(true);
			gm.CurrentGun = null;
		}	//add function drop gun forward;
	}
}