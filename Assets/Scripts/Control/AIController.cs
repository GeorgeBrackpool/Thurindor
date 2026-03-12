using UnityEngine;
using Thurindor.Combat;
using Thurindor.Core;

namespace Thurindor.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;
        Health health;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (health.IsDead()) return;
    
            GameObject player = GameObject.FindWithTag("Player");
            if (InAttackRange() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
        }

        bool InAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);           
            return distanceToPlayer < chaseDistance;
        }
    }
}
