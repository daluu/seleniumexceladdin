// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
//using System.Windows.Input;
using Microsoft.Office.Tools.Ribbon;

namespace SeleniumExcelAddIn
{
    public static class ActionManager
    {
        private static readonly Dictionary<string, Type> BindingClassDefine = new Dictionary<string, Type>()
        {
            {
                "Microsoft.Office.Tools.Ribbon.RibbonButtonImpl", 
                typeof(RibbonButtonActionBinding)
            },
            {
                "Microsoft.Office.Tools.Ribbon.RibbonSplitButtonImpl",
                typeof(RibbonSplitButtonActionBinding)
            },
            {
                "Microsoft.Office.Tools.Ribbon.RibbonToggleButtonImpl", 
                typeof(RibbonToggleButtonActionBinding)
            },
            {
                "System.Windows.Forms.ToolStripButton",
                typeof(ToolStripButtonActionBinding)
            },
            {
                "System.Windows.Forms.ToolStripSplitButton",
                typeof(ToolStripSplitButtonActionBinding)
            },
            {
                "System.Windows.Forms.ToolStripMenuItem", 
                typeof(ToolStripMenuItemActionBinding)
            },
        };

//        private static Dictionary<ActionId, ICommand> commands = new Dictionary<ActionId, ICommand>();
        private static Dictionary<ActionFlags, IActionValidator> validators = new Dictionary<ActionFlags, IActionValidator>();
        private static Dictionary<ActionId, IAction> actions = new Dictionary<ActionId, IAction>();
        private static Dictionary<object, IActionBinding> bindings = new Dictionary<object, IActionBinding>();
        private static Array executeFlags = Enum.GetValues(typeof(ActionFlags));
        private static Dictionary<ActionFlags, bool> canExecuteCache = new Dictionary<ActionFlags, bool>();
        private static bool enabled;

        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer()
        {
            Interval = 1000
        };

        private static List<ActionFlags> canExecuteFlags = new List<ActionFlags>()
        {
            ActionFlags.WorkbookPresent,
            ActionFlags.WorkbookEditable,
            ActionFlags.ListRow,
        };

        static ActionManager()
        {
            timer.Tick += (s, e) =>
            {
                UpdateInternal();
            };
        }

        internal static event EventHandler Updating;

