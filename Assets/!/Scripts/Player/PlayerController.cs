using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace _.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float rotateSpeed;

        [Header("Attack Setting")] [SerializeField]
        private float attackDamage;

        [SerializeField] private GameObject attackWeapon;

        [Header("Dash Setting")] [SerializeField]
        public float dashSpeed;

        [SerializeField] public float dashTime;
        [SerializeField] private GameObject dashWeapon;
        [SerializeField] private GameObject dashPreviewObj;

        [Header("Pull Setting")] 
        [SerializeField]private float pullTime;
        [SerializeField] private float pullMaxDistance;
        private bool _stopExtend;
        private IPullable _currentPullObject;
        private PullDetect _pullDetect;

        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _pullDetect ??= GetComponentInChildren<PullDetect>();
        }

        public void Move(Vector3 dir)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
            _controller.Move(dir * (walkSpeed * (Time.deltaTime)));
        }

        public void Attack()
        {
            attackWeapon.SetActive(true);
            // Observable.Timer(TimeSpan.FromSeconds(0.2))
            //     .Subscribe(_ =>
            //     {
            //         attackWeapon.SetActive(false);
            //     });
        }

        #region Dash

        private Vector3 _dashDir;

        public void ShowDashDirection()
        {
            _dashDir = GetDirection();
            dashPreviewObj.SetActive(true);
            dashPreviewObj.transform.LookAt(_dashDir);
        }

        public void Dash()
        {
            dashPreviewObj.SetActive(false);
            dashWeapon.SetActive(true);

            transform.LookAt(_dashDir);

            var doDash = Observable.EveryFixedUpdate();
            var timerSubscription = doDash.Subscribe(_ =>
            {
                _controller.Move(transform.forward * (Time.deltaTime * dashSpeed));
            });


            Observable.Timer(TimeSpan.FromSeconds(dashTime)).Subscribe(_ =>
            {
                Debug.Log("end dash");
                timerSubscription.Dispose();
                dashWeapon.SetActive(false);
            });
        }

        Vector3 GetDirection()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var layerMask = ~(1 << 6);
            RaycastHit hit;
            var hitpoint = Vector3.zero;
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                hitpoint = hit.point;
                hitpoint.y = transform.position.y;
                return hitpoint;
            }

            return hitpoint;
        }

        #endregion

        #region Pull

        public void SetPullTarget()
        {
            _pullDetect.SetDetectRange(pullMaxDistance);
            GetTarget();
            SetTargetPullDirection();
        }

        void GetTarget()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var layerMask = ~(1 << 2);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    GameObject hitObject = hit.collider.gameObject;
                    Debug.Log($"{hitObject.name}");

                    if (hitObject == null)
                    {
                        return;
                    }

                    if (hitObject.TryGetComponent<IPullable>(out var pullable))
                    {
                        if (_currentPullObject != null)
                            _currentPullObject.PullDirection = Vector3.zero;
                        if (_pullDetect.PullableObjects.Contains(pullable))
                        {
                            _currentPullObject = pullable;
                        }

                        Debug.Log($"選中 {hitObject.name}");
                    }
                }
            }
        }

        void SetTargetPullDirection()
        {
            if (_currentPullObject == null) return;
            if (Input.GetMouseButtonUp(0))
            {
                _currentPullObject = null;
                return;
            }

            var hitpoint = Vector3.zero;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity))
            {
                hitpoint = hitInfo.point;
            }

            // hitpoint.y = 0;
            _currentPullObject.PullDirection = hitpoint;
        }

        public void PullTarget()
        {
            _pullDetect.SetDetectRange(0);
            foreach (var VARIABLE in _pullDetect.PullableObjects)
            {
                VARIABLE.Pull();
            }
        }

        #endregion

        #region Fall

        public void Fall()
        {
            
        }
        

        #endregion
    }
}