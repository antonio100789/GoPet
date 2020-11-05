package md5d53585eec11b6d4c38449250db2913d9;


public class ViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App.PET.Resources.ViewHolder, App.PET", ViewHolder.class, __md_methods);
	}


	public ViewHolder ()
	{
		super ();
		if (getClass () == ViewHolder.class)
			mono.android.TypeManager.Activate ("App.PET.Resources.ViewHolder, App.PET", "", this, new java.lang.Object[] {  });
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
