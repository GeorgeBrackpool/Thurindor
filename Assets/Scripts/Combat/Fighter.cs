using UnityEngine;
using Thurindor.Movement;
using Thurindor.Core;

namespace Thurindor.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        Transform target;
        Mover mover;
        [SerializeField] float weaponRange = 2f;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {

            if (target == null) return;
            
            if (!GetIsInRange())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Cancel();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
                target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
