using UnityEngine;

namespace camera
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private Transform Target;
        [SerializeField] private float damping;
        [SerializeField] private float Distance;
        [SerializeField] private float Height;

        private Transform cameraTransform;
        private Vector3 velocity;

        private void Start()
        {
            cameraTransform = GetComponent<Transform>();

            if (Target == null)
                Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void LateUpdate()
        {
            moveCamera();
        }
        void moveCamera()
        {
            Vector3 movePosition = new Vector3 (Target.position.x, Target.position.y, Distance);
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, 
                                                          movePosition, 
                                                          ref velocity, 
                                                          damping);
        }
    }

}
