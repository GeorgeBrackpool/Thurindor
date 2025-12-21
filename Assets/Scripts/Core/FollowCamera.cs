using UnityEngine;

namespace Thurindor.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}
