using System;
using UnityEngine;
using UniRx;

namespace _.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float attackDamage;
        [SerializeField] public float dashSpeed;
        [SerializeField] public float dashTime;
        [SerializeField] private GameObject attackWeapon;
        [SerializeField] private GameObject dashWeapon;
        [SerializeField] private GameObject dashPreviewObj;

        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Move(Vector3 dir)
        {
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
    }
}