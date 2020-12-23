using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField] private Transform _rightHandObj = null;
    [SerializeField] private Transform _leftHandObj = null;
    [SerializeField] private Transform _lookObj = null;
    [SerializeField] private LayerMask _rayLayer;

    [SerializeField] private bool _ikActive = false;
    
    private Animator _animator;
    private Transform _headPos;
    private RaycastHit _hit;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _headPos = _animator.GetBoneTransform(HumanBodyBones.Head);
    }

    private void OnAnimatorIK()
    {
        if (_animator)
        {
            if (_ikActive)
            {
                if (_lookObj != null)
                {
                    Vector3 direction = _lookObj.position - _headPos.position;// + Vector3.up;

                    if (Physics.Raycast(_headPos.position, direction, out _hit, 2.0f, _rayLayer))
                    {
                        Debug.DrawRay(_headPos.position, direction, Color.yellow);
                        _animator.SetLookAtWeight(1);
                        _animator.SetLookAtPosition(_lookObj.position);
                    }
                    else
                    {
                        Debug.DrawRay(_headPos.position, direction, Color.red);
                    }

                }
                
                if (_rightHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObj.rotation);
                }
                
                if (_leftHandObj != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObj.rotation);
                }

            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetLookAtWeight(0);
            }
        }
    }
}
