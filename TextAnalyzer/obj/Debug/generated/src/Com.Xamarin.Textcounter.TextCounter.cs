using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Xamarin.Textcounter {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.xamarin.textcounter']/class[@name='TextCounter']"
	[global::Android.Runtime.Register ("com/xamarin/textcounter/TextCounter", DoNotGenerateAcw=true)]
	public partial class TextCounter : global::Java.Lang.Object {

		static readonly JniPeerMembers _members = new XAPeerMembers ("com/xamarin/textcounter/TextCounter", typeof (TextCounter));
		internal static IntPtr class_ref {
			get {
				return _members.JniPeerType.PeerReference.Handle;
			}
		}

		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		protected override IntPtr ThresholdClass {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		protected TextCounter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.xamarin.textcounter']/class[@name='TextCounter']/constructor[@name='TextCounter' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe TextCounter ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			const string __id = "()V";

			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				var __r = _members.InstanceMethods.StartCreateInstance (__id, ((object) this).GetType (), null);
				SetHandle (__r.Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance (__id, this, null);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='com.xamarin.textcounter']/class[@name='TextCounter']/method[@name='numConsonants' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("numConsonants", "(Ljava/lang/String;)I", "")]
		public static unsafe int NumConsonants (string text)
		{
			const string __id = "numConsonants.(Ljava/lang/String;)I";
			IntPtr native_text = JNIEnv.NewString (text);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (native_text);
				var __rm = _members.StaticMethods.InvokeInt32Method (__id, __args);
				return __rm;
			} finally {
				JNIEnv.DeleteLocalRef (native_text);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='com.xamarin.textcounter']/class[@name='TextCounter']/method[@name='numVowels' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("numVowels", "(Ljava/lang/String;)I", "")]
		public static unsafe int NumVowels (string text)
		{
			const string __id = "numVowels.(Ljava/lang/String;)I";
			IntPtr native_text = JNIEnv.NewString (text);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (native_text);
				var __rm = _members.StaticMethods.InvokeInt32Method (__id, __args);
				return __rm;
			} finally {
				JNIEnv.DeleteLocalRef (native_text);
			}
		}

	}
}
