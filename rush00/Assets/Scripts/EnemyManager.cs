using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Vector3 _playerPos;
    public GameObject Enemy;
    public GameObject EnemyGun;
    public bool CanFire;
    // Start is called before the first frame update
    void Start()
    {
        EnemyGun.GetComponent<GunManager>().NumOfBullets = 100000;
		StartCoroutine(Fire()); //Enemy Fire Disable for Debug
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            CanFire = true;

            _playerPos = col.gameObject.transform.position - Enemy.transform.position;
            _playerPos.Normalize();

            float rot_z = Mathf.Atan2(_playerPos.y, _playerPos.x) * Mathf.Rad2Deg;
            Enemy.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
            if (Vector3.Distance(col.gameObject.transform.position, Enemy.transform.position) > 2f)
                Enemy.GetComponent<Rigidbody2D>().MovePosition(Enemy.transform.position + _playerPos * Time.deltaTime * 5);
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);
        if (CanFire)
        {
            GetComponent<EnemyAudioController>().playSound("shoot");
            EnemyGun.GetComponent<GunManager>().Shoot();
			CanFire = false;
        }
        StartCoroutine(Fire());
    }
}
