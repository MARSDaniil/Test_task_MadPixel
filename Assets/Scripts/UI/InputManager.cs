using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CubeNS;
namespace Game.UI {
    public class InputManager :MonoBehaviour {

        [SerializeField] Camera camera;

        InGameUIManager inGameUIManager;
        private bool waiting;

        private bool isPressed = false;


        public void Init(InGameUIManager manager) {
            inGameUIManager = manager;
        }

        private void Update() {
            if (!waiting) {
                if (Input.GetMouseButton(0)) MouseInput();
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
                    ArrowInput(Vector3.left);
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    ArrowInput(Vector3.right);
                if (isPressed && !Input.GetMouseButton(0)
                    && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow)
                    && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow)) {
                    isPressed = false;
                    inGameUIManager.inGameManager.cube.GetComponent<Cube>().MoveForward();
                }
            }
        }
        private float deltaSwipe = 0.005f;
        private void MouseInput() {
            isPressed = true;
            var mousePos2D = Input.mousePosition;
            var screenToCameraDistance = camera.nearClipPlane;

            var mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y, screenToCameraDistance);
            var worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);

            var cubePosition = inGameUIManager.inGameManager.cube.GetComponent<Cube>().Position * 0.15f / 3.85f;

            if (cubePosition.x - worldPointPos.x > deltaSwipe)
                inGameUIManager.inGameManager.cube.GetComponent<Cube>().MoveToSide(Vector3.left*2);
            else if(cubePosition.x - worldPointPos.x < -deltaSwipe)
                inGameUIManager.inGameManager.cube.GetComponent<Cube>().MoveToSide(Vector3.right*2);
            else inGameUIManager.inGameManager.cube.GetComponent<Cube>().MoveToSide(Vector3.zero);
        }
        private void ArrowInput(Vector3 vector) {
            isPressed = true;
            inGameUIManager.inGameManager.cube.GetComponent<Cube>().MoveToSide(vector);
        }
    }
}