using System;
using System.Threading.Tasks;
using Csla;
using Csla.Core;

namespace Library {
	public enum MyEnum {
		Value1,
		Value2
	}

	[Serializable]
    public class MyRootObject : ReadOnlyBase<MyRootObject> {
		public static readonly PropertyInfo<MobileList<IMyChildObject>> ChildObjectsProperty = RegisterProperty<MobileList<IMyChildObject>>(x => x.ChildObjects);
		public MobileList<IMyChildObject> ChildObjects {
			get { return GetProperty(ChildObjectsProperty); }
			private set { LoadProperty(ChildObjectsProperty, value); }
		}

		public static Task<MyRootObject> GetMyRootObjectAsync() {
		    return DataPortal.FetchAsync<MyRootObject>();
	    }

	    // ReSharper disable once UnusedMember.Local
	    private void DataPortal_Fetch() {
		    ChildObjects = new MobileList<IMyChildObject> {
			    MyChildObject.GetMyChildObject("name"),
				MyChildObject.GetMyChildObject("name2")
		    };
	    }
    }

	public interface IMyChildObject {
		string Name { get; }
		MyEnum Value { get; }
	}

	[Serializable]
	public class MyChildObject : ReadOnlyBase<MyChildObject>, IMyChildObject {
		public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(x => x.Name);
		public string Name {
			get { return GetProperty(NameProperty); }
			private set { LoadProperty(NameProperty, value); }
		}

		public static readonly PropertyInfo<MyEnum> ValueProperty = RegisterProperty<MyEnum>(x => x.Value);
		public MyEnum Value {
			get { return GetProperty(ValueProperty); }
			private set { LoadProperty(ValueProperty, value); }
		}

		public static MyChildObject GetMyChildObject(string name) {
			return DataPortal.FetchChild<MyChildObject>(name);
		}

		// ReSharper disable once UnusedMember.Local
		private void Child_Fetch(string name) {
			Name = name;
			Value = MyEnum.Value2;
		}
	}
}
