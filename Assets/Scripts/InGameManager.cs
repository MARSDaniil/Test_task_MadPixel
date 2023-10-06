using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class InGameManager :MonoBehaviour {
        [SerializeField] GameObject cube;
        Rigidbody rigidbody;
        private void Awake() {
            Init();
        }
        private void Init() {
            /*
            rigidbody = cube.GetComponent<Rigidbody>();
            Vector3 vector  = new Vector3(0, 0, 1);
            float speed = 1200f;
            rigidbody.AddForce(vector * speed);
            */
        }
        
    }
}