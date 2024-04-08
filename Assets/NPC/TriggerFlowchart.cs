//Copy Right by Vincent Lam 2021
using UnityEngine;
using Fungus;

public class TriggerFlowchart : MonoBehaviour {

	public Flowchart flowchart;
	public string triggerInBlockName;
    public string triggerOutBlockName;
	public string triggerTag="Player";
	public enum triggerInOut {TriggerIn, TriggerOut};

    private void Start()
    {
        if (!flowchart)
            flowchart = GameObject.FindObjectOfType<Flowchart>();
    }
    void OnTriggerEnter (Collider col) {
        if (this.enabled && triggerInBlockName != "") { 
            if (col.CompareTag(triggerTag)) {
                bool hasBlock = flowchart.ExecuteIfHasBlock(triggerInBlockName);
                if (!hasBlock)
                    print("Trigger in Block '" + triggerInBlockName + "' does not exit!");
		    }
        }
    }

	void OnTriggerExit (Collider col) {
        if (this.enabled && triggerOutBlockName!= "")
        {
            if (col.CompareTag(triggerTag))
            {
                bool hasBlock = flowchart.ExecuteIfHasBlock(triggerOutBlockName);
                if (!hasBlock)
                    print("Trigger out Block '" + triggerOutBlockName + "' does not exit!");
            }
        }
	}
}
