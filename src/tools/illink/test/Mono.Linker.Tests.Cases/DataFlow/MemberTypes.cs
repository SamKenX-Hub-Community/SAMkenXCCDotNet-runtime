// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using Mono.Linker.Tests.Cases.Expectations.Assertions;
using Mono.Linker.Tests.Cases.Expectations.Metadata;

namespace Mono.Linker.Tests.Cases.DataFlow
{
	[IgnoreTestCase ("Ignore in NativeAOT, see https://github.com/dotnet/runtime/issues/82447", IgnoredBy = Tool.NativeAot)]
	[KeptAttributeAttribute (typeof (IgnoreTestCaseAttribute), By = Tool.Trimmer)]
	[SetupCompileArgument ("/optimize+")]
	[ExpectedNoWarnings]
	public class MemberTypes
	{
		// Some of the types below declare delegates and will mark all members on them, this includes the Delegate .ctor(object, string) which has RUC and other members
		[ExpectedWarning ("IL2026", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2026", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2026", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2026", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2026", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2026", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2026", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2026", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2026", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2026", nameof (MulticastDelegate) + ".MulticastDelegate")]
		// Some of the types below declare delegates and will mark all members on them, this includes the Delegate .ctor(Type, string) which has DAM annotations and other members
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".Delegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (Delegate.CreateDelegate))]
		[ExpectedWarning ("IL2111", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2111", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2111", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2111", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2111", nameof (MulticastDelegate) + ".MulticastDelegate")]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".BindToMethodName", ProducedBy = Tool.Trimmer)]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".BindToMethodName", ProducedBy = Tool.Trimmer)]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".BindToMethodName", ProducedBy = Tool.Trimmer)]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".BindToMethodName", ProducedBy = Tool.Trimmer)]
		[ExpectedWarning ("IL2111", nameof (Delegate) + ".BindToMethodName", ProducedBy = Tool.Trimmer)]
		public static void Main ()
		{
			RequirePublicParameterlessConstructor (typeof (PublicParameterlessConstructorType));
			RequirePublicParameterlessConstructor (typeof (PrivateParameterlessConstructorType));
			RequirePublicParameterlessConstructor (typeof (PublicParameterlessConstructorBeforeFieldInitType));
			RequirePublicConstructors (typeof (PublicConstructorsType));
			RequirePublicConstructors (typeof (PublicConstructorsBeforeFieldInitType));
			RequirePublicConstructors (typeof (PublicConstructorsPrivateParameterlessConstructorType));
			RequireNonPublicConstructors (typeof (NonPublicConstructorsType));
			RequireNonPublicConstructors (typeof (NonPublicConstructorsBeforeFieldInitType));
			RequireAllConstructors (typeof (AllConstructorsType));
			RequireAllConstructors (typeof (AllConstructorsBeforeFieldInitType));
			RequirePublicMethods (typeof (PublicMethodsType));
			RequireNonPublicMethods (typeof (NonPublicMethodsType));
			RequireAllMethods (typeof (AllMethodsType));
			RequirePublicFields (typeof (PublicFieldsType));
			RequireNonPublicFields (typeof (NonPublicFieldsType));
			RequireAllFields (typeof (AllFieldsType));
			RequirePublicNestedTypes (typeof (PublicNestedTypesType));
			RequireNonPublicNestedTypes (typeof (NonPublicNestedTypesType));
			RequireAllNestedTypes (typeof (AllNestedTypesType));
			RequirePublicProperties (typeof (PublicPropertiesType));
			RequireNonPublicProperties (typeof (NonPublicPropertiesType));
			RequireAllProperties (typeof (AllPropertiesType));
			RequirePublicEvents (typeof (PublicEventsType));
			RequireNonPublicEvents (typeof (NonPublicEventsType));
			RequireAllEvents (typeof (AllEventsType));
			RequireInterfaces (typeof (InterfacesType));
			RequireAll (typeof (AllType));
			RequireAll (typeof (RequireAllWithRecursiveTypeReferences));
		}


		[Kept]
		private static void RequirePublicParameterlessConstructor (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicParameterlessConstructorBaseType
		{
			[Kept]
			public PublicParameterlessConstructorBaseType () { }

			public PublicParameterlessConstructorBaseType (int i) { }
		}

		[Kept]
		[KeptBaseType (typeof (PublicParameterlessConstructorBaseType))]
		class PublicParameterlessConstructorType : PublicParameterlessConstructorBaseType
		{
			[Kept]
			public PublicParameterlessConstructorType () { }

			public PublicParameterlessConstructorType (int i) { }

			private PublicParameterlessConstructorType (int i, int j) { }

			// Not implied by the DynamicallyAccessedMemberTypes logic, but
			// explicit cctors would be kept by ILLink.
			// [Kept]
			// static PublicParameterlessConstructorType () { }

			public void Method1 () { }
			public bool Property1 { get; set; }
			public bool Field1;
		}

		[Kept]
		class PublicParameterlessConstructorBeforeFieldInitType
		{
			static int i = 10;

			[Kept]
			public PublicParameterlessConstructorBeforeFieldInitType () { }
		}

		[Kept]
		class PrivateParameterlessConstructorBaseType
		{
			protected PrivateParameterlessConstructorBaseType () { }

			PrivateParameterlessConstructorBaseType (int i) { }
		}

		[Kept]
		[KeptBaseType (typeof (PrivateParameterlessConstructorBaseType))]
		class PrivateParameterlessConstructorType : PrivateParameterlessConstructorBaseType
		{
			// Private parameterless .ctor is not considered "default .ctor"
			// "default .ctor" is typically the one auto-generated by the compiler
			// which is always public.
			PrivateParameterlessConstructorType () { }

			public PrivateParameterlessConstructorType (int i) { }

			public void Method1 () { }

			public bool Property1 { get; set; }

			public bool Field1;
		}

		[Kept]
		private static void RequirePublicConstructors (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicConstructorsBaseType
		{
			[Kept]
			public PublicConstructorsBaseType () { }

			public PublicConstructorsBaseType (int i) { }
		}

		[Kept]
		[KeptBaseType (typeof (PublicConstructorsBaseType))]
		class PublicConstructorsType : PublicConstructorsBaseType
		{
			private PublicConstructorsType () { }

			[Kept]
			public PublicConstructorsType (int i) { }

			private PublicConstructorsType (int i, int j) { }

			// Not implied by the DynamicallyAccessedMemberTypes logic, but
			// explicit cctors would be kept by ILLink.
			// [Kept]
			// static PublicConstructorsType () { }

			public void Method1 () { }
			public bool Property1 { get; set; }
			public bool Field1;
		}

		[Kept]
		class PublicConstructorsBeforeFieldInitType
		{
			static int i = 10;

			[Kept]
			public PublicConstructorsBeforeFieldInitType () { }
		}

		[Kept]
		class PublicConstructorsPrivateParameterlessConstructorType
		{
			private PublicConstructorsPrivateParameterlessConstructorType () { }
		}


		[Kept]
		private static void RequireNonPublicConstructors (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicConstructorsBaseType
		{
			[Kept]
			protected NonPublicConstructorsBaseType () { }

			protected NonPublicConstructorsBaseType (int i) { }
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicConstructorsBaseType))]
		class NonPublicConstructorsType : NonPublicConstructorsBaseType
		{
			[Kept]
			private NonPublicConstructorsType () { }

			public NonPublicConstructorsType (int i) { }

			[Kept]
			private NonPublicConstructorsType (int i, int j) { }

			// Kept by the DynamicallyAccessedMembers logic
			[Kept]
			static NonPublicConstructorsType () { }

			public void Method1 () { }
			public bool Property1 { get; set; }
			public bool Field1;
		}

		[Kept]
		class NonPublicConstructorsBeforeFieldInitType
		{
			public int i = 10;

			public NonPublicConstructorsBeforeFieldInitType () { }
		}


		[Kept]
		private static void RequireAllConstructors (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllConstructorsBaseType
		{
			[Kept]
			protected AllConstructorsBaseType () { }

			protected AllConstructorsBaseType (int i) { }
		}

		[Kept]
		[KeptBaseType (typeof (AllConstructorsBaseType))]
		class AllConstructorsType : AllConstructorsBaseType
		{
			[Kept]
			private AllConstructorsType () { }

			[Kept]
			public AllConstructorsType (int i) { }

			[Kept]
			private AllConstructorsType (int i, int j) { }

			// Kept by the DynamicallyAccessedMembers logic
			[Kept]
			static AllConstructorsType () { }

			public void Method1 () { }
			public bool Property1 { get; set; }
			public bool Field1;
		}

		[Kept]
		class AllConstructorsBeforeFieldInitType
		{
			[Kept]
			public int i = 10;

			[Kept]
			public AllConstructorsBeforeFieldInitType () { }
		}


		[Kept]
		private static void RequirePublicMethods (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicMethodsBaseType
		{
			[Kept]
			public void PublicBaseMethod () { }
			private void PrivateBaseMethod () { }
			protected void ProtectedBaseMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			public bool PublicPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			protected bool ProtectedPropertyOnBase { get; set; }
			private bool PrivatePropertyOnBase { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEventOnBase;
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticBaseMethod () { }
			private static void PrivateStaticBaseMethod () { }
			protected static void ProtectedStaticBaseMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static protected bool ProtectedStaticPropertyOnBase { get; set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (PublicMethodsBaseType))]
		class PublicMethodsType : PublicMethodsBaseType
		{
			public PublicMethodsType () { }

			[Kept]
			public void PublicMethod1 () { }
			[Kept]
			public bool PublicMethod2 (int i) { return false; }

			internal void InternalMethod () { }
			protected void ProtectedMethod () { }
			private void PrivateMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			public bool PublicProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			protected bool ProtectedProperty { get; set; }
			private bool PrivateProperty { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEvent;
			protected event EventHandler<EventArgs> ProtectedEvent;
			private event EventHandler<EventArgs> PrivateEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticMethod () { }
			private static void PrivateStaticMethod () { }
			protected static void ProtectedStaticMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticProperty { [Kept] get; [Kept] set; }
			static protected bool ProtectedStaticProperty { get; set; }
			static private bool PrivateStaticProperty { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEvent;
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;
		}


		[Kept]
		private static void RequireNonPublicMethods (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicMethods)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicMethodsBaseType
		{
			public void PublicBaseMethod () { }
			private void PrivateBaseMethod () { }
			[Kept]
			protected void ProtectedBaseMethod () { }
			public void HideMethod () { }

			public bool PublicPropertyOnBase { get; set; }
			[Kept]
			protected bool ProtectedPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			private bool PrivatePropertyOnBase { get; set; }
			public bool HideProperty { get; set; }

			public event EventHandler<EventArgs> PublicEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			public event EventHandler<EventArgs> HideEvent;

			public static void PublicStaticBaseMethod () { }
			private static void PrivateStaticBaseMethod () { }
			[Kept]
			protected static void ProtectedStaticBaseMethod () { }
			public static void HideStaticMethod () { }

			static public bool PublicStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicMethodsBaseType))]
		class NonPublicMethodsType : NonPublicMethodsBaseType
		{
			private NonPublicMethodsType () { }

			public void PublicMethod1 () { }
			public bool PublicMethod2 (int i) { return false; }

			[Kept]
			internal void InternalMethod () { }
			[Kept]
			protected void ProtectedMethod () { }
			[Kept]
			private void PrivateMethod () { }
			public void HideMethod () { }

			public bool PublicProperty { get; set; }
			[Kept]
			protected bool ProtectedProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			private bool PrivateProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			public bool HideProperty { get; set; }

			public event EventHandler<EventArgs> PublicEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			private event EventHandler<EventArgs> PrivateEvent;
			public event EventHandler<EventArgs> HideEvent;

			public static void PublicStaticMethod () { }
			[Kept]
			private static void PrivateStaticMethod () { }
			[Kept]
			protected static void ProtectedStaticMethod () { }
			public static void HideStaticMethod () { }

			static public bool PublicStaticProperty { get; set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticProperty { [Kept] get; [Kept] set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			public static event EventHandler<EventArgs> HideStaticEvent;

			public bool Field1;
		}


		[Kept]
		private static void RequireAllMethods (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllMethodsBaseType
		{
			[Kept]
			public void PublicBaseMethod () { }
			private void PrivateBaseMethod () { }
			[Kept]
			protected void ProtectedBaseMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			public bool PublicPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			protected bool ProtectedPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			private bool PrivatePropertyOnBase { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticBaseMethod () { }
			private static void PrivateStaticBaseMethod () { }
			[Kept]
			protected static void ProtectedStaticBaseMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (AllMethodsBaseType))]
		class AllMethodsType : AllMethodsBaseType
		{
			public AllMethodsType () { }

			[Kept]
			public void PublicMethod1 () { }
			[Kept]
			public bool PublicMethod2 (int i) { return false; }

			[Kept]
			internal void InternalMethod () { }
			[Kept]
			protected void ProtectedMethod () { }
			[Kept]
			private void PrivateMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			public bool PublicProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			protected bool ProtectedProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			private bool PrivateProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			private event EventHandler<EventArgs> PrivateEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticMethod () { }
			[Kept]
			private static void PrivateStaticMethod () { }
			[Kept]
			protected static void ProtectedStaticMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;

			public bool Field1;
		}


		[Kept]
		private static void RequirePublicFields (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicFieldsBaseType
		{
			[Kept]
			public bool PublicBaseField;
			protected bool ProtectedBaseField;
			private bool PrivateBaseField;
			[Kept]
			public bool HideField;

			// Backing fields are private, so they are not accessible from a derived type
			public bool PublicPropertyOnBase { get; set; }
			protected bool ProtectedPropertyOnBase { get; set; }
			private bool PrivatePropertyOnBase { get; set; }

			public event EventHandler<EventArgs> PublicEventOnBase;
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;

			[Kept]
			static public bool StaticPublicBaseField;
			static protected bool StaticProtectedBaseField;
			static private bool StaticPrivateBaseField;
			[Kept]
			static public bool HideStaticField;

			static public bool PublicStaticPropertyOnBase { get; set; }
			static protected bool ProtectedStaticPropertyOnBase { get; set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (PublicFieldsBaseType))]
		class PublicFieldsType : PublicFieldsBaseType
		{
			[Kept]
			public bool PublicField;
			[Kept]
			public string PublicStringField;
			internal bool InternalField;
			protected bool ProtectedField;
			private bool PrivateField;
			[Kept]
			public bool HideField;

			// Backing fields are all private
			public bool PublicProperty { get; set; }
			protected bool ProtectedProperty { get; set; }
			private bool PrivateProperty { get; set; }
			public bool HideProperty { get; set; }

			public event EventHandler<EventArgs> PublicEvent;
			protected event EventHandler<EventArgs> ProtectedEvent;
			private event EventHandler<EventArgs> PrivateEvent;
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			static public bool StaticPublicField;
			[Kept]
			static public string StaticPublicStringField;
			static protected bool StaticProtectedField;
			static private bool StaticPrivateField;
			[Kept]
			static public bool HideStaticField;

			static public bool PublicStaticProperty { get; set; }
			static protected bool ProtectedStaticProperty { get; set; }
			static private bool PrivateStaticProperty { get; set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEvent;
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		private static void RequireNonPublicFields (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicFields)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicFieldsBaseType
		{
			public bool PublicBaseField;
			[Kept]
			protected bool ProtectedBaseField;
			private bool PrivateBaseField;
			public bool HideField;

			// Backing fields are private, so they are not accessible from a derived type
			public bool PublicPropertyOnBase { get; set; }
			protected bool ProtectedPropertyOnBase { get; set; }
			private bool PrivatePropertyOnBase { get; set; }

			public event EventHandler<EventArgs> PublicEventOnBase;
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;

			static public bool StaticPublicBaseField;
			[Kept]
			static protected bool StaticProtectedBaseField;
			static private bool StaticPrivateBaseField;
			static public bool HideStaticField;

			static public bool PublicStaticPropertyOnBase { get; set; }
			static protected bool ProtectedStaticPropertyOnBase { get; set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicFieldsBaseType))]
		class NonPublicFieldsType : NonPublicFieldsBaseType
		{
			public bool PublicField;
			public string PublicStringField;
			[Kept]
			internal bool InternalField;
			[Kept]
			protected bool ProtectedField;
			[Kept]
			private bool PrivateField;
			public bool HideField;

			// Backing fields are always private, so they will be kept even if the property itself is public
			[KeptBackingField]
			public bool PublicProperty { get; set; }
			[KeptBackingField]
			protected bool ProtectedProperty { get; set; }
			[KeptBackingField]
			private bool PrivateProperty { get; set; }
			[KeptBackingField]
			public bool HideProperty { get; set; }

			[KeptBackingField]
			public event EventHandler<EventArgs> PublicEvent;
			[KeptBackingField]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[KeptBackingField]
			private event EventHandler<EventArgs> PrivateEvent;
			[KeptBackingField]
			public event EventHandler<EventArgs> HideEvent;

			static public bool StaticPublicField;
			static public string StaticPublicStringField;
			[Kept]
			static protected bool StaticProtectedField;
			[Kept]
			static private bool StaticPrivateField;
			static public bool HideStaticField;

			[KeptBackingField]
			static public bool PublicStaticProperty { get; set; }
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { get; set; }
			[KeptBackingField]
			static private bool PrivateStaticProperty { get; set; }
			[KeptBackingField]
			static public bool HideStaticProperty { get; set; }

			[KeptBackingField]
			public static event EventHandler<EventArgs> PublicStaticEvent;
			[KeptBackingField]
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			[KeptBackingField]
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			[KeptBackingField]
			public static event EventHandler<EventArgs> HideStaticEvent;
		}


		[Kept]
		private static void RequireAllFields (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllFieldsBaseType
		{
			[Kept]
			public bool PublicBaseField;
			[Kept]
			protected bool ProtectedBaseField;
			private bool PrivateBaseField;
			[Kept]
			public bool HideField;

			// Backing fields are private, so they are not accessible from a derived type
			public bool PublicPropertyOnBase { get; set; }
			protected bool ProtectedPropertyOnBase { get; set; }
			private bool PrivatePropertyOnBase { get; set; }

			public event EventHandler<EventArgs> PublicEventOnBase;
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;

			[Kept]
			static public bool StaticPublicBaseField;
			[Kept]
			static protected bool StaticProtectedBaseField;
			static private bool StaticPrivateBaseField;
			[Kept]
			static public bool HideStaticField;

			static public bool PublicStaticPropertyOnBase { get; set; }
			static protected bool ProtectedStaticPropertyOnBase { get; set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			static public bool HideStaticProperty { get; set; }

			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			public static event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (AllFieldsBaseType))]
		class AllFieldsType : AllFieldsBaseType
		{
			[Kept]
			public bool PublicField;
			[Kept]
			public string PublicStringField;
			[Kept]
			internal bool InternalField;
			[Kept]
			protected bool ProtectedField;
			[Kept]
			private bool PrivateField;
			[Kept]
			public bool HideField;

			[KeptBackingField]
			public bool PublicProperty { get; set; }
			[KeptBackingField]
			protected bool ProtectedProperty { get; set; }
			[KeptBackingField]
			private bool PrivateProperty { get; set; }
			[KeptBackingField]
			public bool HideProperty { get; set; }

			[KeptBackingField]
			public event EventHandler<EventArgs> PublicEvent;
			[KeptBackingField]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[KeptBackingField]
			private event EventHandler<EventArgs> PrivateEvent;
			[KeptBackingField]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			static public bool StaticPublicField;
			[Kept]
			static public string StaticPublicStringField;
			[Kept]
			static protected bool StaticProtectedField;
			[Kept]
			static private bool StaticPrivateField;
			[Kept]
			static public bool HideStaticField;

			[KeptBackingField]
			static public bool PublicStaticProperty { get; set; }
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { get; set; }
			[KeptBackingField]
			static private bool PrivateStaticProperty { get; set; }
			[KeptBackingField]
			static public bool HideStaticProperty { get; set; }

			[KeptBackingField]
			public static event EventHandler<EventArgs> PublicStaticEvent;
			[KeptBackingField]
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			[KeptBackingField]
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			[KeptBackingField]
			public static event EventHandler<EventArgs> HideStaticEvent;
		}


		[Kept]
		private static void RequirePublicNestedTypes (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicNestedTypesBaseType
		{
			// Nested types are not propagated from base class at all
			public class PublicBaseNestedType { }
			protected class ProtectedBaseNestedType { }
			private class PrivateBaseNestedType { }
			public class HideBaseNestedType { }
			public delegate int PublicDelegate ();
			private delegate int PrivateDelegate ();
		}

		[Kept]
		[KeptBaseType (typeof (PublicNestedTypesBaseType))]
		class PublicNestedTypesType : PublicNestedTypesBaseType
		{
			[Kept]
			[KeptMember (".ctor()")]
			public class PublicNestedType { }
			protected class ProtectedNestedType { }
			private class PrivateNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			public class HideNestedType { }

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			[KeptMember ("Invoke()")]
			public delegate int PublicDelegate ();

			private delegate int PrivateDelegate ();
		}


		[Kept]
		private static void RequireNonPublicNestedTypes (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicNestedTypesBaseType
		{
			// Nested types are not propagated from base class at all
			public class PublicBaseNestedType { }
			protected class ProtectedBaseNestedType { }
			private class PrivateBaseNestedType { }
			public class HideBaseNestedType { }
			public delegate int PublicDelegate ();
			private delegate int PrivateDelegate ();
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicNestedTypesBaseType))]
		class NonPublicNestedTypesType : NonPublicNestedTypesBaseType
		{
			public class PublicNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			protected class ProtectedNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			private class PrivateNestedType { }
			public class HideNestedType { }

			public delegate int PublicDelegate ();

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			[KeptMember ("Invoke()")]
			private delegate int PrivateDelegate ();
		}


		[Kept]
		private static void RequireAllNestedTypes (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllNestedTypesBaseType
		{
			// Nested types are not propagated from base class at all
			public class PublicBaseNestedType { }
			protected class ProtectedBaseNestedType { }
			private class PrivateBaseNestedType { }
			public class HideBaseNestedType { }
			public delegate int PublicBaseDelegate ();
			private delegate int PrivateBaseDelegate ();
		}

		[Kept]
		[KeptBaseType (typeof (AllNestedTypesBaseType))]
		class AllNestedTypesType : AllNestedTypesBaseType
		{
			[Kept]
			[KeptMember (".ctor()")]
			public class PublicNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			protected class ProtectedNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			private class PrivateNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			public class HideNestedType { }

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			[KeptMember ("Invoke()")]
			public delegate int PublicDelegate ();

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			[KeptMember ("Invoke()")]
			private delegate int PrivateDelegate ();
		}


		[Kept]
		private static void RequirePublicProperties (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicPropertiesBaseType
		{
			[Kept]
			public bool PublicPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool PublicPropertyGetterOnBase { [Kept] get { return false; } [Kept] private set { } }
			[Kept]
			public bool PublicPropertySetterOnBase { [Kept] private get { return false; } [Kept] set { } }
			[Kept]
			public bool PublicPropertyOnlyGetterOnBase { [Kept] get { return false; } }
			[Kept]
			public bool PublicPropertyOnlySetterOnBase { [Kept] set { } }
			protected bool ProtectedPropertyOnBase { get; set; }
			private bool PrivatePropertyOnBase { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static protected bool ProtectedStaticPropertyOnBase { get; set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }
		}

		[Kept]
		[KeptBaseType (typeof (PublicPropertiesBaseType))]
		class PublicPropertiesType : PublicPropertiesBaseType
		{
			[Kept]
			public bool PublicProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool PublicPropertyGetter { [Kept] get { return false; } [Kept] private set { } }
			[Kept]
			public bool PublicPropertySetter { [Kept] private get { return false; } [Kept] set { } }
			[Kept]
			public bool PublicPropertyOnlyGetter { [Kept] get { return false; } }
			[Kept]
			public bool PublicPropertyOnlySetter { [Kept] set { } }
			protected bool ProtectedProperty { get; set; }
			private bool PrivateProperty { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticProperty { [Kept] get; [Kept] set; }
			static protected bool ProtectedStaticProperty { get; set; }
			static private bool PrivateStaticProperty { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }
		}


		[Kept]
		private static void RequireNonPublicProperties (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicProperties)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicPropertiesBaseType
		{
			public bool PublicPropertyOnBase { get; set; }
			public bool PublicPropertyGetterOnBase { get { return false; } private set { } }
			public bool PublicPropertySetterOnBase { private get { return false; } set { } }
			public bool PublicPropertyOnlyGetterOnBase { get { return false; } }
			public bool PublicPropertyOnlySetterOnBase { set { } }
			[Kept]
			protected bool ProtectedPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			private bool PrivatePropertyOnBase { get; set; }
			public bool HideProperty { get; set; }

			static public bool PublicStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			static public bool HideStaticProperty { get; set; }
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicPropertiesBaseType))]
		class NonPublicPropertiesType : NonPublicPropertiesBaseType
		{
			public bool PublicProperty { get; set; }
			public bool PublicPropertyGetter { get { return false; } private set { } }
			public bool PublicPropertySetter { private get { return false; } set { } }
			public bool PublicPropertyOnlyGetter { get { return false; } }
			public bool PublicPropertyOnlySetter { set { } }
			[Kept]
			protected bool ProtectedProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			private bool PrivateProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			public bool HideProperty { get; set; }

			static public bool PublicStaticProperty { get; set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticProperty { [Kept] get; [Kept] set; }
			static public bool HideStaticProperty { get; set; }
		}

		[Kept]
		private static void RequireAllProperties (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllPropertiesBaseType
		{
			[Kept]
			public bool PublicPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool PublicPropertyGetterOnBase { [Kept] get { return false; } [Kept] private set { } }
			[Kept]
			public bool PublicPropertySetterOnBase { [Kept] private get { return false; } [Kept] set { } }
			[Kept]
			public bool PublicPropertyOnlyGetterOnBase { [Kept] get { return false; } }
			[Kept]
			public bool PublicPropertyOnlySetterOnBase { [Kept] set { } }
			[Kept]
			protected bool ProtectedPropertyOnBase { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			private bool PrivatePropertyOnBase { get; set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticPropertyOnBase { [Kept] get; [Kept] set; }
			static private bool PrivateStaticPropertyOnBase { get; set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }
		}

		[Kept]
		[KeptBaseType (typeof (AllPropertiesBaseType))]
		class AllPropertiesType : AllPropertiesBaseType
		{
			[Kept]
			public bool PublicProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool PublicPropertyGetter { [Kept] get { return false; } [Kept] private set { } }
			[Kept]
			public bool PublicPropertySetter { [Kept] private get { return false; } [Kept] set { } }
			[Kept]
			public bool PublicPropertyOnlyGetter { [Kept] get { return false; } }
			[Kept]
			public bool PublicPropertyOnlySetter { [Kept] set { } }
			[Kept]
			protected bool ProtectedProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			private bool PrivateProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }
			[Kept]
			public bool HideProperty { [Kept][ExpectBodyModified] get; [Kept][ExpectBodyModified] set; }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }
		}


		[Kept]
		private static void RequirePublicEvents (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class PublicEventsBaseType
		{
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEventOnBase;
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> PublicStaticEventOnBase;
			static protected event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			static private event EventHandler<EventArgs> PrivateStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (PublicEventsBaseType))]
		class PublicEventsType : PublicEventsBaseType
		{
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEvent;
			protected event EventHandler<EventArgs> ProtectedEvent;
			private event EventHandler<EventArgs> PrivateEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> PublicStaticEvent;
			static protected event EventHandler<EventArgs> ProtectedStaticEvent;
			static private event EventHandler<EventArgs> PrivateStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> HideStaticEvent;
		}


		[Kept]
		private static void RequireNonPublicEvents (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicEvents)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class NonPublicEventsBaseType
		{
			public event EventHandler<EventArgs> PublicEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			public event EventHandler<EventArgs> HideEvent;

			static public event EventHandler<EventArgs> PublicStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static protected event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			static private event EventHandler<EventArgs> PrivateStaticEventOnBase;
			static public event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (NonPublicEventsBaseType))]
		class NonPublicEventsType : NonPublicEventsBaseType
		{
			public event EventHandler<EventArgs> PublicEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			private event EventHandler<EventArgs> PrivateEvent;
			public event EventHandler<EventArgs> HideEvent;

			static public event EventHandler<EventArgs> PublicStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static protected event EventHandler<EventArgs> ProtectedStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static private event EventHandler<EventArgs> PrivateStaticEvent;
			static public event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		private static void RequireAllEvents (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		class AllEventsBaseType
		{
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			private event EventHandler<EventArgs> PrivateEventOnBase;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> PublicStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static protected event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			static private event EventHandler<EventArgs> PrivateStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		[KeptBaseType (typeof (AllEventsBaseType))]
		class AllEventsType : AllEventsBaseType
		{
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> PublicEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			private event EventHandler<EventArgs> PrivateEvent;
			[Kept]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			[method: ExpectBodyModified]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> PublicStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static protected event EventHandler<EventArgs> ProtectedStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static private event EventHandler<EventArgs> PrivateStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			static public event EventHandler<EventArgs> HideStaticEvent;
		}

		[Kept]
		private static void RequireInterfaces (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		interface IInterfaceOnBaseBase
		{
		}

		[Kept]
		[KeptInterface (typeof (IInterfaceOnBaseBase))]
		interface IInterfacesOnBase : IInterfaceOnBaseBase
		{
			void OnBaseInterfaceMethod ();
		}

		[Kept]
		[KeptInterface (typeof (IInterfacesOnBase))] // Interface implementations are collected across all base types, so this one has to be included as well
		[KeptInterface (typeof (IInterfaceOnBaseBase))] // Roslyn adds transitively implemented interfaces automatically
		class InterfacesBaseType : IInterfacesOnBase
		{
			public void OnBaseInterfaceMethod () { }
		}

		[Kept]
		interface IInterfacesEmpty
		{
		}

		[Kept]
		interface IInterfacesWithMethods
		{
			void InterfaceMethod ();
		}

		[Kept]
		interface IInterfaceGeneric<T>
		{
			void GenericMethod<U> (T t, U u);
		}

		[Kept]
		interface IInterfacesBase
		{
			void BaseMethod ();
		}

		[Kept]
		[KeptInterface (typeof (IInterfacesBase))]
		interface IInterfacesDerived : IInterfacesBase
		{
			void DerivedMethod ();
		}

		interface IInterfacesSuperDerived : IInterfacesDerived
		{
			void SuperDerivedMethod ();
		}

		[Kept]
		[KeptInterface (typeof (IInterfacesEmpty))]
		[KeptInterface (typeof (IInterfacesWithMethods))]
		[KeptInterface (typeof (IInterfacesBase))] // Roslyn adds transitively implemented interfaces automatically
		[KeptInterface (typeof (IInterfacesDerived))]
		[KeptInterface (typeof (IInterfaceGeneric<int>))]
		[KeptBaseType (typeof (InterfacesBaseType))]
		class InterfacesType : InterfacesBaseType, IInterfacesEmpty, IInterfacesWithMethods, IInterfacesDerived, IInterfaceGeneric<int>
		{
			public void InterfaceMethod ()
			{
			}

			public void BaseMethod ()
			{
			}

			public void DerivedMethod ()
			{
			}

			public void GenericMethod<U> (int t, U u)
			{
			}
		}

		[Kept]
		private static void RequireAll (
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
			[KeptAttributeAttribute(typeof(DynamicallyAccessedMembersAttribute))]
			Type type)
		{
		}

		[Kept]
		interface IAllBaseGenericInterface<T>
		{
			[Kept]
			void BaseInterfaceMethod ();
			[Kept]
			void BaseDefaultMethod () { }
		}

		[Kept]
		[KeptInterface (typeof (IAllBaseGenericInterface<Int64>))]
		interface IAllDerivedInterface : IAllBaseGenericInterface<Int64>
		{
			[Kept]
			void DerivedInterfaceMethod ();

			[Kept]
			void DerivedDefaultMethod () { }
		}

		[Kept]
		[KeptInterface (typeof (IAllDerivedInterface))]
		[KeptInterface (typeof (IAllBaseGenericInterface<Int64>))]
		class AllBaseType : IAllDerivedInterface
		{
			// This is different from all of the above cases.
			// All means really everything - so we include everything on base class as well - including private stuff

			[Kept]
			protected AllBaseType () { }

			[Kept]
			protected AllBaseType (int i) { }

			[Kept]
			public void PublicBaseMethod () { }
			[Kept]
			private void PrivateBaseMethod () { }
			[Kept]
			protected void ProtectedBaseMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			[KeptBackingField]
			public bool PublicPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			protected bool ProtectedPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			private bool PrivatePropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			public bool HideProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public event EventHandler<EventArgs> PublicEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected event EventHandler<EventArgs> ProtectedEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private event EventHandler<EventArgs> PrivateEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticBaseMethod () { }
			[Kept]
			private static void PrivateStaticBaseMethod () { }
			[Kept]
			protected static void ProtectedStaticBaseMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			public void DerivedInterfaceMethod () { }
			[Kept]
			public void BaseInterfaceMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticPropertyOnBase { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private static event EventHandler<EventArgs> PrivateStaticEventOnBase;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;

			[Kept]
			public bool PublicBaseField;
			[Kept]
			protected bool ProtectedBaseField;
			[Kept]
			private bool PrivateBaseField;
			[Kept]
			public bool HideField;

			[Kept]
			static public bool StaticPublicBaseField;
			[Kept]
			static protected bool StaticProtectedBaseField;
			[Kept]
			static private bool StaticPrivateBaseField;
			[Kept]
			static public bool HideStaticField;

			[Kept]
			[KeptMember (".ctor()")]
			public class PublicBaseNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			protected class ProtectedBaseNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			private class PrivateBaseNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			public class HideBaseNestedType { }

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("Invoke()")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			public delegate int PublicBaseDelegate ();

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("Invoke()")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			private delegate int PrivateBaseDelegate ();
		}

		[Kept]
		[KeptBaseType (typeof (AllBaseType))]
		[AddedPseudoAttributeAttribute ((uint) TypeAttributes.BeforeFieldInit)]
		class AllType : AllBaseType
		{
			[Kept]
			private AllType () { }

			[Kept]
			public AllType (int i) { }

			[Kept]
			private AllType (int i, int j) { }

			// Kept by the DynamicallyAccessedMembers logic
			[Kept]
			static AllType () { }


			[Kept]
			public void PublicMethod1 () { }
			[Kept]
			public bool PublicMethod2 (int i) { return false; }

			[Kept]
			internal void InternalMethod () { }
			[Kept]
			protected void ProtectedMethod () { }
			[Kept]
			private void PrivateMethod () { }
			[Kept]
			public void HideMethod () { }

			[Kept]
			[KeptBackingField]
			public bool PublicProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			protected bool ProtectedProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			private bool PrivateProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			public bool HideProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public event EventHandler<EventArgs> PublicEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected event EventHandler<EventArgs> ProtectedEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private event EventHandler<EventArgs> PrivateEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public event EventHandler<EventArgs> HideEvent;

			[Kept]
			public static void PublicStaticMethod () { }
			[Kept]
			private static void PrivateStaticMethod () { }
			[Kept]
			protected static void ProtectedStaticMethod () { }
			[Kept]
			public static void HideStaticMethod () { }

			[Kept]
			[KeptBackingField]
			static public bool PublicStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static protected bool ProtectedStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static private bool PrivateStaticProperty { [Kept] get; [Kept] set; }
			[Kept]
			[KeptBackingField]
			static public bool HideStaticProperty { [Kept] get; [Kept] set; }

			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> PublicStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			protected static event EventHandler<EventArgs> ProtectedStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			private static event EventHandler<EventArgs> PrivateStaticEvent;
			[Kept]
			[KeptBackingField]
			[KeptEventAddMethod]
			[KeptEventRemoveMethod]
			public static event EventHandler<EventArgs> HideStaticEvent;

			[Kept]
			public bool PublicField;
			[Kept]
			public string PublicStringField;
			[Kept]
			internal bool InternalField;
			[Kept]
			protected bool ProtectedField;
			[Kept]
			private bool PrivateField;
			[Kept]
			public bool HideField;

			[Kept]
			static public bool StaticPublicField;
			[Kept]
			static public string StaticPublicStringField;
			[Kept]
			static protected bool StaticProtectedField;
			[Kept]
			static private bool StaticPrivateField;
			[Kept]
			static public bool HideStaticField;

			[Kept]
			[KeptMember (".ctor()")]
			public class PublicNestedType
			{
				[Kept]
				private void Method () { }
			}

			[Kept]
			[KeptMember (".ctor()")]
			protected class ProtectedNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			private class PrivateNestedType { }
			[Kept]
			[KeptMember (".ctor()")]
			public class HideNestedType { }

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("Invoke()")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			public delegate int PublicDelegate ();

			[Kept]
			[KeptBaseType (typeof (MulticastDelegate))]
			[KeptMember (".ctor(System.Object,System.IntPtr)")]
			[KeptMember ("Invoke()")]
			[KeptMember ("BeginInvoke(System.AsyncCallback,System.Object)")]
			[KeptMember ("EndInvoke(System.IAsyncResult)")]
			private delegate int PrivateDelegate ();
		}

		[Kept]
		class RequireAllWithRecursiveTypeReferences
		{
			[Kept]
			RequireAllWithRecursiveTypeReferences ()
			{
			}

			[Kept]
			class NestedType
			{
				[Kept]
				NestedType ()
				{
				}

				[Kept]
				RequireAllWithRecursiveTypeReferences parent;
			}

			[Kept]
			[KeptMember (".ctor()")]
			[KeptBaseType (typeof (RequireAllWithRecursiveTypeReferences))]
			class NestedTypeWithRecursiveBase : RequireAllWithRecursiveTypeReferences
			{
			}

			[Kept]
			[KeptInterface (typeof (IEquatable<RequireAllWithRecursiveTypeReferences>))]
			[KeptMember (".ctor()")]
			class NestedTypeWithRecursiveGenericInterface : IEquatable<RequireAllWithRecursiveTypeReferences>
			{
				[Kept]
				public bool Equals (RequireAllWithRecursiveTypeReferences other)
				{
					throw new NotImplementedException ();
				}
			}

			[Kept]
			[KeptMember (".ctor()")]
			[KeptBaseType (typeof (List<RequireAllWithRecursiveTypeReferences>))]
			class NestedTypeWithRecursiveGenericBaseClass : List<RequireAllWithRecursiveTypeReferences>
			{
			}
		}
	}
}
