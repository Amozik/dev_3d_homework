using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private bool _isActive = false;

    private bool _prevIsActive = false;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private Animator _animator;
    private NavMeshAgent _navMesh;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _navMesh = GetComponent<NavMeshAgent>();
        
        SetActive(_isActive);
    }

    void Update()
    {
        if (_isActive != _prevIsActive)
        {
            _prevIsActive = _isActive;
            SetActive(_isActive);
        }

        
        if (_navMesh.enabled && _navMesh.remainingDistance > 0 && _navMesh.remainingDistance <= _navMesh.stoppingDistance)
        {
            //Debug.Log(_navMesh.remainingDistance);
            _isActive = true;
        }
    }

    void SetActive(bool value)
    {
        Debug.Log("set active: "+ value);
        _animator.enabled = !value;
        _rigidbodies[0].isKinematic = value;
        _colliders[0].enabled = !value;
        _navMesh.enabled = !value;
        
        
        for (int i = 1; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !value;
        }

        for (int i = 1; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = value;
        }
        
    }
    
}
