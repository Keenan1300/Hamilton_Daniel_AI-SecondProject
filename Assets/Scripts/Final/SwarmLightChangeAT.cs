using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwarmLightChangeAT : ActionTask {

		public Color aggro;
		public Color passive;
		public BBParameter<Light> BL;
		float T;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            BL = agent.GetComponent<Light>();
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

			T += Time.deltaTime * 0.7f;
			BL.value.color = Color.Lerp(passive, aggro, 0 + T);

			if (BL.value.color == aggro)
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