using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALS.BohlPon
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private GameObject _projectile;
        [SerializeField] private float _force;

        public void LaunchProjectile(Vector3 direction)
        {
            Vector3 velocity = direction * _force;
            GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);

            //casting
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (!rb) return;
            rb.AddForce(velocity, ForceMode.Impulse);
        }
    }
}