using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Teleporter : MonoBehaviour
    {
        public Teleporter pair;
        
        bool isEnter;

        void OnTriggerEnter(Collider other)
        {
            var miniCat = other.GetComponent<MiniCat>();
            if (miniCat)
            {
                if (!isEnter)
                {
                    isEnter = true;
                    pair.isEnter = true;
                    Teleport(miniCat);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            var miniCat = other.GetComponent<MiniCat>();
            if (miniCat)
            {
                if (isEnter)
                {
                    isEnter = false;
                }
            }
        }

        void Teleport(MiniCat cat)
        {
            cat.transform.position = pair.transform.position;
        }
    }
}