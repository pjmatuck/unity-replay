using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] float timeToLongIdle;
    
    Rigidbody _rigidbody;
    Vector3 _input;
    bool _isDancing;
    
    static readonly int Walk = Animator.StringToHash("Walk");
    static readonly int Dance = Animator.StringToHash("Dance");
    static readonly int LongIdle = Animator.StringToHash("LongIdle");

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if(_input.magnitude > 0)
            animator.SetBool(Walk, true);
        else
            animator.SetBool(Walk, false);

        _rigidbody.velocity = _input * (speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isDancing)
            {
                _isDancing = false;
                var animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
                var animParameters = animator.parameters;
                animator.SetBool(Dance, false);
                return;
            } 

            _isDancing = true;
            animator.SetBool(Dance, true);
        }
    }
}
