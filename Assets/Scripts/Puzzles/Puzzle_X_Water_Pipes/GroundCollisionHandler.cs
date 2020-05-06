using UnityEngine;

    public class GroundCollisionHandler : MonoBehaviour
    {
        public PipeManager pipeManager;

        private void OnCollisionEnter(Collision collision)
        {
            pipeManager.ResetPipePosition(collision.gameObject);
        }
    }


