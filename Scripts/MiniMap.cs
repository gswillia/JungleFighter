using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniMap : MonoBehaviour
{
		public Slider cam;
		public float zoom;
		public Camera miniM;

		void Start ()
		{

		}

		void Update ()
		{
				zoom = cam.value;
				zoom = zoom * 5f;
				miniM.orthographicSize = zoom;

		}

}
