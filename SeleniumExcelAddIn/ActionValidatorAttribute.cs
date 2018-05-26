// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ActionValidatorAttribute : Attribute
    {
        public ActionValidatorAttribute(Type validatorType)
        {
            this.ValidatorType = validatorType;
        }

        public Type ValidatorType
        {
            get;
            private set;
        }

        public static Type GetActionValidatorType(ActionFlags value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var objs = (ActionValidatorAttribute[])type.GetField(name).GetCustomAttributes(typeof(ActionValidatorAttribute), false);

            return objs[0].ValidatorType;
        }
    }
}
