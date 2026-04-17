using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


namespace NodeCanvas.Tasks.Conditions {

	public class IntrudercheckCT : ConditionTask {


		public BBParameter<float> DetectionDist;
        public BBParameter<Transform> NestSpot;
		public BBParameter<LayerMask> Enemy;
        public bool fromnest;
        public BBParameter<LayerMask> Player;
        private Blackboard PosBoard;
        public BBParameter<Transform> guardpoint;
        public Vector3 Sightedposition;
        private float distanceToTarget;
        private bool Behemoth;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            float distanceToTarget = Vector3.Distance(guardpoint.value.transform.position, Sightedposition);
            PosBoard = agent.GetComponent<Blackboard>();
  

            Collider[] PlayerColliders = Physics.OverlapSphere(guardpoint.value.transform.position, DetectionDist.value, Player.value);
            Collider[] EnemyColliders = Physics.OverlapSphere(guardpoint.value.transform.position, DetectionDist.value, Enemy.value);



            //implementing priority based detection here
            //The Hive will prioritize fending off Behemoths over the player. seeing them as a larger threat
            foreach (Collider EnemyCollider in EnemyColliders)
            {
				
                Vector3 Sightedposition = EnemyCollider.transform.position;
                Vector3 Directiontoposition = EnemyCollider.transform.position - agent.transform.position;
                PosBoard.SetVariableValue("BehemothPosition", Sightedposition);
                PosBoard.SetVariableValue("BehemothNear", true);
                Behemoth = true;
                Debug.Log("enemy seen!");
                distanceToTarget = Vector3.Distance(guardpoint.value.transform.position, Sightedposition);


                //make it so bees can retarget to player when needed
                if( EnemyCollider == null)
                        {
                    Behemoth=false;
                    PosBoard.SetVariableValue("BehemothNear", false);
                }
            }

            if (!Behemoth)
            {
                foreach (Collider PlayerCollider in PlayerColliders)
                {

                    Vector3 Sightedposition = PlayerCollider.transform.position;
                    Vector3 Directiontoposition = PlayerCollider.transform.position - agent.transform.position;
                    PosBoard.SetVariableValue("TargetPosition", Sightedposition);
                    Debug.Log("player seen!");
                    distanceToTarget = Vector3.Distance(guardpoint.value.transform.position, Sightedposition);

                }
            }




                return distanceToTarget <= DetectionDist.value;
		}
	}
}