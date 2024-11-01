using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		public Transform player;
		public List<Transform> targetWalls;
		private Vector3 moveDirection;

		public int timeToWait;
		public Animator anim;
        
       

        IAstarAI ai;

        void Start()
        {
			// Find objects with tagg "Wall" and add objects transform to list
			targetWalls = GameObject.FindGameObjectsWithTag("Wall").Select(go => go.transform).ToList();
			EnemyDestination();
            NoWallFound();
			StartCoroutine(venaaSekka());
        }

		

		void ProcessMovement()
		{
            moveDirection = (target.position - transform.position).normalized;
        }

        void Animate()
        {
            anim.SetFloat("Horizontal", moveDirection.x);
            anim.SetFloat("Vertical", moveDirection.y);
        }

        void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		// functio to take random transform from list and set it as target
		void EnemyDestination()
		{
            int index = Random.Range(0, targetWalls.Count);
            target = targetWalls[index];
        }

        void NoWallFound()
		{
			if (targetWalls.Count <= 0)
			{
				target = player;
			}
		}

		IEnumerator venaaSekka()
		{
			yield return new WaitForSeconds(timeToWait);
		}

        private void OnTriggerStay2D(Collider2D collision)
        {
			if (collision.CompareTag("DestroyedWall"))
			{
				target = player;
				AstarPath.active.Scan();
				StartCoroutine(venaaSekka());
				
			}
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update () 
		{
			if (target != null && ai != null) ai.destination = target.position;

			ProcessMovement();
			Animate();
        }
	}
}
