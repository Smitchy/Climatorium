using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iPuzzle : MonoBehaviour
{
    //An example of abstract attributes. This attribute MUST be given implementation.
    public abstract float example { get; }

    //An example of virtual attributes. Optional implementation, if not overriden this will be used.
    public virtual float exampleTwo
    {
        get
        {
            return 0;
        }
        set
        {
            //Assign local attribute
        }

    }


    //abstract methods that the implementing class MUST implement
    public abstract void SetUp();
    public abstract void TearDown();

    public virtual void SetUp(float example)
    {
        //This is an example of default implementation. 
        //The implementing class can choose to OVERRIDE this method to change the functionality
    }
}
