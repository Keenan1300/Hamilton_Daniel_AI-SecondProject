using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	
	public class SeekSteerAT : ActionTask {

		public BBParameter<Vector3> targetposition;
		//public Transform TargetTransform;
		private Blackboard PosBoard;
		public BBParameter<Vector3> movedirection;
        public float strength;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            PosBoard = agent.GetComponent<Blackboard>();

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			
            movedirection.value = (targetposition.value - agent.transform.position).normalized;
            PosBoard.SetVariableValue("TargetPosition", movedirection.value);

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			//movedirection.value = (TargetTransform.position - agent.transform.position).normalized;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}