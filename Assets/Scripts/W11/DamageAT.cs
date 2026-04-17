using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Events;


namespace NodeCanvas.Tasks.Actions {


	public class DamageAT : ActionTask {

		public float Damage;
		
        public UnityEvent AttackPlayer;
		public Blackboard Behemothscript;
        public BBParameter<GameObject> healthB;
        public BBParameter<bool> Behemothinrange;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            
			
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {


			//if bees arent attacking behemoth
			if (!Behemothinrange.value)
			{
				HealthBar script = healthB.value.GetComponent<HealthBar>();
				script.TakeDamage(Damage);
				Debug.Log("Attacking");
				EndAction(true);
			}
			else
			{
				//nothing
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}