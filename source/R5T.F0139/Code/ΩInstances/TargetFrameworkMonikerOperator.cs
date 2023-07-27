using System;


namespace R5T.F0139
{
    public class TargetFrameworkMonikerOperator : ITargetFrameworkMonikerOperator
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerOperator Instance { get; } = new TargetFrameworkMonikerOperator();


        private TargetFrameworkMonikerOperator()
        {
        }

        #endregion
    }
}
