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

        [Header("Pull Setting")] [SerializeField]
        private float extendTime;

        [SerializeField] private float maxDistance;
        [SerializeField] private GameObject distanceVisualizeObecjt;
        private float _currentExtendTime;
        private bool _stopExtend;
        private List<IPullable> _pullTargetList = new List<IPullable>();
        private IPullable _currentPullObject;

        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _currentExtendTime = extendTime;
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

        private IPullable[] _pullableObjects;

        public void SetPullTarget()
        {
            Vector3 myPosition = transform.position;

            Collider[] colliders = Physics.OverlapSphere(myPosition, maxDistance);

            _pullableObjects = new IPullable[colliders.Length];
            int pullableCount = 0;

            foreach (var collider in colliders)
            {
                // 检查碰撞器上是否有IPullable组件
                IPullable pullable = collider.GetComponent<IPullable>();
                if (pullable != null)
                {
                    // 如果是IPullable对象，将其存入数组
                    _pullableObjects[pullableCount] = pullable;
                    pullableCount++;
                }
            }
        }

        public void PullTarget()
        {
        }

        #endregion
    }
}