using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class InRangeOfNestCT : ConditionTask
    {
        private Transform Nest;
        public BBParameter<Transform> targetTransform;
        public BBParameter<float> rangeDistance;
       


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            Transform nest = agent.transform;
            return null;
        }

        //Called whenever the condition gets enabled.
        protected override void OnEnable()
        {
            Debug.Log("Playerinrange!!");
        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {
            Debug.Log("Player out of range!!");
        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            float distanceToTarget = Vector3.Distance(agent.transform.position, targetTransform.value.position);

            return distanceToTarget < rangeDistance.value;
        }
    }
}