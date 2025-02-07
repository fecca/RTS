using UnityEngine;
using UnityEngine.AI;

namespace World.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        public void MoveTo(Vector3 position)
        {
            if (!NavMesh.SamplePosition(position, out var hit, 1.0f, NavMesh.AllAreas)) return;
            
            navMeshAgent.SetDestination(hit.position);
        }
    }
}