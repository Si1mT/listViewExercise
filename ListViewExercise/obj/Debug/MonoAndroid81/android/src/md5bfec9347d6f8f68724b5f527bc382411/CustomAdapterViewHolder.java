package md5bfec9347d6f8f68724b5f527bc382411;


public class CustomAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ListViewExercise.CustomAdapterViewHolder, ListViewExercise", CustomAdapterViewHolder.class, __md_methods);
	}


	public CustomAdapterViewHolder ()
	{
		super ();
		if (getClass () == CustomAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("ListViewExercise.CustomAdapterViewHolder, ListViewExercise", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
