using System.Collections.Generic;
using UnityEngine;

namespace GardenScripts
{
    public class ChangeLevel : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToChange = new();
        [SerializeField] private List<Transform> newPositions = new();
        
    }
}
