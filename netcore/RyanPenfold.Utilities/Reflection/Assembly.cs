// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Assembly.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Reflection
{
    /// <summary>
    /// Contains functionality relating to <see cref="System.Reflection.Assembly"/> objects
    /// </summary>
    public static class Assembly
    {
        /*
        /// <summary>
        /// Traverses the call stack to find the assembly that indirectly called the current one.
        /// </summary>
        /// <returns>A <see cref="System.Reflection.Assembly"/>, if found</returns>
        public static System.Reflection.Assembly GetCallingAssembly()
        {
            // Result
            System.Reflection.Assembly callingAssembly = null;

            // Get the stack trace
            var stackTrace = new System.Diagnostics.StackTrace(0, true);

            // If there's only one frame (this frame), return
            if (stackTrace.FrameCount <= 1)
            {
                return null;
            }

            // Attempt to get the assembly for the method that called this method
            var executingAssembly = GetAssemblyFromStackFrame(stackTrace.GetFrame(1));

            // If there's only two frames (including this frame), return
            if (stackTrace.FrameCount <= 2)
            {
                return null;
            }

            // Loop through the stack frames starting at 2
            for (var stackFrameId = 2; stackFrameId < stackTrace.FrameCount; stackFrameId++)
            {
                // Attempt to get the stack frame
                var stackFrame = stackTrace.GetFrame(stackFrameId);

                // NULL-check the stack frame
                if (stackFrame == null)
                {
                    continue;
                }

                // Attempt to get the assembly
                var assembly = GetAssemblyFromStackFrame(stackFrame);

                // NULL-check the assembly
                if (assembly == null || assembly == executingAssembly)
                {
                    continue;
                }

                // Calling assembly found
                callingAssembly = assembly;

                break;
            }

            // Return the result
            return callingAssembly;
        }

        /// <summary>
        /// Determines the assembly that made a call for a given frame in the call stack
        /// </summary>
        /// <param name="stackFrame">The stack frame to determine the assembly from</param>
        /// <returns>A <see cref="System.Reflection.Assembly"/> object</returns>
        private static System.Reflection.Assembly GetAssemblyFromStackFrame(System.Diagnostics.StackFrame stackFrame)
        {
            // NULL-check the parameter
            if (stackFrame == null)
            {
                throw new System.ArgumentNullException(nameof(stackFrame));
            }

            // Attempt to get the method from the stack frame
            var methodBase = stackFrame.GetMethod();

            // If the methodbase is null, return null, otherwise search for the assembly from the given type
            return methodBase?.ReflectedType == null ? null : System.Reflection.Assembly.GetAssembly(methodBase.ReflectedType);
        } */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string GetManifestResourceString(this System.Reflection.Assembly assembly, string resourceName)
        {
            // NULL-check the parameters
            if (assembly == null)
            {
                throw new System.ArgumentNullException(nameof(assembly));
            }

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new System.ArgumentNullException(nameof(resourceName));
            }

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new System.Resources.MissingManifestResourceException($"Could not find manifest resource \"{resourceName}\" in assembly {assembly.FullName}.");
                }

                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
