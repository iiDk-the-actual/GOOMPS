using System;
using UnityEngine;

namespace GOOMPS
{
	internal class GOOMPSCollision : MonoBehaviour
	{
		public static void ChangePlayerVisibility(VRRig _rig, bool _visible)
		{
			if (_rig == GorillaTagger.Instance.offlineVRRig)
				return;

			if (Cfg.audio.Value)
			{
				GorillaTagger instance = GorillaTagger.Instance;
				if (instance != null)
				{
					VRRig offlineVRRig = instance.offlineVRRig;
					if (offlineVRRig != null)
						offlineVRRig.tagSound.PlayOneShot(GorillaTagger.Instance.offlineVRRig.clipToPlay[5]);
				}
			}

			_rig.mainSkin.enabled = _visible;
			_rig.muted = Cfg.mute.Value && !_visible;
			_rig.transform.Find("RigAnchor/rig/body/gorillachest").gameObject.SetActive(_visible);
			_rig.transform.Find("RigAnchor/rig/body/head/gorillaface").gameObject.SetActive(_visible);
		}

		private void OnTriggerEnter(Collider coll)
		{
			if (coll.name.Contains("Body"))
				ChangePlayerVisibility(coll.transform.parent.parent.parent.parent.GetComponent<VRRig>(), false);
		}

		private void OnTriggerExit(Collider coll)
		{
			if (coll.name.Contains("Body"))
				ChangePlayerVisibility(coll.transform.parent.parent.parent.parent.GetComponent<VRRig>(), true);
		}
	}
}
