using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Teleporter : MonoBehaviour
    {
        public Teleporter pair;

        void OnTriggerEnter(Collider other)
        {
            var miniCat = other.GetComponent<MiniCat>();
            if (miniCat)
            {
                Teleport(miniCat);
            }
        }

        void Teleport(MiniCat cat)
        {
            cat.transform.position = pair.transform.position;
        }
    }
}