        public static bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                enabled = value;
                Update();
            }
        }

        //public static ICommand CreateCommand(ActionId actionId)
        //{
        //    if (!commands.ContainsKey(actionId))
        //    {
        //        ICommand command = new Command(actionId);
        //        commands.Add(actionId, command);
        //    }

        //    return commands[actionId];
        //}

        public static void Bind(ActionId actionId, params object[] controls)
        {
            if (null == controls)
            {
                throw new ArgumentNullException("controls");
            }

            foreach (object control in controls)
            {
                if (bindings.ContainsKey(control))
                {
                    throw new InvalidOperationException("Already Bindings = " + control + " = " + actionId);
                }

                IActionBinding binding = CreateBinding(actionId, control);
                bindings.Add(control, binding);
            }
        }

        public static void Unbind(object control)
        {
            if (null == control)
            {
                throw new ArgumentNullException("control");
            }

            if (!bindings.ContainsKey(control))
            {
                return;
            }

            bindings.Remove(control);
        }

        public static void Execute(ActionId actionId)
        {
#if DEBUG
            Log.Logger.DebugFormat("Action Execute = {0}", actionId);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
#endif
            try
            {
                IAction action = GetAction(actionId);

                foreach (ActionFlags flag in executeFlags)
                {
                    var f = flag & action.Flags;
                    IActionValidator validator = GetValidator(f);
                    string error = validator.Validate();

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        MessageDialog.Warn(error);
                        return;
                    }
                }

                action.Execute();
#if DEBUG
                sw.Stop();
                Log.Logger.DebugFormat("Action Completed = {0}, {1}", actionId, sw.Elapsed);
#endif
            }
            catch (AggregateException ex)
            {
                ex.Flatten();

                foreach (var e in ex.InnerExceptions)
                {
                    Log.Logger.Warn(e);
                }

                MessageDialog.Error(ex.InnerException.Message);
            }
            catch (InvalidOperationException ex)
            {
                Log.Logger.Warn(ex);
                MessageDialog.Warn(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex);
                MessageDialog.Error(ex.Message);
            }
        }

        public static ActionId GetActionId(string actionName)
        {
            if (string.IsNullOrWhiteSpace(actionName))
            {
                throw new ArgumentNullException("actionName");
            }

            ActionId actionId;

            if (Enum.TryParse<ActionId>(actionName, true, out actionId))
            {
                return actionId;
            }

            string msg = string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.ActionManager_GetActionId_Error,
                actionName);

            throw new InvalidOperationException(msg);
        }

        internal static void Update(bool force = false)
        {
            if (!enabled)
            {
                return;
            }
//#if DEBUG
//            Log.Logger.DebugFormat("update(1)");
//#endif
            if (force)
            {
                UpdateInternal();
                return;
            }

            timer.Stop();
            timer.Start();
        }

        private static void UpdateInternal()
        {
//#if DEBUG
//            Log.Logger.DebugFormat("update(2)");
//#endif
            timer.Stop();
            canExecuteCache.Clear();
            Updating(null, EventArgs.Empty);
        }

        private static IAction GetAction(ActionId actionId)
        {
            if (actions.ContainsKey(actionId))
            {
                return actions[actionId];
            }

            Type t = ActionAttribute.GetActionType(actionId);
            IAction action = (IAction)Activator.CreateInstance(t);
            actions.Add(actionId, action);

            return action;
        }

        private static IActionValidator GetValidator(ActionFlags flag)
        {
            if (validators.ContainsKey(flag))
            {
                return validators[flag];
            }

            Type t = ActionValidatorAttribute.GetActionValidatorType(flag);
            IActionValidator validator = (IActionValidator)Activator.CreateInstance(t);
            validators.Add(flag, validator);

            return validator;
        }

        private static IActionBinding CreateBinding(ActionId actionId, object control)
        {
            if (null == control)
            {
                throw new ArgumentNullException("control");
            }

            Type controlType = control.GetType();
            string controlFullName = controlType.FullName;

            if (!BindingClassDefine.ContainsKey(controlFullName))
            {
                throw new NotSupportedException(controlFullName);
            }

            IActionBinding binding = Activator.CreateInstance(BindingClassDefine[controlFullName]) as IActionBinding;
            binding.Bind(actionId, control);

            return binding;
        }

        private static bool CanExecute(ActionId actionId)
        {
            if (!Enabled)
            {
                return true;
            }

            foreach (ActionFlags flag in canExecuteFlags)
            {
                IAction action = GetAction(actionId);
                var f = flag & action.Flags;

                if (canExecuteCache.ContainsKey(f))
                {
                    return canExecuteCache[f];
                }

                IActionValidator validator = GetValidator(f);
                string error = validator.Validate();
                bool isCanExecute = string.IsNullOrWhiteSpace(error);
                canExecuteCache.Add(f, isCanExecute);

                if (!isCanExecute)
                {
                    return false;
                }
            }

            return true;
        }

        #region

        //#region COMMAND

        //private class Command : ICommand
        //{
        //    public Command(ActionId actionId)
        //    {
        //        this.ActionId = actionId;

        //        ActionManager.Updating += (s, e) =>
        //        {
        //            if (null != this.CanExecuteChanged)
        //            {
        //                this.CanExecuteChanged(this, EventArgs.Empty);
        //            }
        //        };
        //    }

        //    public event EventHandler CanExecuteChanged;

        //    public ActionId ActionId
        //    {
        //        get;
        //        private set;
        //    }

        //    public bool CanExecute(object parameter)
        //    {
        //        return ActionManager.CanExecute(this.ActionId);
        //    }

        //    public void Execute(object parameter)
        //    {
        //        ActionManager.Execute(this.ActionId);
        //    }
        //}

        //#endregion

        #region IActionBinding

        private interface IActionBinding
        {
            void Bind(ActionId actionId, object control);
        }

        #endregion

        #region ActionBinging

        #region RibbonButtonActionBinding

        private class RibbonButtonActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                if (null == control)
                {
                    throw new ArgumentNullException("control");
                }

                RibbonButton nativeControl = (RibbonButton)control;

                nativeControl.Click += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                };
            }
        }

        #endregion

        #region RibbonSplitButtonActionBinding

        private class RibbonSplitButtonActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                RibbonSplitButton nativeControl = (RibbonSplitButton)control;

                nativeControl.Click += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                };
            }
        }

        #endregion

        #region RibbonToggleButtonActionBinding

        private class RibbonToggleButtonActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                RibbonToggleButton nativeControl = (RibbonToggleButton)control;

                nativeControl.Click += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    IAction action = ActionManager.GetAction(actionId);
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                    nativeControl.Checked = nativeControl.Enabled ? action.IsChecked : false;
                };
            }
        }

        #endregion

        #region ToopStripButton

        private class ToolStripButtonActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                ToolStripButton nativeControl = (ToolStripButton)control;

                nativeControl.Click += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    IAction action = ActionManager.GetAction(actionId);
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                    nativeControl.Checked = nativeControl.Enabled ? action.IsChecked : false;
                };
            }
        }

        #endregion

        #region ToopStripSplitButton

        private class ToolStripSplitButtonActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                ToolStripSplitButton nativeControl = (ToolStripSplitButton)control;

                nativeControl.ButtonClick += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                };
            }
        }

        #endregion

        #region ToolStripMenuItem

        private class ToolStripMenuItemActionBinding : IActionBinding
        {
            public void Bind(ActionId actionId, object control)
            {
                ToolStripMenuItem nativeControl = (ToolStripMenuItem)control;

                nativeControl.Click += (sender, e) =>
                {
                    ActionManager.Execute(actionId);
                };

                ActionManager.Updating += (s, e) =>
                {
                    IAction action = ActionManager.GetAction(actionId);
                    nativeControl.Enabled = ActionManager.CanExecute(actionId);
                    nativeControl.Checked = action.IsChecked;
                };
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
