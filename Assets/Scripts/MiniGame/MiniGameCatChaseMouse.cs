using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameCatChaseMouse : SingleTon<MiniGameCatChaseMouse>
    {
        public bool gameStart;
        public string horizontal = "Horizontal";
        public string vertical = "Vertical";
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

        //float autoRotateDirection = -1f;
        float angle = 0f;

        void Update()
        {
            if (!gameStart) return;
            

            /* Keyboard controls the direction
            var dv = Input.GetAxisRaw(vertical);
            angle += dv * Time.deltaTime * rotateSpeed;
            angle = Mathf.Clamp(angle, angleRange.x, angleRange.y);

            var e = cursorArrow.localEulerAngles;
            e.z = angle;
            cursorArrow.localEulerAngles = e;
            */

            //Mouse controls the direction
            var mPosRaw = Input.mousePosition;
            var mPos = Camera.main.ScreenPointToRay(mPosRaw).origin;
            mPos.z = cursorArrow.position.z;
            cursorArrow.up = mPos - cursorArrow.position;

            if ((Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)) && cat.isStopped)
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

        void CreatePatch()
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

            var mouse = FindObjectsOfType<MiniMouse>();
            var patches = FindObjectsOfType<MouseHolePatch>();
            if (mouse.Length >= 3)
            {
                patches[Random.Range(0, patches.Length)].CreateMouse();
            } else
            {
                foreach(MouseHolePatch p in patches)
                    p.CreateMouse();
            }

/*
            foreach(MiniMouse m in mouse)
           {
                if (m.transform.parent == mouseRoot) m.gameObject.SetActive(false);
                else Destroy(m.gameObject);
            }
*/
            CreateMouse();
            CreatePatch();
        }
    }
}