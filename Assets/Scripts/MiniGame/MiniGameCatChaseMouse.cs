using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameCatChaseMouse : SingleTon<MiniGameCatChaseMouse>
    {
        public bool gameStart;
        public string horizontal = "Horizontal";
        public float rotateSpeed = 60f;
        public Vector2 angleRange = new Vector2(-60, 60);
        public Transform cursorArrow;
        public float moveBoardSpeed = 3f;
        public Vector2 boardRange = new Vector2(-7, 7);
        public Transform board;
        public Transform catStartPos;
        public MiniCat cat;
        public float catSpeed = 7f;
        public Rect mouseArea;
        public Transform mouseRoot;
        public Transform patchRoot;
        public GameObject exitButton;

        float autoRotateDirection = -1f;
        float angle = 0f;

        void Update()
        {
            if (!gameStart) return;
            
            angle += autoRotateDirection * Time.deltaTime * rotateSpeed;
            if (angle > angleRange.y) autoRotateDirection = -1f;
            if (angle < angleRange.x) autoRotateDirection = 1f;

            var e = cursorArrow.localEulerAngles;
            e.z = angle;
            cursorArrow.localEulerAngles = e;

            if (Input.GetMouseButtonDown(0) && cat.isStopped)
                ShootCat();
            
            var dh = Input.GetAxisRaw(horizontal) * Time.deltaTime * moveBoardSpeed;
            board.localPosition += dh * Vector3.right;
            board.localPosition = new Vector3(
                Mathf.Clamp(board.localPosition.x, boardRange.x, boardRange.y),
                board.localPosition.y,
                board.localPosition.z
            );

            if (IsMouseAllKilled())
                exitButton.SetActive(true);
        }

        void OnDisable()
        {
            if (cat)
                cat.gameObject.SetActive(false);
        }

        void ShootCat()
        {
            Vector3 vDirection = cursorArrow.up;
            cat.Run(vDirection * catSpeed);
        }

        void CreateMouse()
        {
            foreach(Transform t in mouseRoot) t.gameObject.SetActive(true);
        }

        public void CreatePatch()
        {
            foreach(Transform t in patchRoot) t.gameObject.SetActive(true);
        }

        bool IsMouseAllKilled()
        {
            return MiniMouse.all.Count == 0;
        }

        public void Restart()
        {
            cat.transform.SetParent(FindObjectOfType<CatBoard>().transform, true);
            cat.transform.position = catStartPos.position;
            cat.Stop();
            foreach(MiniMouse m in FindObjectsOfType<MiniMouse>())
                m.gameObject.SetActive(false);
            CreateMouse();
            CreatePatch();
        }
    }
}