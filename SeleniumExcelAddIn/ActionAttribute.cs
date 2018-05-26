// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Linq;

namespace SeleniumExcelAddIn
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ActionAttribute : Attribute
    {
        public ActionAttribute(Type actionType)
        {
            this.ActionType = actionType;
        }

        public Type ActionType
        {
            get;
            private set;
        }

        public static Type GetActionType(ActionId actionId)
        {
            var type = actionId.GetType();
            var name = Enum.GetName(type, actionId);
            var objs = (ActionAttribute[])type.GetField(name).GetCustomAttributes(typeof(ActionAttribute), false);

            if (1 != objs.Length)
            {
                throw new InvalidOperationException("Undefined Action Attribute = " + actionId);
            }

            return objs[0].ActionType;
        }
    }
}
