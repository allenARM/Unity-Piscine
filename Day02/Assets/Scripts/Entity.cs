using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private enum MoveState{Stay, Walk}
    private MoveState _moveState;
    private Vector3 _targetPos;
    public float Speed = 2f;
    private Animator _anim;
    public AudioClip    TellYes;
    private AudioSource _audio;
    public void Move(Vector2 pos)
    {
        _moveState = MoveState.Walk;
        _targetPos = pos;
        transform.up = _targetPos;
        Vector3 dir = _targetPos - transform.position;
        float ang = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(ang, -Vector3.forward);
        _anim.SetBool("Movement", true);
        _audio.clip = TellYes;
        _audio.Play(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        _moveState = MoveState.Stay;
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveState == MoveState.Walk)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, Speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, _targetPos) < 0.01f)
        {
            _moveState = MoveState.Stay;
            _anim.SetBool("Movement", false);
        }
    }
}
