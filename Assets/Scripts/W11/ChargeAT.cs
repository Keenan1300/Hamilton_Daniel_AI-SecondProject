using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChargeAT : ActionTask {
		public float chargeDuration;
		private float timeCharging;

		public Color startcolor, chargedcolor;

		private MeshRenderer objectRenderer;



		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			objectRenderer = agent.GetComponent<MeshRenderer>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timeCharging = 0f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			timeCharging += Time.deltaTime;
			objectRenderer.material.color = Color.Lerp(startcolor, chargedcolor, timeCharging / chargeDuration);

			
			//if unit has been charging long enough
			if (timeCharging > chargeDuration)
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}