package md5fa3be16b83ce3acd3be83265686c14de;


public class Tag
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CarouselView.FormsPlugin.Android.Tag, CarouselView.FormsPlugin.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Tag.class, __md_methods);
	}


	public Tag () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Tag.class)
			mono.android.TypeManager.Activate ("CarouselView.FormsPlugin.Android.Tag, CarouselView.FormsPlugin.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
