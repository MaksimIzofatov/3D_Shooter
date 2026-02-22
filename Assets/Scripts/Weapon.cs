using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponName _weaponName;
        [SerializeField] private float _damage;
        [SerializeField] private GameObject _test;
        
        private Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);
        public void Shot(Camera camera)
        {
            Ray ray = camera.ViewportPointToRay(_screenShotPercent);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(_test, hit.point, Quaternion.identity);
            }
        }
    }

    public enum WeaponName
    {
        M4,
        PoliceGun,
        MachineGun
    }
}