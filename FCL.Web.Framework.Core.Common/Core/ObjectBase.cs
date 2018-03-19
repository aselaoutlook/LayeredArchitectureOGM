using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using FCL.Web.Framework.Core.Common.Extensions;

namespace FCL.Web.Framework.Core.Common.Core
{
    public abstract class ObjectBase : IExtensibleDataObject
    {
        public ObjectBase()
        {

        }
        
        public static CompositionContainer Container { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion

        #region Protected methods

        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
                                       Action<IList> snippetForCollection,
                                       params string[] exemptProperties)
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            List<string> exemptions = new List<string>();
            if (exemptProperties != null)
                exemptions = exemptProperties.ToList();

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = snippetForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {
                                    ObjectBase obj = (ObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            walk(this);
        }

        #endregion
    }
}
